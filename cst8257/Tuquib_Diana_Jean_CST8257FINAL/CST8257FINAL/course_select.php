<?php
$cssFile = "course_select.css";
$jsFile = "course_select.js";
include "./Common/header.php";


if (!isset($_SESSION["studentSN"])) {
    header("Location:Login.php");
    exit();
}

## DB Operations
include "./Common/db.php";
$pdo = connect();


## variables
$errMsg = "";
$StudentSet = $_SESSION["StudentSet"];
$StudentId = $_SESSION["StudentId"];
$userName = $_SESSION["Name"];

## Semester 
$SemesterCodes = [];
$SemesterSet = [];
$SemesterSelected = "";

if ($pdo != null) {
    $SemesterSql = "select * from Semester";
    $SemesterSmt = $pdo->query($SemesterSql);
    $SemesterSet = $SemesterSmt->fetchAll(PDO::FETCH_ASSOC);

    foreach ($SemesterSet as $row) {
        $SemesterCodes[] = $row['SemesterCode'];
    }
}
if (isset($_GET['SemesterSelected'])) {
    $SemesterSelected = $_GET['SemesterSelected'];
} elseif (isset($_POST['SelSemester'])) {
    $SemesterSelected = $_POST['SelSemester'];
} elseif (sizeof($SemesterCodes) > 0) {
    $SemesterSelected = $SemesterCodes[0];
}

## end of Semester 

## Registration
$totalhoursArray = [];
$totalWeekHr = 0;
if ($pdo != null) {
    $RegistrationSql = <<<REG
    select totalhours,SemesterCode
    from (select sum(c.WeeklyHours) as totalhours, r.StudentId,r.SemesterCode
          from Registration r
                   inner join Course c on c.CourseCode = r.CourseCode
          group by r.StudentId, r.SemesterCode) t 
          left join Student s on s.StudentId=t.StudentId
          where t.StudentId='{$StudentId}' and t.SemesterCode='{$SemesterSelected}'
    REG;

    $RegistrationRslt = $pdo->query($RegistrationSql);

    foreach ($RegistrationRslt as $rslt) {
        $key = $rslt['SemesterCode'];
        $value = $rslt['totalhours'];
        $totalhoursArray[$key] = intval($value);
    }
}
$totalWeekHr = (isset($totalhoursArray[$SemesterSelected])) ? $totalhoursArray[$SemesterSelected] : $totalWeekHr;
## end Registration

if (isset($_POST['_submit'])) {
    //extract $_POST here #4
    extract($_POST);
    if (!isset($_POST['courseId'])) {
        $errMsg = "You need to select at least one course!";
    } else {
        $errMsg = "";
        $currentWeekHr = $totalWeekHr;
        foreach ($courseId as $CourseCode) {
            $currentWeekHr += intval($courseWH[$CourseCode]);
        }
        if ($currentWeekHr <= 16) {
            if ($pdo != null) {
                $insertSql = "insert into Registration (StudentId,CourseCode,SemesterCode) values (?,?,?)";
                $insertSmt = $pdo->prepare($insertSql);
                foreach ($courseId as $CourseCode) {
                    $insertSmt->execute([$StudentId, $CourseCode, $SelSemester]);
                }
                $totalWeekHr = $currentWeekHr;
            }
        } else {
            $errMsg = "You have exceeded the max weekly hours.";
        }
    }
}

$totalWeekHrLeft = 16 - $totalWeekHr;
?>
<div class="content">
    <div class="innerContents">
        <h1>Course Selection</h1>
        <p class="title">
            Welcome <?php echo $userName; ?> (not you? change user <a href="Login.php">here</a> )<br />
            You have registered <?php echo $totalWeekHr; ?> hours for the selected semester<br />
            You can register <?php echo $totalWeekHrLeft; ?> more hours of course(s) for the semester<br />
            Please note that the courses you have registered will not be displayed in the list
        </p>
        <div class="select">
            <select name="Semester" id="Semester">
                <?php
                foreach ($SemesterSet as $row) {
                    $selected = ($SemesterSelected == $row['SemesterCode']) ? "selected" : "";
                    echo "<option value='" . $row['SemesterCode'] . "' " . $selected . ">" . $row['year'] . " " . $row['term'] . "</option>";
                }
                ?>
            </select>
        </div>
        <form action="<?php echo $_SERVER['PHP_SELF'] ?>" method="post"> <!-- #5 use $_SERVER['PHP_SELF'] instead of course_select.php -->
            <?php $SelSemester = ($SemesterSelected != "") ? $SemesterSelected : $SemesterCodes[0]; ?>
            <label class="error"><?php echo $errMsg; ?></label>
            <input type="hidden" name="SelSemester" value="<?php echo $SelSemester; ?>">
            <table>
                <tr>
                    <th>Code</th>
                    <th>Course Title</th>
                    <th>Hours</th>
                    <th>Select</th>
                </tr>
                <?php
                if ($pdo != null) {
                    try {
                        $sql = <<<SQL_SELECT
                Select o.CourseCode,Title,WeeklyHours,o.SemesterCode from CourseOffer o 
                left join Course C on o.CourseCode = C.CourseCode 
                left join Semester S2 on S2.SemesterCode = o.SemesterCode
                SQL_SELECT;

                        $sql .= " where S2.SemesterCode='";
                        $sql .= ($SemesterSelected != "") ? $SemesterSelected : $SemesterCodes[0];
                        $sql .= "'";
                        $sql .= " and not exists (select * from Registration r where r.CourseCode=o.CourseCode and r.SemesterCode=o.SemesterCode and r.StudentId='";
                        $sql .= $StudentId;
                        $sql .= "')";
                        $resultSet = $pdo->query($sql);
                        foreach ($resultSet as $row) {
                            print <<<TABLE_BODY
                    <tr>
                        <td>{$row['CourseCode']}</td>
                        <td>{$row['Title']}</td>
                        <td>{$row['WeeklyHours']}</td>
                        <td><input type="checkbox" name="courseId[]" id="courseId[]" value="{$row['CourseCode']}"></td>
                        <input type="hidden" name="courseWH[{$row['CourseCode']}]" value="{$row['WeeklyHours']}">
                    </tr>
                    TABLE_BODY;
                        }
                        $pdo = null;
                    } catch (\Throwable $th) {
                        echo $th->getMessage();
                    }
                }
                ?>
                <tr>
                    <td></td>
                    <td><input type="submit" name="_submit" value="Submit"></td>
                    <td><input type="reset" value="Clear"></td>
                    <td></td>
                </tr>
            </table>
        </form>

    </div>
</div>
<?php
include "./Common/footer.php";
?>
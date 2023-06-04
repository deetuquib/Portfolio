<?php
//session_start(); // remove to avoid duplicate
$cssFile = "course_registration.css";
$jsFile = "current_registration.js";
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

if (isset($_POST['_submit'])) {
    $SelectedRegistered = $_POST['SelectedRegistered'];
    foreach ($SelectedRegistered as $cscode => $semcode) {
        register_del($pdo, $StudentId, $cscode, $semcode);
    }
}


?>
<div class="content">
    <div class="innerContents">
        <h1>Current Registrations</h1>
        <p>
            Hello <?php echo $userName; ?> (not you? change user <a href="Login.php">here</a> ), the following are your current registrations.
        </p>
        <form id="deleteForm" action="<?php echo $_SERVER['PHP_SELF']; ?>" method="post">
            <table>
                <tr>
                    <th>Year</th>
                    <th>Term</th>
                    <th>Course Code</th>
                    <th>Course Title</th>
                    <th>Hours</th>
                    <th>Select</th>
                </tr>
                <?php

                if ($pdo != null) {
                    $semesterSet = register_Semester($pdo);
                    foreach ($semesterSet as $srow) {
                        $hrs = $srow['Hrs'];
                        $SemesterCode = $srow['SemesterCode'];
                        $registerSet = register_query($pdo, $StudentId, $SemesterCode);
                        foreach ($registerSet as $row) {
                            $CourseCode = $row['CourseCode'];
                            print <<<REG
                    <tr>
                    <td>{$row['Year']}</td>
                    <td>{$row['Term']}</td>
                    <td>{$CourseCode}</td>
                    <td>{$row['Title']}</td>
                    <td>{$row['WeeklyHours']}</td>
                    <td><input type="checkbox" name="SelectedRegistered[{$CourseCode}]" value="{$SemesterCode}"></td>
                    </tr>
                REG;
                        }
                        echo "<tr><td colspan='4' class='summary'>Total Weekly Hours</td><td>{$hrs}</td><td></td></tr>";
                    }
                }
                ?>
            </table>
            <input type="hidden" name="_submit">
            <div><button id="deleteBtn" type="submit" onclick="return confirm('The selected registrations will be deleted!');">Delete Selected</button>&nbsp;<input type="reset" value="Clear"></div>
        </form>
    </div>
</div>
<?php
function register_query(&$pdo_obj, $sid, $sc)
{
    $registerSql = <<<SQL
    select s.Year,s.Term,r.CourseCode,C.Title,C.WeeklyHours from Registration r
    left join Semester s on r.SemesterCode = s.SemesterCode
    left join Course C on r.CourseCode = C.CourseCode
    where r.StudentId='{$sid}' and r.SemesterCode='{$sc}'
SQL;
    $registerSmt = $pdo_obj->query($registerSql);
    return $registerSmt->fetchAll(PDO::FETCH_ASSOC);
}
function register_Semester(&$pdo_obj)
{
    $sql = <<<SQLS
        select SemesterCode,sum(C.WeeklyHours) as Hrs from Registration r
        left join Course C on r.CourseCode = C.CourseCode
        group by SemesterCode order by SemesterCode
    SQLS;
    $smt = $pdo_obj->query($sql);
    return $smt->fetchAll(PDO::FETCH_ASSOC);
}
function register_del(&$pdo_obj, $stid, $cscode, $semcode)
{
    // #10 use prepare($sql)
    $sql = "DELETE FROM Registration WHERE StudentId = :stid AND SemesterCode = :semcode AND CourseCode = :cscode;";
    $smt = $pdo_obj -> prepare($sql);
    $smt->execute();
    
        //$sql = "delete from Registration where StudentId='{$stid}' and CourseCode='{$cscode}' and SemesterCode='{$semcode}'";
        //$smt = $pdo_obj->query($sql);    
    //$smt = $pdo_obj->prepare($sql);
    //$smt->execute();
}
include "./Common/footer.php";
$pdo = null;
?>
$(function() {
    $("#Semester").on('change', function() {
        let formStr = '<form action="course_select.php">';
        formStr += '<input type="hidden" name="SemesterSelected" value="';
        formStr += this.value;
        formStr += '"></form>';
        $(formStr).appendTo('body').submit();
    });
});
$(function() {
    $("#deleteBtn").on("click", e => {
        if (confirm("The selected registration will be deleted!")) {
            $("#deleteForm").submit();
        }
    });
});
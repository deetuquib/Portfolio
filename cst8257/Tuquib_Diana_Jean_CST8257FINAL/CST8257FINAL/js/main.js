var urls = {
    'Home': 'index.php',
    'Course Selection': 'course_select.php',
    'Current Registration': 'current_registration.php'
};
$(function() {
    $(".container>.header .byjs").each((index, item) => {
        $(item).text(Object.keys(urls)[index]);
        $(item).on("click", function() {
            window.location = urls[$(this).text()];
        });
    });
});
/* javaaaascriptt */

$("#addItemJob").click(function () {
    $.ajax({
        url: this.href,
        cache: false,
        success: function (html) { $("#editorRowsJob").append(html); }
    });
    return false;
});

$("#addItemSchool").click(function () {
    $.ajax({
        url: this.href,
        cache: false,
        success: function (html) { $("#editorRowsSchool").append(html); }
    });
    return false;
});

$(".deleteRowJob").on("click", null, function () {
    $(this).parents(".editorRowJob:first").remove();
    return false;
});

$(".deleteRowSchool").on("click", null, function () {
    $(this).parents(".editorRowSchool:first").remove();
    return false;
});

// Debug mode:
$('.ajax').click(function() {
    var test = $('#kowed').serialize();
    console.log(test);
})
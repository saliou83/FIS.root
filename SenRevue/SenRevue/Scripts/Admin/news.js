$(document).ready(function () {
    $("#btnAddArticle").off('click').on("click", function (e) {
        e.preventDefault();
        $("#actionResult").html('<br />');
        
        $.ajax({
            url: $("#addArticleLink").val(),
            success: function (data) {
                $('#modalWrapper').html(data);

                $('#modalNews').modal();
            }
        });
    });
});
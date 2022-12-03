$(function () {
    let $removeButtons = $(".remove-button");
    let $downloadButtons = $(".download-button");

    $removeButtons.on("click", function (e) {

        let $that = $(this);

        $.ajax({
            contentType: "application/json",
            url: "/Home/RemoveHomework/",
            data: JSON.stringify({
                id: $that.data("id")
            }),
            type: "POST",
            success: function () {
                $that.parent().remove();
            }
        });
    });

    $downloadButtons.on("click", function (e) {
        let $that = $(this);
        
        $.ajax({
            url: "/Home/DownloadHomework/" + $that.data("id"),
            type: "GET"
        });
    });
});
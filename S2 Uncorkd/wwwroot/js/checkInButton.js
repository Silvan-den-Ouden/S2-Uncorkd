function sendData(wineId) {
    var sliderValue = slider.value;

    $.ajax({
        url: '@Url.Action("SendData", "Review")',
        type: 'GET',
        data: { sliderValue: sliderValue, wineId: wineId },
        success: function (data) {
            console.log(data);
            location.href = '/profile/reviews';
        },
        error: function (error) {
            console.log("error", error);
        }
    });
}
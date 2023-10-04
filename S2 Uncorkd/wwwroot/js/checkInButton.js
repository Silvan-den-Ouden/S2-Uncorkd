function sendData(wineId) {
    var sliderValue = slider.value;
    var tasteTags = document.getElementById("selectedTags").textContent;

    $.ajax({
        url: '/Review/SendData',
        type: 'GET',
        data: { sliderValue: sliderValue, wineId: wineId, tasteTags: tasteTags },
        success: function (data) {
            console.log(data);
            location.href = '/profile/reviews';
        },
        error: function (error) {
            console.log("error", error);
        }
    });
}
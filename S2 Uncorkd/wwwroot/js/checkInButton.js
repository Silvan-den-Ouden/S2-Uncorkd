function sendData(wineId) {
    var sliderValue = slider.value;
    var tasteTags = document.getElementById("selectedTags").textContent;
    var comment = document.getElementById("comment").value;

    if (tasteTags === null || tasteTags === '') {
        tasteTags = '0';
    }

    if (comment === null || comment === '') {
        comment = 'no comment'
    }

    $.ajax({
        url: '/Review/SendData',
        type: 'GET',
        data: { sliderValue: sliderValue, wineId: wineId, tasteTags: tasteTags, comment: comment },
        success: function (data) {
            console.log(data);
            location.href = '/profile/reviews';
        },
        error: function (error) {
            console.log("error", error);
        }
    });
}

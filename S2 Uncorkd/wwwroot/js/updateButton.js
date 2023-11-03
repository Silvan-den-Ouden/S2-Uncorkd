function updateWine(wine_id) {
    var tasteTags = document.getElementById("selectedTags").textContent;
    var description = document.getElementById("description").value;
    var name = document.getElementById("wine-name").value;
    var image_url = document.getElementById("winery-icon").src;


    if (name === '') {
        alert("Please enter a name");
    } else if (description === '') {
        alert("Please enter a descritption");
    } else if (tasteTags.split(",").length !== 5) {
        alert("Please select 5 taste tags");
    } else {
        $.ajax({
            url: '/Wine/UpdateWine',
            type: 'GET',
            data: { wineId: wine_id, name: name, description: description, tasteTags: tasteTags, image_url: image_url },
            success: function (data) {
                console.log(data);
                location.href = '';
            },
            error: function (error) {
                console.log("error", error);
            }
        });
    }
}

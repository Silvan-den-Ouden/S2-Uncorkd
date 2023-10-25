function uploadWine(wineryId) {
    var tasteTags = document.getElementById("selectedTags").textContent;
    var description = document.getElementById("description").value;
    var name = document.getElementById("wine-name").value;

    if (name === '') {
        alert("Please enter a name");
    } else if (description === '') {
        alert("Please enter a descritption");
    } else if (tasteTags.split(",").length !== 5) {
        alert("Please select 5 taste tags");
    } else {
        $.ajax({
            url: '/Wine/Create',
            type: 'GET',
            data: { wineryId: wineryId, name: name, description: description, tasteTags: tasteTags },
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

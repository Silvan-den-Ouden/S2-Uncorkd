var expanded = false;

function expandFlavors() {
    var tags = document.querySelectorAll(".cat");
    const selectedTagCountElement = document.getElementById("expandFlavors");
    const moreButton = document.getElementById("moreButton");
    const lessButton = document.getElementById("lessButton");


    if (!expanded) {
        for (var i = 0; i < 5; i++) {
            tags[i].style.display = "block";
        }
        for (var i = 5; i < tags.length; i++) {
            tags[i].style.display = "none";
        }
        moreButton.style.display = "block";
        lessButton.style.display = "none";
        selectedTagCountElement.textContent = "Flavor Profile >";

        expanded = true;
    } else {
        for (var i = 5; i < tags.length; i++) {
            tags[i].style.display = "block";
        }
        moreButton.style.display = "none";
        lessButton.style.display = "block";
        selectedTagCountElement.textContent = "Flavor Profile v";

        expanded = false;
    }
}

expandFlavors();

function handleCheckboxChange() {
    const checkboxes = document.querySelectorAll('input[name="category"]');
    const selectedTagsArray = [];

    checkboxes.forEach(checkbox => {
        if (checkbox.checked) {
            selectedTagsArray.push(checkbox.value);
        }
    });

    const selectedTagsElement = document.getElementById('selectedTags');
    selectedTagsElement.textContent = selectedTagsArray.join(', ');
}

const checkboxes = document.querySelectorAll('input[name="category"]');
checkboxes.forEach(checkbox => {
    checkbox.addEventListener('change', handleCheckboxChange);
});

// Initial call to populate selected tags
handleCheckboxChange();
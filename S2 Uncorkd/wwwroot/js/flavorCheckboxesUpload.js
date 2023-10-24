var expanded = false;

function expandFlavors() {
    var tags = document.querySelectorAll(".cat");

    if (!expanded) {
        for (var i = 0; i < 10; i++) {
            tags[i].style.display = "block";
        }
        for (var i = 10; i < tags.length; i++) {
            tags[i].style.display = "none";
        }
        expanded = true;
    } else {
        for (var i = 10; i < tags.length; i++) {
            tags[i].style.display = "block";
        }
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

    if (selectedTagsArray.length >= 5) {
        //alert("You can select a maximum of 5 tasteTags.");
        checkboxes.forEach(checkbox => {
            if (!selectedTagsArray.includes(checkbox.value)) {
                checkbox.disabled = true;
            }
        });
    } else {
        checkboxes.forEach(checkbox => {
            checkbox.disabled = false;
        });
    }

    const selectedTagsElement = document.getElementById('selectedTags');
    selectedTagsElement.textContent = selectedTagsArray.join(', ');

    const selectedTagCountElement = document.getElementById('selectedTagCount');
    selectedTagCountElement.textContent = selectedTagsArray.length + "/5";

}

const checkboxes = document.querySelectorAll('input[name="category"]');
checkboxes.forEach(checkbox => {
    checkbox.addEventListener('change', handleCheckboxChange);
});

// Initial call to populate selected tags
handleCheckboxChange();

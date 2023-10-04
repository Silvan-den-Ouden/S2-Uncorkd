function expandFlavors() {
    console.log("haha dit doet nog niks")
}

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
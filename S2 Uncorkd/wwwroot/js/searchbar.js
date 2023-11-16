var selectedMenu = "wineMenu";
const input = document.getElementById("mySearch");
const flexbox = document.getElementById("flexboxes");
const menuButtons = document.getElementById("menuButtons");

function searchBar() {
    var filter = input.value.toUpperCase();
    var container = document.getElementById(selectedMenu);

    if (!container) {
        console.error("Container not found. Check if the ID is correct.");
        return;
    }

    var items = container.getElementsByTagName("div");

    // Only display search bar when typing innit
    if (filter == "") {
        container.style.display = "none";
        menuButtons.style.display = "none";
        flexbox.style.display = "block";
    } else {
        container.style.display = "block";
        menuButtons.style.display = "block";
        flexbox.style.display = "none";
    }

    // Hide items that don't match search query unless searching for #
    if (filter == "#") {
        for (i = 0; i < items.length; i++) {
            items[i].style.display = "block";
        }
    } else {
        for (i = 0; i < items.length; i++) {
            a = items[i].getElementsByTagName("a")[0];
            if (a.innerHTML.toUpperCase().indexOf(filter) > -1) {
                items[i].style.display = "block";
            } else {
                items[i].style.display = "none";
            }
        }
    }
}

function displayMenuButtons() {
    flexbox.style.display = "none";
    menuButtons.style.display = "block";
}

function handleRadioChange(event) {
    const selectedValue = event.target.value;
    const currentMenu = document.getElementById(selectedMenu);

    // Hide all elements from previous (current) menu
    if (currentMenu) {
        const currentItems = currentMenu.getElementsByTagName("div");
        for (let i = 0; i < currentItems.length; i++) {
            currentItems[i].style.display = "none";
        }
    }

    selectedMenu = selectedValue + "Menu";

    searchBar();

    menuButtons.style.display = "block";
    flexbox.style.display = "none";
}
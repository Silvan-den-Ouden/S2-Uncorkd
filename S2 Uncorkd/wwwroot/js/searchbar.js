var selectedMenu = "wineMenu";
const input = document.getElementById("mySearch");
const flexbox = document.getElementById("flexboxes");
const menuButtons = document.getElementById("menuButtons");

function searchBar() {
    var filter = input.value.toUpperCase();
    var container = document.getElementById(selectedMenu);
    var a;

    if (!container) {
        console.error("Container not found. Check if the ID is correct.");
        return;
    }

    var viewContainer = container.getElementsByClassName("search-container");
    var items = container.getElementsByClassName("information-container");

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
            viewContainer[i].style.display = "block";
        }
    } else {
        for (i = 0; i < items.length; i++) {
            a = items[i].getElementsByTagName("a")[0];
            if (a.innerHTML.toUpperCase().indexOf(filter) > -1) {
                viewContainer[i].style.display = "block";
            } else {
                viewContainer[i].style.display = "none";
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
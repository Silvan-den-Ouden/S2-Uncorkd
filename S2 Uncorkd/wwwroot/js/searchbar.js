var selectedMenu;

function searchBar() {
    var input, filter, ul, li, a, i;
    input = document.getElementById("mySearch");
   
    filter = input.value.toUpperCase();

    if (selectedMenu == null) {
        selectedMenu = "wineMenu";
    }

    ul = document.getElementById(selectedMenu);
    li = ul.getElementsByTagName("li");

    // Only display search bar when typing innit
    if (filter == "") {
        ul.style.display = "none";
        menuButtons.style.display = "none";
    } else {
        ul.style.display = "block";
        menuButtons.style.display = "block";
    }

    // Hide items that don't match search query unless searching for #
    if (filter == "#") {
        for (i = 0; i < li.length; i++) {
            li[i].style.display = "block";
        }
    } else {
        for (i = 0; i < li.length; i++) {
            a = li[i].getElementsByTagName("a")[0];
            if (a.innerHTML.toUpperCase().indexOf(filter) > -1) {
                li[i].style.display = "block";
            } else {
                li[i].style.display = "none";
            }
        }
    }
}

function displayMenuButtons() {
    const menuButtons = document.getElementById("menuButtons");

    menuButtons.style.display = "block";
}

function handleRadioChange(event) {
    const selectedValue = event.target.value;
    const currentMenu = document.getElementById(selectedMenu);


    // Hide all elements from previous (current) menu
    if (currentMenu) {
        const currentItems = currentMenu.getElementsByTagName("li");
        for (let i = 0; i < currentItems.length; i++) {
            currentItems[i].style.display = "none";
        }
    }

    selectedMenu = selectedValue + "Menu";

    searchBar();

    menuButtons.style.display = "block";
}

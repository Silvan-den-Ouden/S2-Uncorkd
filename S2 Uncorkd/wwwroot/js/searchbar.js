var selectedMenu;

function searchBar() {
    var input, filter, ul, li, a, i;
    input = document.getElementById("mySearch");
    filter = input.value.toUpperCase();

    console.log(filter);

    if (selectedMenu == null) {
        selectedMenu = "wineMenu";
    }

    ul = document.getElementById(selectedMenu);
    li = ul.getElementsByTagName("li");

    // Only display search bar when typing innit
    if (filter == "") {
        ul.style.display = "none";
    } else {
        ul.style.display = "block";
    }

    // Hide items that don't match search query
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

function handleRadioChange(event) {
    const selectedValue = event.target.value;
    const currentMenu = document.getElementById(selectedMenu);

    if (currentMenu) {
        const currentItems = currentMenu.getElementsByTagName("li");
        for (let i = 0; i < currentItems.length; i++) {
            currentItems[i].style.display = "none";
        }
    }

    selectedMenu = selectedValue + "Menu";

    searchBar();
}

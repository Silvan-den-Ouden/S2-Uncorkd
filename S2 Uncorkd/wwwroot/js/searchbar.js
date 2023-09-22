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
    if (filter !== "") {
        ul.style.display = "block";
    } else {
        ul.style.display = "none";
    }

    // Hide items that don't match search query
    if (filter !== "#") {
        for (i = 0; i < li.length; i++) {
            a = li[i].getElementsByTagName("a")[0];
            if (a.innerHTML.toUpperCase().indexOf(filter) > -1) {
                li[i].style.display = "";
            } else {
                li[i].style.display = "none";
            }
        }
    }
}

function handleRadioChange(event) {
    const selectedValue = event.target.value;
    const searchBar = document.getElementById("mySearch");
   
    console.log("Selected value:", selectedValue);

    searchBar.value = "";

    if (selectedValue == "wine") {
        selectedMenu = "wineMenu";
    }
    if (selectedValue == "winery") {
        selectedMenu = "wineryMenu";
    }

    return selectedMenu;
}
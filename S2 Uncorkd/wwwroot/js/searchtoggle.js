const wineRadio = document.getElementById("wineRadio");
const wineryRadio = document.getElementById("wineryRadio");
const myMenu = document.getElementById("myMenu");

wineRadio.addEventListener("change", function () {
    if (wineRadio.checked) {
        myMenu.style.display = "block"; // Show the wine list
    } else {
        myMenu.style.display = "none"; // Hide the list
    }
});

wineryRadio.addEventListener("change", function () {
    if (wineryRadio.checked) {
        myMenu.style.display = "block"; // Show the winery list
    } else {
        myMenu.style.display = "none"; // Hide the list
    }
});
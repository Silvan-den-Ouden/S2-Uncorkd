var slider = document.getElementById("myRange");
var sliderValueText = document.getElementById("sliderValue");
sliderValueText.textContent = (slider.value / 4).toFixed(2);

slider.addEventListener("input", function () {
    sliderValueText.textContent = (slider.value / 4).toFixed(2);
});

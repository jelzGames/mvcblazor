document.addEventListener("DOMContentLoaded", function () {
    const images = document.querySelectorAll(".img-container");
    const captions = document.querySelectorAll(".caption");
    const header = document.getElementById("main-header");
    const buttonContainer = document.getElementById("portfolio-button-container");

    setTimeout(() => {
        images.forEach((el, i) => {
            setTimeout(() => {
                el.classList.add("visible");
            }, 700 + i * 200);
        });

        captions.forEach((caption, i) => {
            setTimeout(() => {
                caption.classList.add("visible");
            }, 700 + i * 200);
        });

        setTimeout(() => {
            header.classList.add("visible");
            buttonContainer.classList.add("visible");
        }, 700 + images.length * 200);
    }, 800);
});
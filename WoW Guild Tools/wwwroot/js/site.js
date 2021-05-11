var coll = document.getElementsByClassName("collapsible__trigger");
var i;

for (i = 0; i < coll.length; i++) {
    coll[i].addEventListener("click", function () {
        var content = this.nextElementSibling;
        this.classList.toggle("collapsible--shown");
        if (content.style.maxHeight) {
            content.style.maxHeight = null;
        } else {
            content.style.maxHeight = content.scrollHeight + "px";
        }
    });

    //Uncollapse is there's an active element within the collapse
    //TODO: swap to using active?
    if (coll[i].classList.contains("collapsible--shown")) {
        var content = coll[i].nextElementSibling;
        content.style.maxHeight = content.scrollHeight + "px";
    }
}

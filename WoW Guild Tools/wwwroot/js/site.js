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

    // Uncollapse if there's an active element within the collapse
    // TODO: swap to using active?
    if (coll[i].classList.contains("collapsible--shown")) {
        var content = coll[i].nextElementSibling;
        content.style.maxHeight = content.scrollHeight + "px";
    }
}


// Library / Framework specific
$(document).ready(function () {
    $('select').select2({
        minimumResultsForSearch: Infinity,
        dropdownAutoWidth: true,
        theme: 'slate',
        //placeholder: {
        //    id: '0', // the value of the option
        //    text: 'Select an option'
        //}
    });
    $(".select--search").select2({
        theme: 'slate',
    });
});

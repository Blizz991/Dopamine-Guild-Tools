//Prevent wowhead tooltips from linking - there's something to be considered for whether or not this makes sense.
var wowheadlinks = document.getElementsByClassName("wowheadtooltip");
for (var i = 0; i < wowheadlinks.length; i++) {
    wowheadlinks[i].addEventListener("click", function (e) {
        e.preventDefault();
    })
}

var coll = document.getElementsByClassName("collapsible__trigger");
var i;

for (i = 0; i < coll.length; i++) {
    coll[i].addEventListener("click", function (e) {
        e.preventDefault();
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

function sortTable(n, tableElemId) {
    var table, rows, switching, i, x, y, shouldSwitch, dir, switchcount = 0;
    table = document.getElementById(tableElemId);
    switching = true;
    // Set the sorting direction to ascending:
    dir = "asc";
    /* Make a loop that will continue until
    no switching has been done: */
    while (switching) {
        // Start by saying: no switching is done:
        switching = false;
        rows = table.rows;
        /* Loop through all table rows (except the
        first, which contains table headers): */
        for (i = 1; i < (rows.length - 1); i++) {
            // Start by saying there should be no switching:
            shouldSwitch = false;
            /* Get the two elements you want to compare,
            one from current row and one from the next: */
            x = rows[i].getElementsByTagName("TD")[n];
            y = rows[i + 1].getElementsByTagName("TD")[n];
            /* Check if the two rows should switch place,
            based on the direction, asc or desc: */
            if (dir == "asc") {
                if (x.innerHTML.toLowerCase() > y.innerHTML.toLowerCase()) {
                    // If so, mark as a switch and break the loop:
                    shouldSwitch = true;
                    break;
                }
            } else if (dir == "desc") {
                if (x.innerHTML.toLowerCase() < y.innerHTML.toLowerCase()) {
                    // If so, mark as a switch and break the loop:
                    shouldSwitch = true;
                    break;
                }
            }
        }
        if (shouldSwitch) {
            /* If a switch has been marked, make the switch
            and mark that a switch has been done: */
            rows[i].parentNode.insertBefore(rows[i + 1], rows[i]);
            switching = true;
            // Each time a switch is done, increase this count by 1:
            switchcount++;
        } else {
            /* If no switching has been done AND the direction is "asc",
            set the direction to "desc" and run the while loop again. */
            if (switchcount == 0 && dir == "asc") {
                dir = "desc";
                switching = true;
            }
        }
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

    var roleContainers = document.getElementsByClassName("role__inner-container");

    for (var i = 0; i < roleContainers.length; i++) {
        new Sortable(roleContainers[i], {
            animation: 150,
            sort: false,
            /*removeOnSpill: true, // Enable plugin*/
            group: {
                //put: function(to) {
                //    return to.el.children && 'raidgroup',
                //},
                name: 'raider',
                pull: 'clone',
            }
            /*ghostClass: 'blue-background-class'*/
        });
    }

    var groupsInRaids = document.getElementsByClassName("raidgroup__slots");

    for (var i = 0; i < groupsInRaids.length; i++) {
        new Sortable(groupsInRaids[i], {
            animation: 150,
            //TODO: Allow swapping AND sorting
            //TODO: Fix drop threshold
            /*swap: true,*/
            removeOnSpill: true, // Enable plugin
            group: {
                /*put: ['raider', 'raidgroup'],*/
                name: 'raidgroup',
                put: function(to) {
                    return to.el.children.length + 1 <= 5 && ['raider', 'raidgroup']; //length starts at 0
                },
                /*pull: 'swap'*/
            }

            /*ghostClass: 'blue-background-class'*/
        });
    }

    jQuery('#raidGroupDateTimePicker').datetimepicker({
        /*inline: true,*/
        format: 'd/m/Y',
        minDate: 0, // today
        theme: 'dark',
        timepicker: false,
        dayOfWeekStart: 1,
    });
});

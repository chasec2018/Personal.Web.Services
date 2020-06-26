// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

function CopyToClipBoard(id) {

    const CopyText = document.getElementById(id).innerText;
    const NewElement = document.createElement('textarea');
    NewElement.value = CopyText;

    NewElement.setAttribute('readonly', '');
    NewElement.style.position = 'absolute';
    NewElement.style.left = '-9999px';

    document.body.appendChild(NewElement);
    NewElement.select();
    document.execCommand('copy');
    document.body.removeChild(NewElement);

    var prefix = "RTXT-";
    var prefixid = prefix.concat(id)

    var tooltip = document.getElementById(prefixid);
    tooltip.innerHTML = "Copied";

}

function ToolTipHover(id) {
    var tooltip = document.getElementById(RTXT - id);
    tooltip.innerHTML = "Copy to clipboard";
}

$(function () {
    $('[data-toggle="tooltip"]').tooltip()
})

$(function () {
    $('[data-toggle="popover"]').popover()
})

$(document).ready(function () {
    $('[data-toggle="image-popover"]').popover({
        container: 'body',
        html: true,
        content: function () {
            return '<img src="' + $(this).data('img') + '" width="500" height="333">';
        }
    })
});

function remove_input(InputId) {

    $('#'.concat(InputId, ':last-child')).remove();
}


function clone_input(input_id, clone_location, replace_list_count = false, traverse = false, list_indexer_start = 0) {

    var inputId = '#'.concat(input_id);
    var cloneLocation = '#'.concat(clone_location);

    $(inputId.concat(":last-child"))
        .clone()
        .appendTo(cloneLocation);

    // Increment List Objects
    if (replace_list_count == true) {
        var splits = $(inputId.concat(':last-child')).attr("name").split('.');
        var new_name = "";

        // Change Variable
        if (list_indexer_start > 0) {
            var change_index = list_indexer_start;
        } else {
            var change_index = splits.length - 1;
        }

        
        for (i = 0; i < splits.length; i++) {
            var bracket_one = splits[i].indexOf('[') + 1;
            var bracket_two = bracket_one + 1;

            if (i == change_index) {

                var a = Number.parseInt(splits[i].substring(bracket_one, bracket_two));
                var b = a + 1;

                new_name = new_name.concat(splits[i].replace(a.toString(), b.toString()));
            }
            else {
                new_name = new_name.concat(splits[i], ".");
            }
        }

        $(inputId.concat(':last-child')).attr("name", new_name);
    }

    if (traverse == true) {
        

        $(inputId.concat(':last-child')).find("input").attr("value", "");
        $(inputId.concat(':last-child')).find("input").val("");
        $(inputId.concat(':last-child')).find("textarea").text("");

    } else {
        $(inputId.concat(':last-child')).attr("value", "");
        $(inputId.concat(':last-child')).val("");
    }
}

function clone_inputs(input_ids = [""], clone_location = "", input_tags = [""]) {

    var location = '#'.concat(clone_location);

    for (i = 0; i < input_ids.length; i++) {

        var inputId = '#'.concat(input_ids[i]);

        if (input_tags.length > 0) {
            $(inputId)
                .clone(true,true)
                .appendTo(location);

            $(inputId)
                .val(get_idcount(input_ids[i]));
        }
        else {
            $(inputId.concat(":last-child"))
                .clone()
                .appendTo(location);
        }
    }
}

function remove_inputs(input_ids = [""], clone_location = "") {

}


function get_idcount(id = "", location_id = ""): number {

    var id = "#".concat(id);
    var location_id = "#".concat(location_id);

    $(id).each(function (index) {
        return index;
    });
}




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


$(document).ready(function () {
    var choicesLeft = $('#numberOfChoices').val();
    var rootImage = "/Images/hangman-";
    var imageIndex = 7 - choicesLeft;
    if (imageIndex != 0) {
        var image = rootImage + imageIndex + ".png";
        $("img").attr('src', image);
    }


});

var coord_seat_x_txt = $('.SelectSeat');
var coord_seat_y_txt = $('.SelectSeatColumn');
var lastSeat;
$(".imag").on('click', function () {

    if (lastSeat != null) {

        if (lastSeat.attr("src") == "/Content/images/seat1.gif") {
            lastSeat.attr("src", "/Content/images/seat2.gif")
        }
        else {
            lastSeat.attr("src", "/Content/images/seat1.gif")
        }

    }


});

$(".imag").on('click', function () {
    var row = coord_seat_x_txt.val($(this).attr("data_x"));
    var column = coord_seat_y_txt.val($(this).attr("data_y"));
    lastSeat = $(this);

    if ($(this).attr("src").toString().indexOf('seat1.gif') != -1) {


        this.src = this.src.replace("seat1.gif", "seat2.gif");

    }

    else {

        this.src = this.src.replace("seat2.gif", "seat1.gif");
        coord_seat_x_txt.val("");
        coord_seat_y_txt.val("");


    }

});

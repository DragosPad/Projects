
var coord_seat_x_txt = $('.SelectSeat');
var coord_seat_y_txt = $('.SelectSeatColumn');
var lastSeat;
$(".imag").on('click', function () {

    if (lastSeat != null) {

        if (lastSeat.attr("src") == "/Content/images/SeatAvailable.png") {
            lastSeat.attr("src", "/Content/images/SeatOccupied.png")
        }
        else {
            lastSeat.attr("src", "/Content/images/SeatAvailable.png")
        }

    }


});

$(".imag").on('click', function () {
    var row = coord_seat_x_txt.val($(this).attr("data_x"));
    var column = coord_seat_y_txt.val($(this).attr("data_y"));
    lastSeat = $(this);

    if ($(this).attr("src").toString().indexOf('SeatAvailable.png') != -1) {


        this.src = this.src.replace("SeatAvailable.png", "SeatOccupied.png");

    }

    else {

        this.src = this.src.replace("SeatOccupied.png", "SeatAvailable.png");
        coord_seat_x_txt.val("");
        coord_seat_y_txt.val("");


    }

});

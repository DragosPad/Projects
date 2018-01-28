
    $(document).ready(function () {
        $('#sendSubmit').attr('disabled', true);
        $('#message').keyup(function () {
            if ($(this).val().length != 0)
                $('#sendSubmit').attr('disabled', false);
            else
                $('#sendSubmit').attr('disabled', true);
        })
    });

  
        $(document).ready(function () {
            $('#sendSubmit').attr('disabled', true);
            $('#message1').change(function () {
                if ($(this).val().length != 0)
                    $('#sendSubmit').attr('disabled', false);
                else
                    $('#sendSubmit').attr('disabled', true);
            })
        });
   

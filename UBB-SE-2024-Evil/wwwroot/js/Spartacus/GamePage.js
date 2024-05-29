window.onload = () => {
    $('#moveForm').submit((e) => {
        e.preventDefault();

        // Get the values from the input fields
        var inputDamage;
        if ($('#inputDamage').val() == '') {
            inputDamage = 0;
        } else {
            inputDamage = parseInt($('#inputDamage').val());
        }
        var inputBlock;
        if ($('#inputBlock').val() == '') {
            inputBlock = 0;
        } else {
            inputBlock = parseInt($('#inputBlock').val());
        }

        //Send a PATCH request
        $.ajax({
            url: '/Game/DoMove?damage=' + inputDamage + '&block=' + inputBlock,
            type: 'PATCH',
            success: function (response) {
                // Detect whether the response is a partial view (the game is not over yet)
                if (response.includes('<!-- This is a partial view -->')) {
                    // Update the display
                    $('#playersContainer').html(response);

                    // Clear the inputs
                    $('#inputDamage').val('');
                    $('#inputBlock').val('');
                } else {
                    // The game is over
                    $('html').html(response);
                }
            },
            error: function (xhr, status, error) {
                // Handle error
            }
        });
    });
}
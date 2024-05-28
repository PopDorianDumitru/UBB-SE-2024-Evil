window.onload = () => {
    $('#submitButton').click(() => {
        // Get the values from the input fields
        var inputDamage = parseInt($('#inputDamage').val());
        var inputBlock = parseInt($('#inputBlock').val());


        // Send a PATCH request
        $.ajax({
            url: '/Game/DoMove?damage=' + inputDamage + '&block=' + inputBlock,
            type: 'PATCH',
            success: function (response) {
                // Handle success response
            },
            error: function (xhr, status, error) {
                // Handle error
            }
        });
    });
}
window.onload = () => {
    //console.log("Hello from GamePage.js");
    // $('#submitButton').click(())
    $('#moveForm').submit((e) => {
        e.preventDefault();
        // Get the values from the input fields
        var inputDamage = parseInt($('#inputDamage').val());
        var inputBlock = parseInt($('#inputBlock').val());
        //console.log("Hello");

         //Send a PATCH request
        $.ajax({
            url: '/Game/DoMove?damage=' + inputDamage + '&block=' + inputBlock,
            type: 'PATCH',
            success: function (response) {
                //$('#inputDamage').text = "";
                //$('#inputBlock').text = "";
            },
            error: function (xhr, status, error) {
                // Handle error
            }
        });
    });
}
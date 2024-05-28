window.onload = () => {
    var maxHealth = 200;

    //$('#player-health-bar').css('width', (@Model.Player.Health / maxHealth * 100) + '%');
    //$('#enemy-health-bar').css('width', (@Model.Enemy.Health / maxHealth * 100) + '%');

    console.log("ENTERED JS");

    $('#submitButton').click(() => {
        // Get the values from the input fields
        var inputDamage = parseInt($('#inputDamage').val());
        var inputBlock = parseInt($('#inputBlock').val());


        // // Send a PATCH request
        // '@Url.Action("DoMove", "Game")'
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
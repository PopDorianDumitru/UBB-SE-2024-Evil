window.onload = () => {
    // Add click event listener to the pay button
    $('#payButton').click(() => {
        // Clear any previous error messages
        clearErrors();

        // Gather input values
        const creditCardHolder = $('#personName').val().trim();
        const creditCardNumber = $('#cardNumber').val().trim();
        const expirationDate = $('#expiry').val().trim();
        const cvv = $('#cvv').val().trim();

        // Validate inputs
        let isValid = true;

        if (!creditCardHolder) {
            showError('personName', 'Name is required');
            isValid = false;
        }

        if (!creditCardNumber) {
            showError('cardNumber', 'Card number is required');
            isValid = false;
        }

        if (!expirationDate) {
            showError('expiry', 'Expiration date is required');
            isValid = false;
        }

        if (!cvv) {
            showError('cvv', 'CVV is required');
            isValid = false;
        }

        // If all inputs are valid, make the AJAX request
        if (isValid) {
            const data = {
                CreditCardHolder: creditCardHolder,
                CreditCardNumber: creditCardNumber,
                ExpirationDate: expirationDate,
                Cvv: cvv
            };

            const urlBase = window.location.origin;

            $.ajax({
                type: 'POST',
                url: `${urlBase}/api/CreditCards`,
                data: JSON.stringify(data),
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (response) {
                    alert('Payment processed successfully!');
                },
                error: function (error) {
                    console.error('Error processing payment:', error);
                    alert('Error processing payment. Please try again.');
                }
            });
        }
    });
};

function showError(fieldId, message) {
    const field = document.getElementById(fieldId);
    const errorDiv = document.createElement('div');
    errorDiv.className = 'text-danger';
    errorDiv.textContent = message;
    field.parentElement.appendChild(errorDiv);
}

function clearErrors() {
    const errors = document.querySelectorAll('.text-danger');
    errors.forEach(error => error.remove());
}

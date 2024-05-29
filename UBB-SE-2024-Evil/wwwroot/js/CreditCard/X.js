window.onload = () => {
    // Add click event listener to the pay button
    document.getElementById('payButton').addEventListener('click', () => {
        // Clear any previous error messages
        clearErrors();

        // Gather input values
        const creditCardHolder = document.getElementById('personName').value.trim();
        const creditCardNumber = document.getElementById('cardNumber').value.trim();
        const expirationDate = document.getElementById('expiry').value.trim();
        const cvv = document.getElementById('cvv').value.trim();

        // Validate inputs
        let isValid = true;

        if (!creditCardHolder) {
            showError('personName', 'Name is required');
            isValid = false;
        }

        if (!/^\d{16}$/.test(creditCardNumber)) {
            showError('cardNumber', 'Card number must be 16 digits');
            isValid = false;
        }

        if (!/^(0[1-9]|1[0-2])\/\d{4}$/.test(expirationDate)) {
            showError('expiry', 'Expiry must be in MM/YYYY format');
            isValid = false;
        }

        if (!/^\d{3,4}$/.test(cvv)) {
            showError('cvv', 'CVV must be 3 or 4 digits');
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

            $.ajax({
                type: 'POST',
                url: 'api/CreditCards', 
                data: JSON.stringify(data),
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (response) {
                    console.log('Payment processed successfully:', response);
                    alert('Payment processed successfully!');
                },
                error: function (error) {
                    console.error('Error processing payment:', error);
                    alert('Error processing payment. Please try again.');
                }
            });
        }
    });

    console.log('Page loaded');
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

// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function togglePasswordVisibility() {
    var passwordInput = document.getElementById("password");
    var eyeIcon = document.getElementById("eyeIcon");

    if (passwordInput.type === "password") {
        passwordInput.type = "text";
        eyeIcon.className = "bi bi-eye-slash";
    } else {
        passwordInput.type = "password";
        eyeIcon.className = "bi bi-eye";
    }

}
// Define a function to set default date values
function setDefaultDateValues() {
    // Get today's date
    var today = new Date();
    var dd = String(today.getDate()).padStart(2, '0');
    var mm = String(today.getMonth() + 1).padStart(2, '0'); // January is 0!
    var yyyy = today.getFullYear();

    today = yyyy + '-' + mm + '-' + dd;

    // Set today's date as the default value for the Written Date input
    document.getElementById('writtenDate').value = today;

    // Calculate one month from today
    var expirationDate = new Date(today);
    expirationDate.setMonth(expirationDate.getMonth() + 1);

    // Format expiration date
    var exp_dd = String(expirationDate.getDate()).padStart(2, '0');
    var exp_mm = String(expirationDate.getMonth() + 1).padStart(2, '0');
    var exp_yyyy = expirationDate.getFullYear();

    var expiration = exp_yyyy + '-' + exp_mm + '-' + exp_dd;

    // Set one month from today as the default value for the Expiration Date input
    document.getElementById('expirationDate').value = expiration;
}

function updateFullName() {
    var firstName = document.getElementById('FirstName').value;
    var lastName = document.getElementById('LastName').value;
    document.getElementById('FullName').value = firstName + ' ' + lastName;
}

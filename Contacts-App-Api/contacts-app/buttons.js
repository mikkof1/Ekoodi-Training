/**
 * Created by ekoodi on 20.3.2017.
 */
contactsApp.buttons = function () {

    function onClicked() {
        var contact = buildInputContact();

        if (modifyIndex > -1) {
            contactsApp.contactStore.editItem(contact);
        }
        else {
            contactsApp.contactStore.saveContact(contact);
        }

        modifyIndex = -1;
        document.getElementById("addButton").innerText = 'Add';
        emptyInputs();
    }

    function emptyInputs() {
        var inputs = document.getElementsByTagName("input");
        for (var i = 0; i < inputs.length; i++) {
            inputs[i].value = '';
        }
    }

    function buildInputContact() {
        var id = -1;
        if (modifyIndex > -1) {
            id = contactsList[modifyIndex].id;
        }

        var contact = contactsApp.contact(
            id,
            document.getElementById('firstName').value,
            document.getElementById('lastName').value,
            document.getElementById('phone').value,
            document.getElementById('address').value,
            document.getElementById('city').value
        );
        return contact;
    }

    function startEdit(editIndex) {

        document.getElementById("firstName").value = contactsList[editIndex].firstName;
        document.getElementById("lastName").value = contactsList[editIndex].lastName;
        document.getElementById("phone").value = contactsList[editIndex].phone;
        document.getElementById("address").value = contactsList[editIndex].address;
        document.getElementById("city").value = contactsList[editIndex].city;
        document.getElementById("addButton").innerText = 'Edit';
    }


    function onDelete(delIndex) {
        if (modifyIndex > -1) {
            alert('Hello, edit first');
            return;
        }
        var contact = contactsList[delIndex];
        contactsApp.contactStore.removeItem(contact);
    }

    return {
        onClicked: function () {
            onClicked();
        },
        startEdit: function (editIndex) {
            modifyIndex = editIndex;
            startEdit(editIndex);
        },
        onDelete: function (delIndex) {
            onDelete(delIndex);
        }
    }

}
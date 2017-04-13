/**
 * Created by ekoodi on 20.3.2017.
 */

contactsApp.contactStore = (function () {
      var apiUrl = "http://localhost:51343/api/contacts/";
   // var apiUrl = "http://localhost:49478/api/contacts/";
    var mediaType = "application/json; charset=utf-8;";

    function loadLocalStorage() {
        console.log("load storage");
        $.getJSON(apiUrl).done(function (data) {
            contactsList = data;
            contactsApp.contactsTable.fillTable();
        });
    }

    function addToApiStorage(contact) {
        console.log("add new contact");
        $.ajax({
            url: apiUrl,
            type: "POST",
            data: JSON.stringify(contact),
            contentType: mediaType
        }).done(function (data) {
            loadLocalStorage();
        });
    }

    function removeItemFromList(contact) {
        console.log("delete contact");
        $.ajax({
            url: apiUrl,
            type: "DELETE",
            data: JSON.stringify(contact),
            contentType: mediaType
        }).done(function (data) {
            loadLocalStorage();
        });
    }

    function editItemInList(contact) {
        console.log("edit contact");
        $.ajax({
            url: apiUrl,
            type: "PUT",
            data: JSON.stringify(contact),
            contentType: mediaType
        }).done(function (data) {
            loadLocalStorage();
        });
    }

    return {
        saveContact: function (contact) {
            addToApiStorage(contact);
        },
        loadContacts: function () {
            return loadLocalStorage();
        },
        removeItem: function (contact) {
            removeItemFromList(contact);
        },
        editItem: function (contact) {
            editItemInList(contact);
        }
    }
})();
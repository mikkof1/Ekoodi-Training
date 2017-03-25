/**
 * Created by ekoodi on 20.3.2017.
 */

contactsApp.contactStore = (function () {
	var apiUrl="http://localhost:51343/api/contacts/";

    function loadLocalStorage() {
		console.log("load storage");
		$.getJSON(apiUrl).done(function(data){
			contactsList=data;
			contactsApp.contactsTable.fillTable();
		});
    }

    function saveContactsToLocalStorage(contact) {
		console.log("save new contact");
		$.ajax({
			url: apiUrl,
			type: "PUT",
			data: contact}).done(function(data){
				loadLocalStorage();
		});
    }

    function removeItemFromList(contact) {
		console.log("delete contact");
		$.ajax({
			url: apiUrl,
			type: "DELETE",
			data: contact}).done(function(data){
				loadLocalStorage();
		});
    }

    function editItemInList(contact) {
		console.log("edit contact");
		$.post(apiUrl, contact).done(function(data){
			loadLocalStorage();
		});
    }

    return {
        saveContact: function (contact) {
            saveContactsToLocalStorage(contact);
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
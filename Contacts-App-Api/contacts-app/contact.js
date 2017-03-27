/**
 * Created by ekoodi on 20.3.2017.
 */
contactsApp.contact = function (id, firstName, lastName, phone, address, city) {
    return {
		id: id,
        firstName: firstName,
        lastName: lastName,
        phone: phone,
        address: address,
        city: city
    }
}


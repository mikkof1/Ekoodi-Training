/**
 * Created by ekoodi on 16.3.2017.
 */
var users = [];
function onClicked() {
    var newUser = createUser();
    users.push(newUser)
    console.log(newUser);
    console.log('users count: '+users.length);
    fillTable();
}

function createUser() {
    return {
        firstName: document.getElementById('firstName').value,
        lastName: document.getElementById('lastName').value,
        phone: document.getElementById('phone').value,
        street: document.getElementById('street').value,
        city: document.getElementById('city').value
    };
}


function fillTable() {
    var table = document.getElementById("resultsTable");
    table.innerHTML="<thead><tr><th>First name</th><th>Last name</th><th>Phone</th><th>Address</th></tr></thead>";
    for (var i = 0; i < users.length; i++) {

        var row = table.insertRow(table.rows.length);
        var fName = row.insertCell(0);
        var lName = row.insertCell(1);
        var pho = row.insertCell(2);
        var adress = row.insertCell(3);

        fName.innerText = users[i].firstName;
        lName.innerText = users[i].lastName;
        pho.innerText = users[i].phone;
        adress.innerText = users[i].street + ' , ' + users[i].city;

        if(i%2==0) {row.className="evenRow";}
        else {row.className="oddRow";}
    }

}
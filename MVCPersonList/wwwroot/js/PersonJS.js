var allBtnElement = document.getElementById("allBtn");
var inputBtnElement = document.getElementById("inputBtn");
var textInputElement = document.getElementById("textInput");
var resultDivElement = document.getElementById("resultDiv");

allBtnElement.addEventListener("click", ajaxGetAllPersons);         // Listen to a click of allBtn and execute ajaxGetAllPersons()
inputBtnElement.addEventListener("click", ajaxPostDetailsPerson);   // Listen to a click of inputBtn and execute ajaxPostDetailsPerson()


function ajaxGetAllPersons() {

    $.get("Ajax/AllPersonsPartialView", function (data, status) {
        console.log("Data: " + data + "\nStatus: " + status);
        resultDivElement.innerHTML = data;                          // Prerendered html
    });
}


function ajaxPostDetailsPerson() {

                                                                    // Add if textInputElement.value is null - empty or not      

    $.post("Ajax/DetailsPartialView",                               // Go to this url       
        {
            id: textInputElement.value                              // Post the id that is saved in this element
        }
        , function (data, status) {                                 // When the data is back
        console.log("Data: " + data + "\nStatus: " + status);
        resultDivElement.innerHTML = data;                          // Put it inside the result element
    });
}

function deletePerson(element, event) {
    //console.log(event);
    //console.log(element);
    event.preventDefault();

    var deleteUrl = event.target.href;

    $.get(deleteUrl,
        function (data, status) {
            alert("Data: " + data + "\nStatus: " + status);
            $("#" + data).remove();
        }
    ).fail(function (jqXHR, textStatus, errorThrown) {
        console.log("jqXHR", jqXHR);
        console.log("textStatus", textStatus);
        console.log("errorThrown", errorThrown);
        if (jqXHR.status == 404) {
            alert("Person not found.\nwas not able to delete.")
        }
        else {
            alert("Status: " + jqXHR.status);
        }
    });
}
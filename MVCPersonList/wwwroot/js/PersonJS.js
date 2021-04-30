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
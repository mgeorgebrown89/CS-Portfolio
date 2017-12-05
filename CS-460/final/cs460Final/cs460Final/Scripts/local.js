var ajax_call = function(id) {

    $.ajax({
        type: "GET",
        dataType: "json",
        url: "Items/Bids/" + id,
        success: displayResults,
        error: errorOnAjax
    });
};


var interval = 1000 * 5; // where X is your timer interval in X seconds

window.setInterval(ajax_call, interval);

function displayResults(data) {
    console.log("Success!");
    console.log(data);

    $('#results').empty();

    var item = document.getElementById("results");

    data.arr.forEach(function (item) {
        $('#results').append(item);
    });

}

function errorOnAjax() {
    console.log("Error");
}
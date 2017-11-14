//console.log("In numbers.js")

$("#Request").click(function () {
    var a = $("#Count").val();
    console.log(a);
    var source = "/Home/RandomNumbers/" + a;
    console.log(source);

    // Send an async request to our server, requesting JSON back
    $.ajax({
        type: "GET",
        dataType: "json",
        url: source,
        success: displayData,
        error: errorOnAjax
    });
});

function displayData(data) {
    console.log(data);
    $("#Message").text(data["message"]);
    $("#Amount").text("Number of values requested " + data.num);
    $("#Values").text(data.numbers);
    var sum = data.numbers.reduce(function (a, b) { return a + b; });
    var ave = sum / data.numbers.length;
    $("#Average").text("Average of these values is " + ave);
}

function errorOnAjax() {
    console.log("error");
}
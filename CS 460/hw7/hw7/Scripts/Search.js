var page = 1;

$("#SearchText").keypress(function (event) {
    //enter (13)
    if (event.keyCode == 13) {
        search();
        event.preventDefault();
    }
});

$("#SearchButton").click(search); //new search

function search() {
    var q = $("#SearchText").val();
    var limit = $("#limit").val();

    var source = "gif/searcher/" + page + "?q=" + q + "&limit=" + limit;
    console.log(source);

    $.ajax({
        type: "GET",
        dataType: "json",
        url: source,
        success: displayGifs,
        error: errorOnAjax
    });
}



function displayGifs(response) {
    //delete old gifs
    $('#results').empty();

    console.log(response);
    for (var i = 0; i < response.data.length; i++) {
        var currentStillURL = response.data[i].images.fixed_height_still.url; // still image 
        var currentMovingURL = response.data[i].images.fixed_height.url; // moving image

        // Create a Div to house Gif
        var currentGifDiv = $('<div>');
        currentGifDiv.addClass('gif_container'); // Add class
        currentGifDiv.attr('data-name', "unclicked"); // Add Data Attributed for clicked

        // Append Moving Gif Image
        var currentGif = $('<img>')
        currentGif.addClass('moving_gif'); // Added a class for animated gif
        currentGif.attr("src", currentMovingURL);
       // currentGif.hide(); // Hide the moving gif
        currentGifDiv.append(currentGif);

        // Append current Div to the DOM
        $('#results').append(currentGifDiv);
    }
}

function errorOnAjax() {
    console.log("error");
}

$('#SearchRequest').click(function () {

    var APIKeyMethod = "Home/APIKey";
    console.log(APIKeyMethod);

    $.ajax({
        type: "GET",
        dataType: "json",
        url: APIKeyMethod,
        success: getAPIKey
    });
});

function getAPIKey(keyData) {
    var searchQuery = $('#Search').val().trim().toLowerCase();
    var APIKey = keyData["key"];
    console.log(APIKey);

    var queryURL = "http://api.giphy.com/v1/gifs/search?q=" + searchQuery + "&api_key=" + APIKey + "&limit=5";
    console.log(queryURL);
    var xhr = $.get(queryURL);
    //xhr.done(function (data) { console.log("success got data", data); });

    $.ajax({
        type: "GET",
        dataType: "json",
        url: queryURL,
        success: displayGif,
        failure: errorOnAjax
    });
}




function displayGif(response) {
    //delete old gifs
    $('#GifSearchResult').empty();

    console.log(response);
    for (var i = 0; i < response.data.length; i++) {
        var currentStillURL = response.data[i].images.fixed_height_still.url; // still image 
        var currentMovingURL = response.data[i].images.fixed_height.url; // moving image
        // Collect the animal gif Ratings
        var currentRating = response.data[i].rating;

        // Correct for empty rating
        if (currentRating == "") {
            currentRating = "none";
        }

        // Create a Div to house Gif and Rating
        var currentGifDiv = $('<div>');
        currentGifDiv.addClass('gif_container'); // Added a class
        currentGifDiv.attr('data-name', "unclicked"); // Added a Data Attributed for clicked

        // Append Rating to current gif
        var currentGifRating = $('<h1>');
        currentGifRating.text("Rating: " + currentRating);
        currentGifDiv.append(currentGifRating);

        // Append Moving Gif Image
        var currentGif = $('<img>')
        currentGif.addClass('moving_gif'); // Added a class for animated gif
        currentGif.attr("src", currentMovingURL);
       // currentGif.hide(); // Hide the moving gif
        currentGifDiv.append(currentGif);

        // Append current Div to the DOM
        $('#GifSearchResult').append(currentGifDiv);
    }
}

function errorOnAjax() {
    console.log("error");
}


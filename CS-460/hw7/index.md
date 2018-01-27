---
Title: CS 460 - Homework 7.
Layout: default
---
# [Portfolio Home](https://mgeorgebrown89.github.io/CS-Portfolio) - [CS 460](https://mgeorgebrown89.github.io/CS-Portfolio/CS-460) - Homework 7
## MVC APP #4 | Giphy API | JSON
### [Official Requirements](http://www.wou.edu/~morses/classes/cs46x/assignments/HW7.html) 

### Step 1: Simple, Single-Page Web App

For this step, I just created the basic skeleton for the landing/home page for my Gif searching application. For this homework assignment, we are required to only have one page and use AJAX to only reload a portion of the site. Here is a screenshot of the homepage:

![homepage](https://mgeorgebrown89.github.io/CS-Portfolio/CS-460/hw7/homepage.PNG)

### Step 2: Register as Developer with Giphy

The next step is pretty self explanatory. Once I registered, I recieved an API key. We then had to keep it out of our repo but still use it, which required us to use a .config file that was externel to our repo and change our Web.config file accordingly so that it would get it. Here is the corresponding code:

```cs
  <appSettings file="..\..\..\..\AppSettingsSecrets.config">
```
and in my actual AppSettingsSecrets.config file:
```cs
<appSettings>
  <add key="GiphyAPIKey" value="myGiphyDeveloperAPIKey" />
</appSettings>
```

### Step 3: Gif Search with AJAX and JSON

Here I made my first big mistake. I successfully made an application that allowed the user to search gifs and display them, but I did most of it in JavaScript, meaning that my API key was visible to the user, should they look for it. I basically used an AJAX call to get my API Key from a JsonResult method, then assembled the query with it, and used another AJAX call in my JavaScript. I had to redo this part of the assignment so that I used AJAX to pass the search terms, and then use my action controller method to assemble the GET request, keeping my API Key secret. Here is the relevent code:

```cs 
 public JsonResult Search(int? page=1)
        {
            string GiphyAPIKey = System.Web.Configuration.WebConfigurationManager.AppSettings["GiphyAPIKey"];//get api key from outside repo
            string q = Request.QueryString["q"];//user's search
            string limit = Request.QueryString["limit"];//how many gifs to display

            //Giphy API
            string url = "https://api.giphy.com/v1/gifs/search?api_key=" + GiphyAPIKey + "&q=" + q + "&limit=" + limit + "&rating=g";

            ...

            WebRequest request = WebRequest.Create(url); //send request

            WebResponse response = request.GetResponse(); //get response
            Stream dataStream = response.GetResponseStream(); //start data stream
            string reader = new StreamReader(dataStream).ReadToEnd(); //read as a string

            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer(); 
            var data = serializer.DeserializeObject(reader); //parse string into JSON object
            
            dataStream.Close();
            response.Close();

            return Json(data, JsonRequestBehavior.AllowGet);
        }
```

The section cut out from the middle of my Search() method is related to the database, which I will get to later. You probably want to see the related JavaScript as well:

```js
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
```
Above, you can see that it assemble the query to pass to my JsonResult action, and it also uses a custom route, which is displayed here:

```cs
   routes.MapRoute(
               name: "Search",
               url: "gif/searcher/{page}",
               defaults: new { controller = "Giphy", action = "Search", page = UrlParameter.Optional }
           );
```
I had tried to make it paginate the results from the search, but I couldn't get it to work, and then my computer literally died, and its the week before Finals, so I'm getting the requirements done as is. :/

Upon success in the AJAX call, it calls the displayGifs function in the Search.js file:

```js
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
```

I had originally tried to display the still image first, and then when the user clicked on it, it would change to the animated gif, but I couldn't get this to work in the time alloted either, so there may be some residual code or comments refering to those still image attempts, but this functions to display the gifs. Here is a screen shot of a search for some cat gifs:

![Before](https://mgeorgebrown89.github.io/CS-Portfolio/CS-460/hw7/gifsearchbefore.PNG)

![After](https://mgeorgebrown89.github.io/CS-Portfolio/CS-460/hw7/gifsearchafter.PNG)
(Obviously, these images are stills, because its a screenshot.)

### Step 4: Static Content and CSS

The biggest thing I did for this step was to change the layout page. I downloaded a bootstrap template and replaced the reference to bootstrap.css in the bundleConfig.cs file. This made the homepage darker and in my opinion sleeker. You can also see above in the displayGif function how the search results get displayed and styled. 

### Step 5: Additional Search Features

Here I added a number HTML element to allow the user to decide how many gifs to display. Probably not super practical, but I wanted to paginate originally, but could not succeed, so I thought this would suffice for now. I also added a select element to allow the user to display gifs by rating, y-pg13 only. Here is the code for that stuff:

```html
<div class="col-lg-6">
    <form>
        <div class="form-group">
            @*Text input for gif searching.*@
            <h2><label for="SearchText" class="label label-primary">Search gifs.</label></h2>
            <input id="SearchText" name="SearchText" type="text" value="cats" class="form-control" />
        </div>
        <label for="limit" class="label label-primary">How many?</label>
        <input id="limit" name="limit" type="number" min="1" max="20" step="1" value="1" />
        @*Buttom to submit search request.*@
        <input id="SearchButton" name="SearchButton" type="button" value="Search" class="btn btn-lg btn-primary" />
    </form>
    <div class="col-lg-6">
        <div id="results"></div>
    </div>
</div>
```

#### Step 6: Database Log

And thus begins the nightmare, although it had nothing to do with this homework, I just want to complain. I got a corrupt branch, and in my attempts to fix it, I ended up just cloning my repo and trying to restart, but the Visual studio stated going crazy--All kinds of timeouts and Not Responding dialogues. I searched online for a fix, but nothing. So I decided to reinstall VS. I installed the correct plugins, but then local db wasn't working either, even on previous homeowrk assignments. So, I thought maybe if I restart my computer? 

Then it entered recovery mode, saying there were disk errors. 

Then it said it couldn't fix the computer, so I would have to restore the OS.

I guess my 10 year old Toshiba, 17in, 10lb laptop just wouldn't cut it anymore.  

So I got a new laptop, reinstalled everything, cloned my repo, and after about 5 hours, I'm back in business. 

Then I added my database logging functionality. Here is my up.sql script:

```sql
-- SearchRequests table
CREATE TABLE hw7.SearchRequests
(
	ID				INT Identity (1,1) NOT NULL,
	Request			NVARCHAR(256)  NOT NULL,
	Timestamp		DateTime NOT NULL,
	IPAddress		NVARCHAR(128) NOT NULL,
	BrowserClient	NVARCHAR(128) NOT NULL,
	
	CONSTRAINT [PK_hw7.SearchRequests] PRIMARY KEY CLUSTERED (ID ASC)
);
```
and my down.sql:

```sql
IF EXISTS
(
    SELECT *
    FROM sys.tables
)
BEGIN
    DROP TABLE dbo.SearchRequests;
END
```

And in my controller, then code that takes the query and puts it as a new entry into the database:

```cs
public JsonResult Search(int? page=1)
        {
            string GiphyAPIKey = System.Web.Configuration.WebConfigurationManager.AppSettings["GiphyAPIKey"];//get api key from outside repo
            string q = Request.QueryString["q"];//user's search
            string limit = Request.QueryString["limit"];//how many gifs to display

            //Giphy API
            string url = "https://api.giphy.com/v1/gifs/search?api_key=" + GiphyAPIKey + "&q=" + q + "&limit=" + limit + "&rating=g";

            //logging requests
            DateTime timestamp = DateTime.Now; 
            string IPAddress = Request.UserHostAddress; 
            string browserClient = Request.UserAgent;

            var entry = db.SearchRequests.Create();

            entry.Request = q;
            entry.IPAddress = IPAddress;
            entry.Timestamp = timestamp;
            entry.BrowserClient = browserClient;
            
            db.SearchRequests.Add(entry);
            db.SaveChanges();
```

This is, of course, after using Entity framework to make a SearchRequest class:

```cs
    public partial class SearchRequest
    {
        public int ID { get; set; }

        [Required]
        [StringLength(256)]
        public string Request { get; set; }

        public DateTime Timestamp { get; set; }

        [Required]
        [StringLength(128)]
        public string IPAddress { get; set; }

        [Required]
        [StringLength(128)]
        public string BrowserClient { get; set; }
    }
}
```

and a SearchRequestContext class:

```cs
namespace hw7.Models
{
    public class SearchRequestContext : DbContext
    {
        public SearchRequestContext() : base("name=SearchRequest")
        { }

        public virtual DbSet<SearchRequest> SearchRequests { get; set; }
    }
}
```

#### Demo

<a href="http://www.youtube.com/watch?feature=player_embedded&v=yLifmMgI_Cc" target="_blank"><img src="http://img.youtube.com/vi/yLifmMgI_Cc/0.jpg" 
alt="Homework 7 Demo" width="240" height="180" border="10" /></a>

### Step 7: Portfolio
Got it. 
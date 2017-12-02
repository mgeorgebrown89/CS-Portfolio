---
Title: CS 460 - Homework 8.
Layout: default
---
## [Portfolio Home](https://mgeorgebrown89.github.io/CS-Portfolio) - [CS 460](https://mgeorgebrown89.github.io/CS-Portfolio/CS-460) - Homework 8
##### [Requirements](http://www.wou.edu/~morses/classes/cs46x/assignments/HW8.html) 

#### Step 1: New MVC App. New Feature Branch.

This step required us to start with a new MVC application. This assignment is based on last year's final, so some of the steps might not make sense outside of that context. We are told that we can use all tools at our disposal, short of search the internet, so using scaffolded code is exceptable. 

#### Step 2: Domain Model

We were given a data set to work with a create a domain model and ER Diagram from. Here is my ER diagram:

![ER Diagram](https://mgeorgebrown89.github.io/CS-Portfolio/CS-460/hw8/hw8-ERDiagram.pnd)

#### Step 3: Seed Data into Tables

Then we had to make a script to make appropriate tables based on our ER diagram, and seed them with the examples from [this page](http://www.wou.edu/~morses/classes/cs46x/assignments/HW8_tables.html). Here is my up.sql script. This is the first half, which is the table creation:

```sql
-- Artists table
CREATE TABLE dbo.Artists
(
	ArtistID		INT Identity (1,1) NOT NULL,
	Name			NVARCHAR(64)  NOT NULL,
	BirthDate		NVARCHAR(64) NOT NULL,
	BirthCity		NVARCHAR(64) NOT NULL,
	
	CONSTRAINT [PK_dbo.Artists] PRIMARY KEY CLUSTERED (ArtistID ASC)
);

-- Artworks table
CREATE TABLE dbo.Artworks
(
	ArtworkID		INT Identity (1,1) NOT NULL,
	Title			NVARCHAR(64) NOT NULL,
	ArtistID		INT NOT NULL,
	CONSTRAINT[PK_dbo.Artworks] PRIMARY KEY CLUSTERED (ArtworkID ASC),
	CONSTRAINT[FK_dbo.Artworks_Artists] FOREIGN KEY (ArtistID)
		REFERENCES dbo.Artists(ArtistID)
		ON DELETE CASCADE
		ON UPDATE CASCADE
);

-- Genres table
CREATE TABLE dbo.Genres
(
	GenreID			INT Identity (1,1) NOT NULL,
	Name			NVARCHAR(64) NOT NULL,
	CONSTRAINT[PK_dbo.Genres] PRIMARY KEY CLUSTERED (GenreID ASC)
);

-- Classifications table
CREATE TABLE dbo.Classifications
(
	ClassificationID	INT Identity(1,1) NOT NULL,
	ArtworkID			INT NOT NULL,
	GenreID				INT NOT NULL,
	CONSTRAINT[PK_dbo.Classifications] PRIMARY KEY CLUSTERED (ClassificationID ASC),
	CONSTRAINT[FK_dbo.Artworks_Classifications] FOREIGN KEY (ArtworkID)
		REFERENCES dbo.Artworks (ArtworkID)
		ON DELETE CASCADE
		ON UPDATE CASCADE,
	CONSTRAINT[FK_dbo.Genres_Classifications] FOREIGN KEY (GenreID)
		References dbo.Genres (GenreID)
		ON DELETE CASCADE
		ON UPDATE CASCADE
);
```

And this second half is the entry insertion:

```sql
-- Insertions
INSERT INTO dbo.Artists(Name,BirthDate,BirthCity) VALUES 
	('M C Escher','June 17, 1898', 'Leeuwarden, Netherlands'),
	('Leonardo Da Vinci','May 2, 1519','Vinci, Italy'),
	('Hatip Mehmed Efendi','November 11, 1680','Unknown'),
	('Salvador Dali','May 11, 1904','Figueres,Spain');

INSERT INTO dbo.Artworks (Title, ArtistID) VALUES
('Circle Limit III','1'),
('Twon Tree','1'),
('Mono Lisa','2'),
('The Vitruvian Man','2'),
('Ebru','3'),
('Honey Is Sweeter Than Blood','4');

INSERT INTO dbo.Genres(Name) VALUES
('Tesselation'),
('Surrealism'),
('Portrait'),
('Renaissance');

INSERT INTO dbo.Classifications(ArtworkID, GenreID) VALUES
('1','1'),
('2','1'),
('2','2'),
('3','3'),
('3','4'),
('4','4'),
('5','4'),
('6','2');

GO
```

I decided to make seperate Primary Key columns, because I thought it would be simpler, but in reality I think it just made my LINQ expressions that much more difficult to figure out. 

#### Step 4: Menu Items

Then we needed to add menu buttons to the shared layout to display three views: Artists, Artworks, and Classifications. Each view should display a list. I used scaffolded code to generate an ArtistController and some views. Here are the buttons in my share layout:

```cs 
    <div class="navbar navbar-inverse navbar-fixed-top">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                @Html.ActionLink("Homework 8", "Index", "Home", new { area = "" }, new { @class = "navbar-brand" })
            </div>
            <div class="navbar-collapse collapse">
                <ul class="nav navbar-nav">
                    <li>@Html.ActionLink("Home", "Index", "Home")</li>
                    <li>@Html.ActionLink("Artists","Index","Artists")</li>
                    <li>@Html.ActionLink("Artworks","Artworks","Artists")</li>
                    <li>@Html.ActionLink("Classifications","Classifications","Artists")</li>
                </ul>
            </div>
        </div>
    </div>
```

And here is the view of artists:

```cs 
@model IEnumerable<hw8.Models.Artist>

@{
    ViewBag.Title = "Index";
}

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(model => model.Name)
        </th>
        <th>
            @Html.DisplayNameFor(model => model.BirthDate)
        </th>
        <th>
            @Html.DisplayNameFor(model => model.BirthCity)
        </th>
        <th></th>
    </tr>

@foreach (var item in Model) {
    <tr>
        <td>
            @Html.DisplayFor(modelItem => item.Name)
        </td>
        <td>
            @Html.DisplayFor(modelItem => item.BirthDate)
        </td>
        <td>
            @Html.DisplayFor(modelItem => item.BirthCity)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", new { id=item.ArtistID }) |
            @Html.ActionLink("Details", "Details", new { id=item.ArtistID }) |
            @Html.ActionLink("Delete", "Delete", new { id=item.ArtistID })
        </td>
    </tr>
}

</table>

```

#### Step 5: Commit to local Repo

This step is pretty self-explanatory and I'm assuming its for the sake of the final. 

#### Step 6: CRUD

Here we needed to implement CRUD functionality for Artists. I used the scaffolded views to create the create, details, edit, and delete views. 

Here are the controller methods:

```cs
  // GET: Artists/Details/5
        public ActionResult Details(int id)
        {
            var artist = db.Artists.Find(id);
            return View(artist);
        }

        // GET: Artists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Artists/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {

                var newArtist = db.Artists.Create();

                newArtist.Name = collection["Name"];
                newArtist.BirthCity = collection["BirthCity"];
                newArtist.BirthDate = collection["BirthDate"];

                db.Artists.Add(newArtist);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Artists/Edit/5
        public ActionResult Edit(int id)
        {
            var artist = db.Artists.Find(id);
            return View(artist);
        }

        // POST: Artists/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var editArtist = db.Artists.Find(id);

                editArtist.Name = collection["Name"];
                editArtist.BirthCity = collection["BirthCity"];
                editArtist.BirthDate = collection["BirthDate"];
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Artists/Delete/5
        public ActionResult Delete(int id)
        {
            var artists = db.Artists.Where(a => a.ArtistID == id).FirstOrDefault();
            return View(artists);
        }

        // POST: Artists/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var artist = db.Artists.Find(id);
                db.Artists.Remove(artist);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
```

#### Step 7: Attribute Checking 

I forgot about this part until I started typing this up! Here is the code in my ArtistsController:

```cs
 // POST: Artists/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var editArtist = db.Artists.Find(id);

                editArtist.Name = collection["Name"];
                editArtist.BirthCity = collection["BirthCity"];
                editArtist.BirthDate = collection["BirthDate"];

                if (collection["Name"].Length > 50) //attribute checking for Name length
                {
                    TempData["testmsg"] = "<script>alert('Name cannot be more than 50 characters!');</script>";
                    return RedirectToAction("Edit");
                }

                //attribute checking for date of birth
                string[] dob = editArtist.BirthDate.Split('/');

                int birthYear = Int32.Parse(dob[2]);
                int birthMonth = Int32.Parse(dob[0]);
                int birthDay = Int32.Parse(dob[1]);

                int yyyy = DateTime.Now.Year;
                int mm = DateTime.Now.Month;// jan is month 0
                int dd = DateTime.Now.Day;

                if (birthYear > yyyy)
                {
                    TempData["testmsg"] = "<script>alert('Are you from the future?');</script>";
                    return View();
                }
                else if (birthYear == yyyy && birthMonth > mm)
                {
                    TempData["testmsg"] = "<script>alert('Are you from the future?');</script>";
                    return View();
                }
                else if (birthYear == yyyy && birthMonth == mm && birthDay > dd)
                {
                    TempData["testmsg"] = "<script>alert('Wait a minute, you're not born yet.');</script>";
                    return View();
                }

                db.SaveChanges();

                return RedirectToAction("Index");
            }



            catch
            {
                return View();
            }
        }
```

#### Step 8: Genre Buttons

More AJAX. Ugh, although actually what gave me the most trouble was the LINQ queries. Here is the foreach loop for generating the buttons:

```cs
 <div class="col-md-6">
        <div class="btn-group">
           @foreach (var item in Model.ToList())
           {
            <button class="btn btn-primary" onclick="Ajax('@item.GenreID');">@item.Name</button>
           }
        </div>
    </div>
```
And here is the ajax call in javascript:

```js
function Ajax(id) {
    var source = "/Home/Genre/" + id;
    console.log(source);
    $.ajax({
        type: "GET",
        dataType: "json",
        data: { id: id },
        url: source,
        success: displayResults,
        error: errorOnAjax
    });
}
```

And here is the JSON in the controller:

```cs
 public ActionResult Index()
        {
            var genres = db.Genres.ToList();
            return View(genres);
        }

        public JsonResult Genre(int id)
        {
            var works = db.Genres.Find(id)
                                 .Classifications
                                 .ToList()
                                 .OrderBy(t => t.Artwork.Title)
                                 .Select(a => new { aw = a.ArtworkID, awa = a.Artwork.ArtistID })
                                 .ToList();

            string[] artworkCreator = new string[works.Count()];
            for (int i = 0; i < artworkCreator.Length; ++i)
            {
                artworkCreator[i] = $"<ul>{db.Artworks.Find(works[i].aw).Title} by {db.Artists.Find(works[i].awa).Name}</ul>";
            }
            var data = new
            {
                arr = artworkCreator
            };
            
            return Json(data, JsonRequestBehavior.AllowGet);
        }
```

##### Demo

<a href="http://www.youtube.com/watch?feature=player_embedded&v=A9c7KJ_OIcE" target="_blank"><img src="http://img.youtube.com/vi/A9c7KJ_OIcE/0.jpg" 
alt="Homework 7 Demo" width="240" height="180" border="10" /></a>

#### Step 9: Portfolio
Check.
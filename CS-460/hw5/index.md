---
Title: CS 460 - Homework 5.
Layout: default
---
## [Portfolio Home](https://mgeorgebrown89.github.io/CS-Portfolio) - [CS 460](https://mgeorgebrown89.github.io/CS-Portfolio/CS-460) - Homework 5

#### Step 1: Create an Empty MVC project.
This is the same as Homework 4. We couldn't use any pre-built code. I won't include a screenshot of it this time, since it's the same as the previous assignment. 

#### Step 2: DMV Form
For this step, there wasn't really anything to do, but we looked at an Oregon DMV Address Change Request form.

#### Step 3: DMV Form
For this step we examined the form and decided how we were going to break apart the form into the separate fields. I went with:

ID, ODL, Full Legal Name, Street Address, City, State, Zip, Country (which I realize now should have been *county*, not country.)

#### Step 4: Data Model
This is where we created our first (local) database. I ran into a lot, I mean **A LOT** of problems with this, but I'm pleased to say I got it all done and working correctly. Here are my up.sql and down.sql files:

```sql

-- DMVdb table
CREATE TABLE dbo.DMVForms
(
	ID				INT Identity (1,1) NOT NULL,
	ODL				INT  NOT NULL,
	DOB				DateTime NOT NULL,
	Name			NVARCHAR(128) NOT NULL,
	StreetAddress	NVARCHAR(128) NOT NULL,
	City			NVARCHAR(64) NOT NULL,
	State			NVARCHAR(16) NOT NULL,
	Zip				INT	NOT NULL,
	Country			NVARCHAR(128) NOT NULL

	CONSTRAINT [PK_dbo.DMVForms] PRIMARY KEY CLUSTERED (ID ASC)
);

INSERT INTO dbo.DMVForms(ODL,DOB,Name,StreetAddress,City,State,Zip,Country) VALUES 
	('1234567','1989-09-22 00:00:00', 'Michael Brown','12345 Meadow Ln','Monmouth','Oregon','97361','USA'),
	('8910111','1990-07-27 00:00:00', 'Korenet Brown','12345 Meadow Ln','Monmouth','Oregon','97361','USA'),
	('2131415','2014-06-28 00:00:00', 'Nora Brown','12345 Meadow Ln','Monmouth','Oregon','97361','USA'),
	('1617181','2015-08-14 00:00:00', 'Jane Brown','12345 Meadow Ln','Monmouth','Oregon','97361','USA'),
	('9202122','2007-03-21 00:00:00', 'Margot Brown','12345 Meadow Ln','Monmouth','Oregon','97361','USA');


GO
```

```sql
IF EXISTS
(
    SELECT *
    FROM sys.tables
)
BEGIN
    DROP TABLE dbo.DMVForms
END
```

I also ran a testQuery.sql file `SQL SELECT * FROM DMVForms;` to make sure the entries were correctly inserted into the table. Below is a screenshot.

![Test Query](https://mgeorgebrown89.github.io/CS-Portfolio/CS-460/hw5/testQuery.PNG)

#### Step 5: Model Class and Database Context Class
Now I created the model class and the context class in the DAL folder. Here is my model class code:

```cs

namespace hw5b.Models
{
    public class DMVForm
    {
        [Required]
        public int ID { get; set; }

        public int ODL { get; set; }

        public DateTime DOB { get; set; }

        [Required, StringLength(64)]
        [Display(Name = "Full Legal Name")]
        public string Name { get; set; }

        public string StreetAddress { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public int Zip { get; set; }

        public string Country { get; set; }
    }
}

```

Here is the context class: 

```cs 

namespace hw5b.DAL
{
    public class DMVFormContext : DbContext
    {
        public DMVFormContext() : base("name=OurDBContext")
        { }

        public virtual DbSet<DMVForm> DMVForms { get; set; }
    }
}

```

#### Step 6: Connection String
This was pretty easy. I just used a local database so my connection string looks like this:

```xml

  <connectionStrings>
    <add name="OurDBContext" connectionString="Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False" providerName= "System.Data.SqlClient"/>
  </connectionStrings>
  
  ```
  
  #### Step 7: Controller and Action Methods
  We needed to use the GET-POST-Redirect pattern to create functionality. Here is my DMVFormController:
  
  ```cs
  
  public class DMVFormsController : Controller
    {
        private DMVFormContext db = new DMVFormContext();
        // GET: Forms
        public ActionResult Index()
        {
            return View(db.DMVForms.ToList());
        }

        // Get: Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID, ODL, DOB, Name, StreetAddress, City, State, Zip, Country")] DMVForm form)
        {
            if (ModelState.IsValid)
            {
                db.DMVForms.Add(form);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(form);
        }
    }
    
```

I also have a HomeController, but you don't need to see that. It just returns a view, nothing special. 

#### Step 8: Strongly Typed Views
Now we had to create the UI with razor. We needed two pages, one to create a page, and another to display all of the entries. The second part is what gave me the most trouble. I mean 4+ hours of acheiving nothing, but hey, I did it. Here is the index view of my DMVForm. This returns a view with the current requests from the database.

```cs
@model IEnumerable<hw5b.Models.DMVForm>

@{
    ViewBag.Title = "Current Requests";
}

<h2><span class="label label-default">Current Requests</span></h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(model => model.ODL)
        </th>
        <th>
            @Html.DisplayNameFor(model => model.DOB)
        </th>
        <th>
            @Html.DisplayNameFor(model => model.Name)
        </th>
        <th>
            @Html.DisplayNameFor(model => model.StreetAddress)
        </th>
        <th>
            @Html.DisplayNameFor(model => model.City)
        </th>
        <th>
            @Html.DisplayNameFor(model => model.State)
        </th>
        <th>
            @Html.DisplayNameFor(model => model.Zip)
        </th>
        <th>
            @Html.DisplayNameFor(model => model.Country)
        </th>
        <th></th>
    </tr>

@foreach (var item in Model) {
    <tr>
        <td>
            @Html.DisplayFor(modelItem => item.ODL)
        </td>
        <td>
            @Html.DisplayFor(modelItem => item.DOB)
        </td>
        <td>
            @Html.DisplayFor(modelItem => item.Name)
        </td>
        <td>
            @Html.DisplayFor(modelItem => item.StreetAddress)
        </td>
        <td>
            @Html.DisplayFor(modelItem => item.City)
        </td>
        <td>
            @Html.DisplayFor(modelItem => item.State)
        </td>
        <td>
            @Html.DisplayFor(modelItem => item.Zip)
        </td>
        <td>
            @Html.DisplayFor(modelItem => item.Country)
        </td>
        <td>
        </td>
    </tr>
}

</table>
```

And here is the page for creating a new 

```cs

@model hw5b.Models.DMVForm

@{
    ViewBag.Title = "Create a Request Address Change Form.";
}

<h2><span class="label label-info">Create New Request</span></h2>

@using (Html.BeginForm()) 
{
    @Html.AntiForgeryToken()
    
    <div class="form-horizontal">
        <h4></h4>
        <hr />
        @Html.ValidationSummary(true, "", new { @class = "text-danger" })
        <div class="form-group">
            @Html.LabelFor(model => model.ODL, htmlAttributes: new { @class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(model => model.ODL, new { htmlAttributes = new { @class = "form-control" } })
                @Html.ValidationMessageFor(model => model.ODL, "", new { @class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(model => model.DOB, htmlAttributes: new { @class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(model => model.DOB, new { htmlAttributes = new { @class = "form-control" } })
                @Html.ValidationMessageFor(model => model.DOB, "", new { @class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(model => model.Name, htmlAttributes: new { @class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(model => model.Name, new { htmlAttributes = new { @class = "form-control" } })
                @Html.ValidationMessageFor(model => model.Name, "", new { @class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(model => model.StreetAddress, htmlAttributes: new { @class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(model => model.StreetAddress, new { htmlAttributes = new { @class = "form-control" } })
                @Html.ValidationMessageFor(model => model.StreetAddress, "", new { @class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(model => model.City, htmlAttributes: new { @class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(model => model.City, new { htmlAttributes = new { @class = "form-control" } })
                @Html.ValidationMessageFor(model => model.City, "", new { @class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(model => model.State, htmlAttributes: new { @class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(model => model.State, new { htmlAttributes = new { @class = "form-control" } })
                @Html.ValidationMessageFor(model => model.State, "", new { @class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(model => model.Zip, htmlAttributes: new { @class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(model => model.Zip, new { htmlAttributes = new { @class = "form-control" } })
                @Html.ValidationMessageFor(model => model.Zip, "", new { @class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(model => model.Country, htmlAttributes: new { @class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(model => model.Country, new { htmlAttributes = new { @class = "form-control" } })
                @Html.ValidationMessageFor(model => model.Country, "", new { @class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Create" class="btn btn-default" />
            </div>
        </div>
    </div>
}

<div>
    @Html.ActionLink("Back to List", "Index")
</div>
```

#### Step 9: Demo the Site
Here are some screenshots of the working site:

##### The Home Page
![Home Page]((https://mgeorgebrown89.github.io/CS-Portfolio/CS-460/hw5/homepage.PNG)
##### The Current Requests Page
![Current Requests](https://mgeorgebrown89.github.io/CS-Portfolio/CS-460/hw5/preCreate.PNG)
##### The Create Page
![Create](https://mgeorgebrown89.github.io/CS-Portfolio/CS-460/hw5/create.PNG)
##### The New Entry
![New Entry](https://mgeorgebrown89.github.io/CS-Portfolio/CS-460/hw5/newEntry.PNG)

#### Step 10: Portfolio
Check.


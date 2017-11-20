---
Title: CS 460 - Homework 6.
Layout: default
---
## [Portfolio Home](https://mgeorgebrown89.github.io/CS-Portfolio) - [CS 460](https://mgeorgebrown89.github.io/CS-Portfolio/CS 460) - Homework 6

#### Step 1: Set Up the Database
First, we downloaded and extracted the AdventureWorks 2014 sample database to use with our homework 6 project. 

#### Step 2: Entity Framework - Code First from Existing Database
Next, we set up our project by using Entity Framework (Code First from Existing Database) to add the database to our project and reverse engineer all of the model classes for the Production subsystem only. After homework 5, this was actually pretty easy, and it someways it was actually easier to set up sicne we could autogenerate the model classes. I just followed [this guide](https://msdn.microsoft.com/en-us/library/jj200620(v=vs.113).aspx) to set up my project. 

#### Step 3: Feature 1: Browse Products
For this step, we needed to implement a storefront example, using the AdventureWorks database. I made a navbar with the four main categories. They each drop down to display their subcategories and by clicking them it takes the user to a list all the products within their subcategory. Here is the code for my navbar. (I realize I could have made this much shorter by using HTML helper methods and iterating through the categories to get the subcategories, but this was the first thing I implemented and it took me awhile to get the hang of using LINQ method syntax).


```html
<li class="dropdown">
                    <a class="dropdown-toggle" data-toggle="dropdown" href="#">
                        Bikes
                        <span class="caret"></span>
                    </a>
                    <ul class="dropdown-menu">
                        <li>@Html.ActionLink("All", "Bikes", "Home",null,null)</li>
                        <li>@Html.ActionLink("Mountain", "Bikes", "Home", new { id = "Mountain" }, null)</li>
                        <li>@Html.ActionLink("Road", "Bikes", "Home", new { id = "Road" }, null)</li>
                        <li>@Html.ActionLink("Touring", "Bikes", "Home", new { id = "Touring" }, null)</li>
                    </ul>
                </li>
```
This is just for the Bikes category of products and its four subcategories. There are three other similar snippets of code that I won't show here for the remaining categories. 

The corresponding code in my controller shows how the links are handled.

```cs
//GET: Home/Bikes/sytle
        public ActionResult Bikes(string id)
        {
            string Style = id;
            var Bikes = db.Products.Where(s => s.ProductSubcategory.ProductCategory.Name == "Bikes");

            if (Style == "All" || Style == null)
            {
                ViewBag.BikeType = "All Bikes";
                /*foreach (var bike in Bikes)
                {
                    byte[] image = bike.ProductProductPhotoes.FirstOrDefault().ProductPhoto.LargePhoto;
                    ViewBag.image = "data:image/png;base64," + Convert.ToBase64String(image, 0, image.Length);
                }*/
                return View(Bikes.ToList());
            }
            else
            {
                Bikes = db.Products.Where(s => s.ProductSubcategory.Name == Style + " Bikes");
                ViewBag.BikeType = Style + " Bikes";
                /*foreach (var bike in Bikes)
                {
                    byte[] image = bike.ProductProductPhotoes.FirstOrDefault().ProductPhoto.LargePhoto;
                    ViewBag.image = "data:image/png;base64," + Convert.ToBase64String(image, 0, image.Length);
                }*/
                return View(Bikes.ToList());

            }

```
Here you can see that the parameter `id` gets passed in as the `Style` which determines which products get placed in the list of `Bikes`.

#### Step 4: Add Review

#### Step 5: Portfolio
Got it.
---
Title: CS 460 - Homework 6.
Layout: default
---
## [Portfolio Home](https://mgeorgebrown89.github.io/CS-Portfolio) - [CS 460](https://mgeorgebrown89.github.io/CS-Portfolio/CS 460) - Homework 6

#### Step 1: Set Up the Database
First, we downloaded and extracted the AdventureWorks 2014 sample database to use with our homework 6 project. 

#### Step 2: Entity Framework - Code First from Existing Database
Next, we set up our project by using Entity Framework (Code First from Existing Database) to add the database to our project and reverse engineer all of the model classes for the Production subsystem only. After homework 5, this was actually pretty easy, and in some ways it was actually easier to set up since we could autogenerate the model classes. I just followed [this guide](https://msdn.microsoft.com/en-us/library/jj200620(v=vs.113).aspx) to set up my project. 

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
This is just for the Bikes category of products and its four subcategories. Here is a screenshot of the navbar:

![navbar](https://mgeorgebrown89.github.io/CS-Portfolio/CS 460/hw6/navbar.PNG)

There are three other similar snippets of code that I won't show here for the remaining categories. 

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
Here you can see that the parameter `id` gets passed in as the `Style` which determines which products get placed in the list of `Bikes`. If there is no `Style` specified, or it is `All`, then it displays all bikes in the category, otherwise it assumes what is passed is one of the subcategories, and filters the LINQ selection accordingly. This isn't a complete check, but it suffices for the purposes of this assignment (I hope). 

You can also see my abandoned attempt at getting the pictures to display on this View. I thought I had it at first, but it was only displaying the last product in the foreach loop's picture, rather than each one individually. I had better success on the Details View, however. Here is a screenshot of the bikes list being displayed successfully:

![Bikes List](https://mgeorgebrown89.github.io/CS-Portfolio/CS 460/hw6/bikeslist.PNG)


I realized I could do some more filtering with `html` stuff, so I would only need to construct one View for the details of all products. By doing things like so:
```html
  @if (Model.Color != null)
            {
                    <dt>
                        @Html.DisplayNameFor(model => model.Color)
                    </dt>

                    <dd>
                        @Html.DisplayFor(model => model.Color)
                    </dd>
                }
```
I could only display the information relevant to the product. I can also probably refactor my other views and controller methods so that I only have one view for all subcategory displays, rather than four separate ones, but that's for another project to figure out. Here is the details method in my controller:

```cs
  public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var Product = db.Products.Find(id);

            byte[] image = Product.ProductProductPhotoes.FirstOrDefault().ProductPhoto.LargePhoto;
            ViewBag.image = "data:image/png;base64," + Convert.ToBase64String(image, 0, image.Length);

            if (Product == null)
            {
                return HttpNotFound();
            }
            return View(Product);
        }
```
By now, I'd figured out LINQ a little better, and was using better queries. I needed some help, but I figured out the photoes eventually. Here is a screenshot of the details view:

![Details](https://mgeorgebrown89.github.io/CS-Portfolio/CS 460/hw6/details.PNG)

#### Step 4: Add Review
Finally, we needed to add review functionality to our site. This gave me some trouble. I finally figured it out when I included the ProductID field in the form, but I didn't want the user to have to manually enter in the number before it would allow them to actually post their review. I realized that I wasn't actually passing a review object to the View in my GET method, so it wouldn't automatically have the ProductID when the user got their through the link from the details page of the product they wanted to review. I got it to work by actually passing the review object like so:
```cs
 public ActionResult Review(int? id)
        { 
            var Product = db.Products.Find(id);
            ViewBag.product = Product.Name;
            ProductReview PR = new ProductReview();
            PR.ProductID = Product.ProductID;
            return View(PR);
        }
```
And then the ProductID field would already by filled when the user navigated there from the details page, and by making the ProductID field hidden, the user couldn't edit it before POSTing it. 
```cs
// Post: Home/Review/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Review([Bind(Include = "ProductReviewID, ProductID, ReviewerName, " +
            "ReviewDate, EmailAddress, Rating, Comments, CommentsModifiedDate, Product ")] ProductReview review)
        {
            string id = review.ProductID.ToString();
            ViewBag.ProductID = id;
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            if (ModelState.IsValid)
            {
                review.ProductID = Convert.ToInt32(id);
                review.ReviewDate = DateTime.Now;
                review.ModifiedDate = review.ReviewDate;
                review.Product = db.Products.Where(p => p.ProductID.ToString() == id).FirstOrDefault();

                db.ProductReviews.Add(review);
                db.SaveChanges();

                return Redirect("/Home/Details/" + id);
            }

            return View(review);
        }
```
Here is a pair of screenshots that show the review form filled in, and the corresponding details page view with the new review added to the page:

![Review Form](https://mgeorgebrown89.github.io/CS-Portfolio/CS 460/hw6/review.PNG)

![New Review](https://mgeorgebrown89.github.io/CS-Portfolio/CS 460/hw6/reviewAdded.PNG)



And with that, I was done. Below is a video demo of my site.

##### Demo

<a href="http://www.youtube.com/watch?feature=player_embedded&v=ReShEUasFF4" target="_blank"><img src="http://img.youtube.com/vi/ReShEUasFF4/0.jpg" 
alt="IMAGE ALT TEXT HERE" width="240" height="180" border="10" /></a>

#### Step 5: Portfolio
Got it.
---
Title: CS 460 - Homework 4.
Layout: default
---
## [Portfolio Home](https://mgeorgebrown89.github.io/CS-Portfolio) - [CS 460](https://mgeorgebrown89.github.io/CS-Portfolio/CS-460) - Homework 4

#### Step 1: Create an Empty MVC project.
This first step was pretty self-explanatory but still a little daunting. Its very tempting to just use a template, but I did the whole thing from scratch.

![Project Creation](https://mgeorgebrown89.github.io/CS-Portfolio/CS-460/hw4/creationEmptyProj.PNG)

#### Step 2: Implement Feature Branches
Now we begin feature branching. I made a feature branch for each of the three pages we made.

#### Step 3: Create a Home Page
I first branched into a new feature branch:

```bash 

$ git branch hw4
$ git checkout hw4

```

then, I created the skeleton for my home page:

![Early Beginning](https://mgeorgebrown89.github.io/CS-Portfolio/CS-460/hw4/earlybeginning.PNG)

Eventually, I applied some more Bootstrap things to make it look better. Also included are the @Html.Actionlinks.

```html

<div class="container">
    <div class="row">
        <div class="col-md-4"></div>
        <div class="col-md-4">
            <h2><span class="label label-default">@ViewBag.Message</span></h2><br />
            <ul class="list-inline">
                <li class="list-group-item">@Html.ActionLink("Page 1", "page1")</li>
                <li class="list-group-item">@Html.ActionLink("Page 2", "page2")</li>
                <li class="list-group-item">@Html.ActionLink("Page 3", "page3")</li>
            </ul>
        </div>
        <div class="col-md-4"></div>
    </div>
</div>

```

Here is a screenshot of it in action:

![Home Page example](https://mgeorgebrown89.github.io/CS-Portfolio/CS-460/hw4/homepageexample.PNG)

#### Step 4: Page 1. Form GET and Request Objects

Here we needed a form with at least two text fields and a submit button. We needed to `GET` a new page with the query strings, do something with them, and return a view with values from a `Request` object. I decided to implement the suggested temperature converter. 

Here is the code for my HTML form:

```html

<div class="form-horizontal">
    <form method="get" action="/Home/Page1">

        <label for="temp">Temperature: </label>
        <input type="number" class="form-control" name="temp" value="" required/>
        <br />
        <div class="radio-inline">
            <label for="c"> C </label>
            <input type="radio" name="optradio" value="C" checked />
        </div>
        <div class="radio-inline">
            <label for="f"> F </label>
            <input type="radio" name="optradio" value="F" />
        </div>

        <input type="submit" class="btn btn-default" name="submit" value="Submit" />
    </form>
</div>

```

Here is the associated C# code in the Page1 controller:

```cs

[HttpGet]
        public ActionResult Page1()
        {
            ViewBag.Message = "Page 1: Temperature Converter";

            double temp = Convert.ToInt32(Request.QueryString["temp"]);
            string degreeType = Request.QueryString["optradio"];
            double convTemp = 0;
            string convDeg = "";

            if (degreeType == "C")
            {
                convDeg = "F"; // what degree type we're converting INTO. 
                convTemp = (temp * (9 / 5)) + 32;
            }
            else
            {
                convDeg = "C"; // ^^^ CCCCC
                convTemp = (temp - 32) / (9 / 5);
            }

            Response.Write(temp + " degrees " + degreeType + " is " + convTemp + " degrees " + convDeg + ".");

            return View();
        }
```

And here is a screen shot of Page1 in action:

![Page 1](https://mgeorgebrown89.github.io/CS-Portfolio/CS-460/hw4/page1.PNG)

#### Step 5: Page 2. HTML POST and FormCollection.
Now we had to do the same thing (in my case, the temperature converter), but instead use a `FormCollection` object and use HTML `POST` in the HTML form. After writing the code for the parameterless GET controller action method, I wrote the one parameter POST action method. It is displayed below:

```cs

[HttpPost]
        public ActionResult Page2(FormCollection form)
        {
            ViewBag.Message = "Page 2: Temperature Converter 2.0";
            //If user submits no data, do this:
            if (form == null)
            {
                Response.Write("Please enter something.");
            }

            double inputTemp = Convert.ToDouble(form["temp"]);
            double outputTemp = 0;
            string inputDeg = form["optradio"];
            string outputDeg = "";
            string result1, result2 = "";

            if (inputDeg == "C") //celsius to fahrenheit
            {
                outputDeg = "F";
                outputTemp = (inputTemp * (9 / 5)) + 32;
            }
            else if (inputDeg == "F") // fahrenheit to celsius
            {
                outputDeg = "C";
                outputTemp = (inputTemp - 32) / (9 / 5);
            }
            else
            {
                Response.Write("Please enter a value.");
            }

            result1 = inputTemp.ToString() + " " + inputDeg;
            result2 = outputTemp + " " + outputDeg;

            ViewBag.result1 = result1;
            ViewBag.result2 = result2;
            ViewBag.eq = " = ";


            return View();
        }
```

Here is my Temperature Converter 2.0 in action:

![Temperature Coverter 2.0](https://mgeorgebrown89.github.io/CS-Portfolio/CS-460/hw4/tempconv2.PNG)

#### Step 6: Page3. The Loan Calculator and Model Binding.

I decided to do a monthly loan calculator for page 3, since 99% of the time(not a real statistic) this is how someone pays back a loan. The main difference between page 3 and page 2 is that we needed to implement model binding, meaning we had parameters in the contorller methods that bind directly to the form element values. We also need to make our page robust, which I mostly did by using HTML `required`.  Here is the code for my HTML `POST` form:

```html

<div class="form-group">
    <form method="post">

        <label for="principle">Principle: </label>
        <input type="number" class="form-control" name="principle" value="" step="100" required />
        <br />

        <label for="rate">Annual Interest Rate: </label>
        <input type="number" class="form-control" name="rate" min="1" max="100" step="0.01" requried/>
        <br />

        <label for="term">Term Length (In Months): </label>
        <input type="number" class="form-control" name="term" value="" required/>
        <br />

        <input type="submit" class="btn btn-primary" name="submit" value="Submit" />
    </form>
</div>

```

Here is the binded controller method:

```cs

  [HttpPost]
        public ActionResult Page2(FormCollection form)
        {
            ViewBag.Message = "Page 2: Temperature Converter 2.0";
            //If user submits no data, do this:
            if (form == null)
            {
                Response.Write("Please enter something.");
            }

            double inputTemp = Convert.ToDouble(form["temp"]);
            double outputTemp = 0;
            string inputDeg = form["optradio"];
            string outputDeg = "";
            string result1, result2 = "";

            if (inputDeg == "C") //celsius to fahrenheit
            {
                outputDeg = "F";
                outputTemp = (inputTemp * (9 / 5)) + 32;
            }
            else if (inputDeg == "F") // fahrenheit to celsius
            {
                outputDeg = "C";
                outputTemp = (inputTemp - 32) / (9 / 5);
            }
            else
            {
                Response.Write("Please enter a value.");
            }

            result1 = inputTemp.ToString() + " " + inputDeg;
            result2 = outputTemp + " " + outputDeg;

            ViewBag.result1 = result1;
            ViewBag.result2 = result2;
            ViewBag.eq = " = ";


            return View();
        }
```

Here is the page in action:

![Page 3](https://mgeorgebrown89.github.io/CS-Portfolio/CS-460/hw4/page3loancalc.PNG)

#### Step 7: Portfolio

I entered everything here. Hopefully this is the right amount of code snippits -- not too much, not too little. I commented all of my code as well, but did not include that in the snippits. 
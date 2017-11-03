---
Title: CS 460 - Homework 4.
Layout: default
---
## [Portfolio Home](https://mgeorgebrown89.github.io/CS-Portfolio) - [CS 460](https://mgeorgebrown89.github.io/CS-Portfolio/CS 460) - Homework 4

#### Step 1: Create an Empty MVC project.
This first step was pretty self-explanatory but still a little daunting. Its very tempting to just use a template, but I did the whole thing from scratch.

![Project Creation](https://mgeorgebrown89.github.io/CS-Portfolio/CS 460/hw4/creationEmptyProj.PNG)

#### Step 2: Implement Feature Branches
Now we begin feature branching. I made a feature branch for each of the three pages we made.

#### Step 3: Create a Home Page
I first branched into a new feature branch:

```git 

$ git branch hw4
$ git checkout hw4

```

then, I created the skeleton for my home page:

![Early Beginning](https://mgeorgebrown89.github.io/CS-Portfolio/CS 460/hw4/earlybeginning.PNG)

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

![Home Page example](https://mgeorgebrown89.github.io/CS-Portfolio/CS 460/hw4/homepageexample.PNG)




---
Title: CS 460 - Homework 1.
Layout: default
---
## [Portfolio Home](https://mgeorgebrown89.github.io/CS-Portfolio) - [CS 460](https://mgeorgebrown89.github.io/CS-Portfolio/CS 460) - Homework 1
### Github | HTML | CSS | Bootstrap

For homework 1, we are supposed to create a set of webpages in HTML and CSS, utilizing Bootstrap libraries, all while learning how to use Git. 

#### Step 1: Git | Repository
I downloaded the Git Bash since we're supposed to do everything from the command line this term (and the whole year). I first created a repository on Github. I don't remember what I originally named it -- I've since changed it several times, finally landing on CS-Repository. I then created my corresponding folder locally 
```bash 
   $ cd ~/Documents
   $ mkdir CS\ Portfolio
```
and after configuring Git with my user name and email, 
```bash
    $ git config --global user.name "mgeorgebrown89"
    $ git config --global user.email "m.george.brown89@gmail.com"
```
I ran into some issues with line ending preferences:
```bash
    $ git config --global core.autocrlf true
    $ git config --global core.safecrlf true
```
but more on that later.

#### Step 2: Github | `pull` | `add` | `commit` | `push`
Next, I added a `remote` to my local repository. 
```bash
$ git remote add origin 
```
and verified that it worked.
```bash
$ git remote -v
origin  https://github.com/mgeorgebrown89/CS-Portfolio.git (fetch)
origin  https://github.com/mgeorgebrown89/CS-Portfolio.git (push)
```
I then made some quick files, `add`ed, `commit`ed, and `push`ed them up to my Github repository. The first time I tried `push`ing, it ran into some issues with the autocrlf and safecrlf, so I set them to false, and it seemed to work. My professor said that for now, that's fine, but I will eventually have to figure it out when we get into more group work. 
```bash
    $ git add .
    
    $ git commit . -m "first commit"
    [master 4a240c9] more reorg
    1 file changed, 8 insertions(+), 8 deletions(-)

    $ git push origin master
    Counting objects: 3, done.
    Delta compression using up to 8 threads.
    Compressing objects: 100% (3/3), done.
    Writing objects: 100% (3/3), 351 bytes | 351.00 KiB/s, done.
    Total 3 (delta 2), reused 0 (delta 0)
    remote: Resolving deltas: 100% (2/2), completed with 2 local objects.
    To https://github.com/mgeorgebrown89/CS-Portfolio.git
        8e20106..4a240c9  master -> master    
```
I also tested the `pull` command by editing a file on my Github account in the browser and then `pull`ing it back down to my local repository. 
``` bash
    $ git pull origin master
    From https://github.com/mgeorgebrown89/CS-Portfolio
    * branch            master     -> FETCH_HEAD
    Already up-to-date.
```
#### Step 3: HTML | CSS | Bootstrap | The Website
The next step was to create a website using HTML and CSS. My experience with HTML was very limited, and my experience with CSS and Bootstrap was virutally nonexistent. I went through some basic tutorials and decided to make my website about my family, since the content didn't really matter, and I didn't have any other good ideas. I have a website for my DJ business (www.celebratewithcana.com) but I used squarespace, so it doesn't really teach anything about website design.

 Here is the link to my website. I'm not really happy with it. We are supposed to attempt to make a modern looking website, but mine definitely looks like its from 1997 or so. I may edit it from this point forward, but for now, here it is. 
#### [The Brown Family Website](TheBrownFamilyWebsite)
##### Website Requirement #1: Use Bootstrap | Demonstrate both single column and two or more column formatting

I started by reading up on Bootstap, and decided to use the CDN rather than download it. I used Bootstrap mostly to utilize their grid system. I added this to my `<head>` part of the `michael.html` page 
```html
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
```
and then added this two make two columns of equal width.
```html
      <div class="container">
          <h1>Michael George Brown</h1>
          <div class="row">
            <div class="col-sm-6" style="background-color:azure;">
              <p>Husband to Koren, Father to Nora, Jane &amp; Margot.</p>
                <p>Born in Portland, Oregon.</p>
            </div>
            <div class="col-sm-6" style="background-color:grey; border: 1px solid azure">
              <p>Things Michael Likes:</p>
                <ul>
                <li>His family, obviously.</li>
                <li>Running.</li>
                <li>Coffee.</li>
                <li>Music. Playing and listening.</li>
                <li>Showing he knows how to use an unordered list in HTML.</li>
                </ul>
            </div>
          </div>
        </div>
```
##### Website Requirement #2: Use your own CSS file
I made a CSS file, changing some aspects of my pages. Using the program "Brackets" made this really easy, as you can click on specific elements of HTML and add rules on your CSS page directly in the HTML editor. This actually helped me learn a lot about how HTML and CSS work together. 

I played around with changing colors and font styles. I'm not a visual person, but I know when something looks bad, I just can't do much to fix it. I may try to make my business's website on my own later, but for now, this is what I've got. Here is an example from my CSS file:
```html
.container {
    border-left: 1px solid dimgrey;
    border-top: 1px solid dimgrey;
    border-radius: 25px;
    padding: 20px;
    background-color: darkseagreen
}
```

##### Website Requirement #3: Navigation Bar or Menu
I looked up Bootstrap's template for Navbars, and used this one:
```html
	<script src="js/jquery-1.11.3.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    
    <nav class="navbar navbar-default">
        <div class="container-fluid">
          <div class="navbar-header">
            <a class="navbar-brand" href="index.html">The Browns</a>
          </div>
          <ul class="nav navbar-nav">
            <li class="active"><a href="michael.html">Michael</a></li>
            <li><a href="korenet.html">Korenet</a></li>
            <li><a href="nora.html">Nora</a></li>
            <li><a href="jane.html">Jane</a></li>
            <li><a href="margot.html">Margot</a></li>
            <li><a href="future.html">The Future</a></li>
            
          </ul>
            
        </div>
      </nav>
```
This is from the `michael.html` page, and if you look at the first `<li>` in the `<ul>`, you'll notice that it has an added attribute `class="active"` which makes that particular `<li>` a darker color, as well as some other things that I change in my own CSS file. For example:
```html
.active {
    font-size: 18px;
    font-weight: 400;
}
```
This made that part of the Navbar bigger and darker, making it clear to the user which page they are on. 
##### Website Requirement #4: Table
We also were required to make a table. I again used Bootstrap for this. 
```html
<div class="row">
            <div class="col-sm-12" style="background-color:azure;">
                    <div class="container">
                            <h2>Basic Information</h2>
                            <p>Here is some basic info about my family members. I figure you don't have our SSN so it's no big deal.</p>            
                            <table class="table">
                              <thead>
                                <tr>
                                  <th>Name</th>
                                  <th>Date of Birth</th>
                                  <th>Current Age</th>
                                </tr>
                              </thead>
                              <tbody>
                                <tr>
                                  <td>Michael</td>
                                  <td>September 22nd, 1989</td>
                                  <td>28 years old</td>
                                </tr>
                                <tr>
                                  <td>Korenet</td>
                                  <td>July 27th, 1990</td>
                                  <td>27 years old</td>
                                </tr>
                                <tr>
                                  <td>Nora</td>
                                  <td>June 28th, 2014</td>
                                  <td>3 years old</td>
                                </tr>
                                <tr>
                                  <td>Jane</td>
                                  <td>August 14th, 2015</td>
                                  <td>2 years old</td>
                                </tr>
                                <tr>
                                  <td>Margot</td>
                                  <td>March 21st, 2017</td>
                                  <td>0.5 years old</td>
                                </tr>
                              </tbody>
                            </table>
                          </div>
            </div>
          </div>
```
This worked pretty well. I did some weird things inside of the Bootstrap grid system. In certain views, the table container is actually bigger than the single column layout (also another requirement!) from Bootstrap. This was not something I was able to fix. 
##### Website Requirement #5: Three kinds of lists
We also had to use one of each kind of list: `ul`, `ol`, and `dl`. I did each of these on different pages. First the unordered list, which I did on the `michael.html` page:
```html
<p>Things Michael Likes:</p>
                <ul>
                <li>His family, obviously.</li>
                <li>Running.</li>
                <li>Coffee.</li>
                <li>Music. Playing and listening.</li>
                <li>Showing he knows how to use an unordered list in HTML.</li>
                </ul>
```
Then, the ordered lists, which is on the `korenet.html` page (I wasn't feeling very creative):
```html
 <ol>
                <li>One.</li>
                <li>Dos.</li>
                <li>Twa.</li>
                </ol>
```
And finally, the description list, which is on the `nora.html` page:
```html
 <dl>
                <dt>Shocks</dt>
                    <dd>Socks</dd>
                    <dt>Margoo</dt>
                    <dd>Margot</dd>
                    <dt>Waaaaa!</dt>
                    <dd>I'm tired.</dd>
                    </li>
                </dl>
```
##### Website Requirement #6: Consistantly Sylted Elements
I think I had moderate success with this, especially considering this was my first foray into HTML and CSS. I used my own CSS style to edit specific elements and ID tags in order to attempt to have a consistent color-scheme and rounded boxes. 

##### Website Requirement #7: No Plagiarism!
We were required to write all of the code ourselves and not use a WYSIWYG designer, which I did not. I did everything in Brackets! 

#### Step 4: Clone Your Repository
At this time, I have not had success cloning my repository to my P: Drive at school. 
#### Step 5: Github Pages | Portfolio 
If you're reading this, I've succeeded in setting up my Portfolio on Github pages!
#### Step 6: Blog Post
this is so meta. 
#### Step 7: Print Grading Rubric with URL
If you're reading this, I've succeed in printing the HW1 rubric and correctly copied down my URL! 
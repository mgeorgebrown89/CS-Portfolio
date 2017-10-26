---
Title: CS 460 - Homework 2.
Layout: default
---
## [Portfolio Home](https://mgeorgebrown89.github.io/CS-Portfolio) - [CS 460](../hw2) - Homework 2

### Git Branch | Merge | Javascript | jQuery | DOM

For homework 2, we are supposed to create another small website, showing that we can do basic Javascript and jQuery while practicing branching with git. 

#### Step 1: Create a New Branch
First, we were supposed to make a new folder named `hw2` and then make a new feature branch there while we work on this homework. Then we were to create an `index.html` and a `styles.css` file. 
```bash
  $ git checkout -b hw2
  Switched to a new branch 'hw2'
```

#### Step 2: Planning the website
For this part, we were to think about what we wanted to do with Javascript. We needed to take input from the user, do something with it, and provide output back by modifying elements on the page and adding new elements. It was supposed to fun, not too complicated, but interesting. 

After tossing aronud a few ideas that were probably way too complicated, I decided to something involving calculations regarding user's self-reported health information. My first idea was rather morbid &emdash; a death-clock of sorts. Its just a joke, and the math is very basic and definitely not accurate at all. I  can't account for every variable in someone's life after all. 

#### Step 3: Create a wireframe mockup
Here we needed to make a diagram of what we wanted our site to look like. My mockup is right here:
![HW2 Mockup](https://github.com/mgeorgebrown89/CS-Portfolio/CS 460/hw2/wireframemockuphw2.png)

#### Step 4: Create the working page
This part really frustrated me for awhile, but I eventually figured it out. I struggled getting the form stuff to work correctly. Here is a screenshot of the final page before entering in anything to the form:
![Before](https://github.com/mgeorgebrown89/CS-Portfolio/CS460/hw2/pre-input.PNG)
and here  is the page after entering in some information.
![After](https://github.com/mgeorgebrown89/CS-Portfolio/CS460/hw2/output.PNG)
You can view the actual page [here](website/index.html).

#### Step 5: Commit and push work frequently
I `commit`ed and `push`ed my work on a fairly regular basis. Every time I worked on homework 2, I `commit`ed and `push`ed my work at least once, if not multiple, times. 

#### Step 6: Merge
Finally, we had to merge our hw2 branch into the master branch:
```bash
  $ git merge hw2
Merge made by the 'recursive' strategy.
   CS 460/hw2/index.md           | 26 ++++++++++++++
   CS 460/hw2/website/index.html | 84 +++++++++++++++++++++++++++++++++++++++++++
   CS 460/hw2/website/styles.css | 12 +++++++
   3 files changed, 122 insertions(+)
   create mode 100644 CS 460/hw2/index.md
   create mode 100644 CS 460/hw2/website/index.html
   create mode 100644 CS 460/hw2/website/styles.css
```
and push it to our remote repository:
```bash
$ git push origin master
Counting objects: 8, done.
Delta compression using up to 8 threads.
Compressing objects: 100% (8/8), done.
Writing objects: 100% (8/8), 1.75 KiB | 898.00 KiB/s, done.
Total 8 (delta 0), reused 0 (delta 0)
To https://github.com/mgeorgebrown89/CS-Portfolio.git
   867efbb..d2e6c58  master -> master
```
This was slightly scary, but I did it!
 
#### Step 7: Portfolio
Everything we do for hw2 had to go into this portfolio. If you're reading this, I did it!
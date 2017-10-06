---
Title: CS 460 - Homework 1.
Layout: default
---
## [Portfolio Home](https://mgeorgebrown89.github.io/CS-Portfolio) - [CS 460](https://mgeorgebrown89.github.io/CS-Portfolio/CS 460) - Homework 1
### Github | HTML | CSS | Bootstrap

For homework 1, we are supposed to create a set of webpages in HTML and CSS, utilizing Bootstrap libraries, all while learning how to use Git. 

#### Step 1
I downloaded the Git Bash since we're supposed to do everything from the command line this term (and the whole year). I first created a repository on Github. I don't remember what I originally named it -- I've since changed it several times, finally landing on CS-Repository. I then created my corresponding folder locally 
``` 
   $ cd ~/Documents
   $ mkdir CS\ Portfolio
```
and after configuring Git with my user name and email, 
```
    $ git config --global user.name "mgeorgebrown89"
    $ git config --global user.email "m.george.brown89@gmail.com"
```
I ran into some issues with line ending preferences:
```
    $ git config --global core.autocrlf true
    $ git config --global core.safecrlf true
```
but more on that later. Next, I added a `remote` to my local repository. 
```
$ git remote add origin 
```
and verified that it worked.
```
$ git remote -v

```
---
Title: CS 460 - Homework 1.
Layout: default
---
## [Portfolio Home](https://mgeorgebrown89.github.io/CS-Portfolio) - [CS 460](https://mgeorgebrown89.github.io/CS-Portfolio/CS 460) - Homework 1
### Github | HTML | CSS | Bootstrap

For homework 1, we are supposed to create a set of webpages in HTML and CSS, utilizing Bootstrap libraries, all while learning how to use Git. 

#### Step 1
##### Git | Repository
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
but more on that later.

#### Step 2
##### Github | `pull` | `add` | `commit` | `push`
Next, I added a `remote` to my local repository. 
```
$ git remote add origin 
```
and verified that it worked.
```
$ git remote -v
origin  https://github.com/mgeorgebrown89/CS-Portfolio.git (fetch)
origin  https://github.com/mgeorgebrown89/CS-Portfolio.git (push)
```
I then made some quick files, `add`ed, `commit`ed, and `push`ed them up to my Github repository.
```
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
``` 
    $ git pull origin master
    From https://github.com/mgeorgebrown89/CS-Portfolio
    * branch            master     -> FETCH_HEAD
    Already up-to-date.
```
#### Step 3
##### HTML | CSS | Bootstrap
The next step was to create a website using HTML and CSS. My experience with HTML was very limited, and my experience with CSS and Bootstrap was virutally nonexistent. I went through some basic tutorials and decided to make my website about my family, since the content didn't really matter, and I didn't have any other good ideas. I have a website for my DJ business (www.celebratewithcana.com) but I used squarespace, so it doesn't really teach anything about website design. 
###### [The Brown Family Website](TheBrownFamilyWebsite)

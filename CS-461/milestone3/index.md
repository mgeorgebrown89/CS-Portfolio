---
Title: CS 461 - Milestone 3.
Layout: default
---
# [Portfolio Home](https://mgeorgebrown89.github.io/CS-Portfolio) - [CS 461](https://mgeorgebrown89.github.io/CS-Portfolio/CS-461) - Milestone 3
## Populate Product Backlog, Backlog Grooming, Scrum Agile Processes, Team Project Inception, Individual Project Ideas
### [Requirements](http://www.wou.edu/~morses/classes/cs46x/assignments/t2/M3.html)

For Milestone 3, we practiced more scrum and agile processes on the class project, went through an inception phase for our team project, and proposed initial ideas for our individual projects.

### Task 1: Product Backlog and Sprint Planning

For this task, we had to figure out how to use Visual Studio Team Services (just their scrum board stuff, we didn't use their version control). We practiced breaking down Epics into Features, Features into PBIs, and PBIs into tasks. 

### Task 2: Backlog Grooming

We assigned each person a task to finish for this first pretend sprint. We had to seperate something PBIs that we normamlly wouldn't, but it was mostly about figuring out VSTS and practicing Scrum. We ended up with these 4 tasks:

    1. Create Empty MVC project
    2. Create data model and up script
    3. Create Model Classes and Views
    4. Set Up Continuous Deployment

### Task 3: Sprint 1

The goal for the first sprint was just to get a Hello World style site up and continuously deployed. I was assigned the third task.

### Task 4: Team Project

This is when we decided to go with the elimination (assassins) game application and API. We brainstormed a few ideas and made a mindmap and early vision statement draft. 

#### Mindmap

![Mindmap](https://mgeorgebrown89.github.io/CS-Portfolio/CS-461/milestone3/mindmap.png)

#### Vision Statement 0.1

> For developers who want to create elmination-based live-actionn mobile games, the Elimination App and API is a server-side application that allows for an admin to make a game and set rules and invite other users to join the game. The application will store user accounts, skills and stats from previous and on-going games, as well as make decisions for furthering current games and setting up new ones. Unlike current methods for playing elmination-based live-action games, our product will remove the subjectivity that comes from a human moderator and human players determining a successful elimination and also make adding more rules to games easier and more fun. 

#### Needs and Features, Requirements

* Needs 
    * Database to store players, player stats, and game information. 
    * API that will allow developers to create games based on eliminating other players and building player stats.
    * Web App to manage the game and players to make accounts and manage them.
    
* Features
    * Create players to allow a user to manage their profile and level up their stats.
    * Skills that will be used to calculate a players chance of successful attacks and traps.
    * Items such as traps, range weapons, armor, anti-venom, theft
    * Bunker time to hide from enemies.
    * Management tools to determine if eliminations are valid like photo recognition, line of sight, bluetooth.

* Requirements
    * Non-functional
        * Need to use Json when passing data from server to client to decrease bandwith constraints.
        * Game and player information should be stored using minimal amount of memory to conserve space.

### Task 5: Individual Project Ideas

We just needed two rudimentary ideas for our team projects. 

#### Michael

| Idea | Platform | Language |
| ---- | -------- | -------- |
| A mobile app that uses the Elimination Framework and API that lets users manage their account and play in elimination-based games with other users.  | iOS | Swift |
| A mobile app that uses a flashcard system to test users' knowledge of subjects the want to learn (like foreign languages or human anatomy). | iOS | Swift |

#### Hannah

| Idea | Platform | Language |
| ---- | -------- | -------- |
| Companion app for group project Elimination API. The app allows users to access and manage their account as well as play against other users and receive new targets in elimination games. | Android | Java |
| Book barcode scanner app. The app allows you to scan a book’s barcode and then gives you reviews and possibly similar titles. Possibly using Goodreads API. | Android | Java |
| House plant identification app. The app uses image recognition to identify plant species and return care instructions. | Android | Java |

#### Alex

| Idea | Platform | Language |
| ---- | -------- | -------- |
| A mobile app to manage tasks created by a user. Tasks could be created to ignore calls when person is in meeting or when using media, such as watching a video or listening to music. | Android | Kotlin/Java |
|A mobile app to do construction takeoff from PDF house plans. It would produce linear footage for wall plates and studs for walls and plywood for floors and walls. | Android | Kotlin/Java |

#### Blake

| Idea | Platform | Language |
| ---- | -------- | -------- |
| blah | blahblah | blahblah |
---
Title: CS 461 - Milestone 4.
Layout: default
---
# [Portfolio Home](https://mgeorgebrown89.github.io/CS-Portfolio) - [CS 461](https://mgeorgebrown89.github.io/CS-Portfolio/CS-461) - Milestone 4
## Class Project Iteration, Team Project Inception, Individual Project Basis
### [Requirements](http://www.wou.edu/~morses/classes/cs46x/assignments/t2/M4.html)

For Milestone 4, we practiced a condensed version of a full sprint iteration (minus the retrospective). We also continued the inception phase for our team project and were to start learning the necessary languages and frameworks for our individual projects. 

### Task 1: Class Project 1 Week Sprint

We groomed our backlog and assigned some more tasks to each member of our team to add some features and functionality to our XC team site. Then we worked on our individual tasks. I worked on getting the most recent run of a particular athlete to display on their details page (at this point everything was still in Entity Framework's basic CRUD views). I learned (somewhat) how to do a Model-View-ViewModel. 

---

### Task 2: Team Project Inception Phase II

Now, its the fun stuff. We were told to "Spend quality time working on your team project." Below are the artifacts we came up with.

---

#### Needs, Features and Requirements

* ### Needs 
    * Database to store players, player stats, and game information. 
    * API that will allow developers to create games based on eliminating other players and building player stats.
        * Developers to create games to test for us
    * Web App to manage the game and players to make accounts and manage them.
    ---
* ### Features
    * #### Player Creation
        * Profile Management
            * Photo
            * Bio
            * Change Password
            * Social Media Login? 
        * View Skills
            * Upgrade Skills with Coins
        * View Performance Stats
        * View Awards/Achievements/Badges
    * #### Elimination Validation
        * Photo-recognition
        * Line-of-sight
        * Bluetooth
        * Manual Host overrule 
    * #### Skills
        * Weapon Proficiency 
        * Trap Proficiency
        * Armor Proficiency
        * Awareness 
        * Sneak
        * Pick-Pocket
        * Tracking?
        >  Used to calculate a players chance of successful attacks and traps (or escape from them), as well as informing the future game target algorithm.
        
    * #### Inventory
        * Armor
        * Weapons
            > Types incremented by range
            * Melee (within 5ft, not affected by armor)
            * Ranged (from further than 5ft)
            * Distanced (like artillery, from anywhere)
            > Modified by Weapon Proficiency Skill
        * Traps
            * Bombs (target only or bystanders)
            * Poison (disguised as items?)
            * Bear Trap (steal skills?)
            * > Modified by Trap Proficiency Skill
        * Items
            * Antivenin
            * Potions?
            * Ammunition?
        * Wallet
    * #### Stats
        * ##### Basic
            * Games Won
            * Games Played
            * Successful Eliminations (kills)
                * Success/Failed (kills/near-misses) Ratio
                * Eliminations/Eliminated (kill/death) Ratio
            * Failed Eliminations (Near-misses)
            * Times Eliminated (deaths)
                * Eliminated/Escaped (death/close-call) Ratio
            * Times Escaped (Close-calls)
        * ##### Detailed
            * Total Distance Travelled
                * Average Distance Travelled per game
                * Average Distance Travelled per elimination
            * Total Time Alive
                * Average Time alive per game
                * Average Time between eliminations
            * Average speed 
    * #### In-Game Currency/Experience Points (Coins)
        * Earned from:
            * Game Victory
            * Successful Elimination
                * Amount varies based on method
            * Successful Escape
            * Achievements
                * Time Alive (outside safe-time/zones)
                * Distance Travelled (outside safe-time/zones)
            * Item-Drops
            * Successful Pick-pocket
        * Spent on: 
            * Weapons, Traps, Items, Armor
            * Upgrading skills
        * Lost from:
            * pick-pocket
            * bear-traps
            * missed check-in
    * #### Awards/Achievements/Badges
        * Number-based
            * Games played
            * Games won
            * Players Eliminated 
            * Times Eliminated
            * Near-misses
            * Close-calls
        * Time-based
        * Distance-based
    * #### Player Settings
        * Safe-times (Bunker-time) (Per-minute invincibility time for things like class or other important things, set by individual user)
        * Safe-Zones (set a home base radius by GPS)
    * #### Global Settings/Rules
        > Game hosts establish (most) rules before game begins
        * Safe-Times (bunker-time) (per-minute invincibility for all players)
        * Safe-Zones (GPS-based safe zones for all players)
        * Total Game Duration 
            * Beginning Time
            * Ending Time or Last-person-standing
        * Game Region
            * GPS based zone for game
            * penalties for leaving zone
                * after certain duration
        * Elimination Rules
            * Allowed frequency of attempts
            * Penalties for near-misses
                * cool-down timer
                * forced **check-in**
            * Awards for eliminations, close-calls
                * Coins, items, skill increases
            * Function after being eliminated
                * Become host's enforcers
            * Target acquisition style
                * Circle (singular or multiple, tiered)
                * Teams 
                * Free-for-all
            * Target Randomization
                * Frequency or none
        * Item-Drop Rules
            * Manual or random location
            * frequency
            * accessibility duration
            * visible or mystery items(good and bad), coins
        * Location Check-in Rules
            * accessibility duration
            * required or optional
            * penalty for missing
                * elimination, skill-loss, item-loss
    ---
* ### Requirements
    * #### Non-functional
        * Need to use **Json** when passing data from server to client to decrease bandwidth constraints.
        * Game and player information should be stored using minimal amount of memory to conserve space.
---
#### Overall Architecture Design
![Overall Architecture Design](https://mgeorgebrown89.github.io/CS-Portfolio/CS-461/milestone4/architecture-diagram.png)

---

#### Initial Modeling 
* ### Initial Database Design
![ER-Diagram](https://mgeorgebrown89.github.io/CS-Portfolio/CS-461/milestone4/initial-database-design.png)

* ### Use Cases
![Overall-Use-Case](https://mgeorgebrown89.github.io/CS-Portfolio/CS-461/milestone4/overall-use-case.png)
![View-Use-Case](https://mgeorgebrown89.github.io/CS-Portfolio/CS-461/milestone4/view-use-case-diagram.png)

---
#### Timeline and Release Plan

---
#### Epics/Features/User stories in Visual Studio Team Services
Check.
---
#### Final Vision Statement
> For people who want to create elimination-based live-action mobile games (like Assassin! or Humans Vs. Zombies), the Elimination Framework and API is an application that allows for an admin to make a game and set rules and invite other users to join the game. Elimination-based live action games involve players being assigned other players as targets and then proceeding to attempt to eliminate their target/targets, traditionally with mock-projectiles (like Nerf-guns or balled up socks), by whatever rules are established for the specific game, until either the last player/team is remaining. Unlike current methods for playing elimination-based live-action games, our full website will remove the subjectivity that comes from a human moderator and human players determining a successful elimination and also make adding more rules and features (like player skill modifiers, a player inventory, and methods of elimination) to games easier and more fun. The application will store user accounts, skills, and stats from previous and on-going games, as well as make decisions for furthering current games and setting up new ones.
---
#### Identification of Risks
* ### Photo-Recognition
    * It may be too difficult to implement or it may not be accurate enough to work. It also may be to slow and ruin the immersion.
    * A player could possibly cheat this system by taking a picture of a picture or resend a previously taken photo the resulted in a successful elimination.    
* ### GPS
    A trap may be set in the bottom floor of a building but go off if someone passes by it on the second floor. 
* ### Legality 
    * Some might call the kind of behaviors expressed while playing elimination-based live-action games "stalker-ish" or "creepy." 
    * There may be misunderstandings that we could be held liable for...
* ### Security 
    * Bluetooth vulnerability 

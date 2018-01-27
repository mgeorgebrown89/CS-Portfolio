---
Title: CS 461 - Milestone 2.
Layout: default
---
# [Portfolio Home](https://mgeorgebrown89.github.io/CS-Portfolio) - [CS 461](https://mgeorgebrown89.github.io/CS-Portfolio/CS-461) - Milestone 2
## Class Project Inception, Team Project Ideas Refining, Practice Git Workflow
### [Requirements](http://www.wou.edu/~morses/classes/cs46x/assignments/t2/M2.html)

For Milestone 2, we went through an inception phase for the throw-away class project, which was creating a application for a Cross Country Coach to use with his team to monitor training. We also refined some of our team project ideas. 

### Task 1: Inception

We met for a few hours to go through this phase, which we learned about last term. There were several things we had to do:

#### List of Primary Needs and Features

* Database
* Hardware
    * watches, etc.
* Garmin API
* Authentication
* Graphs, Tables, representation
* scheduling of tasks, training plans

We were told afterword that we needed to elaborate in the future. 

#### Top-Level Requirements and Non-functional Requirements

* storage
* privacy
* backup
* security
* usability
* performance
* support

#### 10 User Stories

1. As a coach I want to view an individual athlete's performance so that I can make personalized decisions about their future training. 
	
2. As a coach I want to view all, or some subset, of my atheletes performance/training so that I can make general team-wide training decisions. 
	
3. As a coach I want to be able to make training plans and schedules and assign workouts to individuals and/or groups, like varistity, JV, men or women, etc. so that the atheletes can be informed of upcoming workouts.
	
4. As a coach I want to create a notification about changes in schedule or training plan so that athletes can be informed. 
	
5. As an athlete I want to create an account so that I can edit my profile, bio, picture, and most importantly monitor my performance and (hopefully) improvement over time. 

6. As an athlete I want to be able to control the level of privacy so that I can limit who has access to my profile. 

7. As an admin I want to be able to create coach accounts so that they can manage their athletes. 

8. As an athlete I want to be able to choose how I am notified so that I am informed in the most convinient way to me. 
	
9. As a parent or guardian of an underage athlete I want to be able to view their profile and stats so that I can check in on them and encourage them. 

10. As a coach I want to be able to print or download graphs of performace stats or training plans so that I can reference them.  

#### Modeling Outputs

##### Use Case Diagram

![Use Case Diagram](https://mgeorgebrown89.github.io/CS-Portfolio/CS-461/milestone2/use-case-diagram.jpg)

##### ER Diagram

![ER Diagram](https://mgeorgebrown89.github.io/CS-Portfolio/CS-461/milestone2/er-diagram.jpg)

#### Architecture Drawing

![Architecture Drawing](https://mgeorgebrown89.github.io/CS-Portfolio/CS-461/milestone2/architecture-diagram.jpg)

#### Vision Statement 0.9

> For coaches who need to keep record of their athletes overall training and performance, the Place-Holder-Name is a site that will provided a single point of access to view and monitor the performance of every athlete on the team, thereby allowing the coach to create individualized workouts and group training tailored for the team’s needs. Unlike the websites currently available that track athlete performance, our product will incorporate data gathered from every athlete’s Garmin GPS watch, heart rate monitor, and foot pod, providing such information as distance, splits, time, cadence, heart rate, as well as other metrics based that data. 

### Task 2: Refine Team Project Ideas

We needed to think more about our project ideas, choose two, and then answer some specifc questions about them. We went with one of our original three ideas, but we had actually had another idea, so we went with this new one instead. Here is what we came up with:


> #### Study Buddy App
> A study aide for people that would incorporate an AI API to use a chatbot to quiz them and flashcards which would use an algorithm to determine how often a card appears based on user feedback. 
> ##### Flashcard system
> A user answers the card (either from a list of subjects, but we'll stick to just Human Anatomy and Physiology for now, or self-generated) and then rates how well they know the answer on a scale of 1-5, which then determines the frequenct with which the card is presented again. This attempts to turn short-term memory into long-term memory. 
> ###### Chat-bot
> An interface to facilitate a studying session, incorporating the flashcard system (and possibly other study techniques.) Using a chat-bot is new to these kind of apps. There are study aides the have real-life tutors, but those are expensive and our idea could be much cheaper.
>
> Its worth doing because it can help all people from all socioeconomic statuses have academic success. Its convienient. 
>
> We would need a deep learning API like Watson or Microsoft Azure Cognitive Services. 
>
> Algorithmic content is the flashcards system. 
>	
> We rate it a 7 overall, but really 6-8 depending on how many features we would implement.  

This was our new idea.

> #### Police Speed Prevention App
>An application for police officers to record and upload incidents of speeding and use machine learning to predict likely areas for repeated speeding offences and good places to patrol in order to increase public safety. 
>
>It would be specific to speeding (for now). There are programs already like this, but are more generalized and it sounds like there's no concensus on whether they work or not. 
>	
>It's worth doing because it would increase public safety as well as police revenue. 
>
>We would need as machine learning API as well as google maps API. 
>
>The algorithmic content is stuff like making graphs, etc. 
>
>We rate this a 6. 

After all of this, we actually come up with *another* new idea, and this is actually what we are officially moving forward with for the rest of the year. I actually went ahead and wrote this up after-the-fact since we were already finished with this milestone. 


>#### Assassins	
>An application to host and manage users (assassins) and games and their rules. Individual projects 	would interact with this application to actually play out specific games. A user recieves a picture of their target. Their target also has a target, who has a target, etc. until the last user has the original user as their target. They would use their phone (somehow) to eliminate their target. This could be done with some sort of bluetooth proximity, line of sight, or picture recognition, or some combination. Other rules (power-ups, etc) could be implemented incrementally. 
>
>This idea is original in that it hasn't been done this thoroughly before. There is one mobile app with this game, but it requires a human moderator to determine if the elimination is successful or not. Our project would remove the subjectivity of a human moderator. 
>	
>This idea is worth doing and not boring because it would be really fun. It is a game after all.
>
>We would need to figure out how to use different features of smartphones to figure out the elimination mechanics. Also we will look into using a cognitive service to match photots taken of targets. 
>
>We could use algorithmic content to initially establish who has what target. If there are repeat players from past games, their stats could affect how they are placed within the circle of Assasssins. 
>
>Topic rating: 6?

### Task 3: Practice Git Workflow

It seems trivial at this stage, but it is helpful. 
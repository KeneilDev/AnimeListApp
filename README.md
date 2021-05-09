# AnimeListApp
**QA CRUD Application Project or Keneil Jordan :tw-1f310:
**




**Contents**

1. [ Brief. ](#brief)
2. [ Architecture. ](#Architecture)
3. [ Project Tracking. ](#projecttracking)
4. [ Risk Assessment. ](#riskassessment)
5. [ Testing. ](#testing)
6. [ Front-End Design. ](#frontenddesign)
7. [ Known Issues. ](#knownissues)
8. [ Future Improvements. ](#futureimprovements)
9. [ Authors. ](#authors)







<a name="brief"></a>
## 1. Brief
For this brief I have been asked to create a CRUD application with the utilisation of supporting tools,
 methodologies and technologies that encapsulate all core modules
 covered during training.

**Additional Requirements**

In addition to the requirements set out in the brief, I am also required to include the following:

- A Trello board (or equivalent Kanban board tech) with full expansion
 on user stories, use cases and tasks needed to complete the project.
 It could also provide a record of any issues or risks that I faced
 creating my project.
- A relational database used to store data persistently for the
 The project, with at least 2 tables it.
- Clear Documentation from a design phase describing the architecture
 I used for my project as well as a detailed Risk Assessment.
- A functional CRUD application created in C#, following best
 practices and design principles, that meets the requirements set on
 my Kanban Board.
- Fully designed test suites for the application, as well as automated tests for validation of the application. Provide high test coverage in your backend and provide consistently
 reports and evidence to support a TDD approach.
- A functioning front-end website and integrated API&#39;s, using ASP.NET. As a stretch goal add an Angular based front-end.
- Code fully integrated into a Version Control System using the
 Feature-Branch model which will subsequently be built through a CI
 server and deployed to a cloud-based virtual machine.

##**My Approach**

To meet the requirements of the brief, I have produced a MVC Web application using the .NET Framework Core that that must allow the user to do the following:

- Create a user account (satisfies &#39;Create&#39;) that stores:
  - _Username_
  - _First and Last Name_
  - _Email_
  - _Password_
- Create a list of Anime in the anime library (satisfies &#39;Create&#39;) with the following information:
  - _Name_
  - _Description_
  - _PictureURL_
  - _Genre_
  - _CreatedAt_
- View and update their anime details (satisfies &#39;Read&#39; and &#39;Update&#39;)
- Delete an anime (satisfies &#39;Delete&#39;)

Additionally, I would like to allow the user to:

- Add an individual anime to their list
- Change the current status of the anime they are watching

<a name="Architecture"></a>
##**Architecture**

**Database Structure**

Pictured below is an entity relationship diagram (ERD) showing the structure of the database.

OLD:

![Alt text](/ReadmeImages/image001.png "Old ERD")


NEW:

![Alt text](/ReadmeImages/image003.png "New ERD")

In the ERD&#39;s shown above, the user\_anime table has a one-to-many relationship between the users and anime table. This allows multiple users to have the same anime in their list and each will have a separate status as seen in the remodelled version of the ERD. Another change that was made to the newer ERD was the implementation of a &quot;CreatedAt&quot; attribute.

**CI Pipeline**

![Alt text](/ReadmeImages/image005.png "Pipeline")

The picture above shows the structure of my CI Pipeline. It works from using my local machine and push the code to GitHub which is linked to my azure pipeline. In my Azure pipeline it is linked to my azure web service and the building agent that is set up on my Virtual Machine in azure. Once the pipeline script is ran, it pushes the repository to the web app that was created on azure and an updated app should show on my hosted website.

<a name="projecttracking"></a>
##**Project Tracking**

Trello was used to track the progress of the project (pictured below). You can find the link to this board here: [QA Crud Application | Trello](https://trello.com/b/HARAm46v/qa-crud-application)

![Alt text](/ReadmeImages/image007.png "Trello Board")

The board has been designed and structured to move from left to right from of the project implementation. The summary of each card is stated below

- Backlog [User Stories]:  A list of requirements set out in the brief in order for this to be a successful project.
- _Project Resources:_ List of relevant resources
- _User Stories:_  Any functionality that is implemented into the project first begins as a user story. This keeps the development of every element of the web app focused on the user experience first.
- _Planning:_ is the section where decisions are being made on what needs to be implemented next
- _In Progress_: shows what&#39;s currently being worked on
- _Testing:_ once a feature has been implemented it goes onto the testing stage
- _Finished_ : this section contains the features that have passed the testing stage and made it to production

<a name="riskassessment"></a>
##**Risk Assessment**

The risk assessment matrix for this project can be found below in the screenshot :

![Alt text](/ReadmeImages/image009.png "Risk ssessment")


<a name="testing"></a>
##**Testing**

Only one of the controllers for this application was tested using xUnit testing alongside with a code coverage report addon. The controller test included Repository patterns, Moq implementation to mock the controller behaviour.

Below is a screenshot of the coverage report :

![Alt text](/ReadmeImages/image011.png "Test Coverage 1")

Here&#39;s another screenshot showing the coverage report for the AnimesController of 72%:

![Alt text](/ReadmeImages/image013.png "Test Coverage 2")


<a name="frontenddesign"></a>
##**Front-End Design**

When the web app is first launched the user will be brought to this home page:

![Alt text](/ReadmeImages/image015.png "Home")

The User will now be able to login or register

![Alt text](/ReadmeImages/image017.png "Register")

![Alt text](/ReadmeImages/image019.png "Login")

Once they are logged in, they gain access to the &#39;Anime Library&#39; page and their account page:

![Alt text](/ReadmeImages/image021.png "Library")

If the user decides to navigate to the &#39;Anime Library&#39; page, they can create a new anime or add it to their library if it doesn&#39;t already exist in their list :

![Alt text](/ReadmeImages/image023.png "User List")

<a name="knownissues"></a>
##**Known Issues**

There is only one known issue that I am aware of in the current application which is:

- When a user tries to add an anime to their list that already exists, it doesn&#39;t update the previous value

<a name="futureimprovements"></a>
##**Future Improvements**

For future improvements outside of my existing bugs I would like to:

- Have a fully working API
- Implement more tests
- Add a filter to sort anime list by genre etc.
- Add a review system to anime that multiple users can alter by leaving a review
- Implement Angular


<a name="authors"></a>
##**Authors**

Keneil Jordan

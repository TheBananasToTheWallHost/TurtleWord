TurtleWord ReadMe

==About TurtleWord==

==ReadMe Specific==

+ ReadMe created on 12/23/2017.
+ Nothing done before the creation of the ReadMe was recorded.

==Log==

12/24/2017
+ Added a method that updates the users info XML

12/26/2017
+ Added check to see if the form is populated (i.e. is displaying all the users account info)
+ Added a check for existing accounts when creating a new account
+ Added labels for the table columns
+ Added method that deals with duplicates and apps with multiple accounts properly

07/22/2018
+ Removing the reset password to do due to security concerns.
+ Added comments to the start-up form, the info form, the xml checker, and the xml maker.
+ Added a remove entry button - not functional yet though.

07/27/2018
+ Implemented a password search in the xml checker 
+ Added functionality to the search button
+ Implemented entry removal (at least from the account info files)
+ Added functionality to the remove button
+ Changed how entries are added to the xml file. They're added one at a time as they're entered into turtle word, instead of 
adding all new entries on form closing.

09/18/2018
+ Added an entry tracking system to remove and add table entries properly

==To Do==

09/18/2018
+ Add some basic copy/paste functionality
+ Add enter key functionality

07/27/2018
+ Clear username and password texboxes when wrong username/password input in start-up window
- *** Add password searching functionality - Done ***
+ Trim entries to the account XML and user information XML before they're added to their respective files
- *** Remove entries from the table if they're in the turtle word table and are being removed - Done ***
- *** When searching check the turtle word table if the entry being searched for isn't found in the file - Removed ***
- *** Add a mechanism to deal with duplicates in the Turtle Word form - Done ***
- *** Add mechanism to deal with duplicates on the turle word form when clicking display all entries - Done ***

12/27/2017
- *** Add an event to auto log someone off after a certain amount of time - Removed ***
+ Add tooltips and help form/page

12/24/2017
- *** Figure out how to deal with duplicates and apps the user has multiple accounts for - Done ***
- *** Add existing account check for logging in/creating account - Done ***

12/23/2017
- *** Implement the XML info updater - Done ***
+ Add a specific search function that allows copy pasting
- *** Add a remove function that allows entries to be removed - Done ***
- *** Add a reset password function - Removed ***
+ Add proper checks for addings entries
- *** Add labels for table columns - Done ***
+ Check to see what characters are valid/accepted when saving XML/txt files
+ Attempt to add encryption shenanigans
+ Look into using a database over XML/txt files
//Hello! This is your ProfileHubApp.
//    Here you can Add, View, Update and Delete your Profile.
//    Enjoy!

/* How it works: 

    It works by having basic 3 classes: Menu, Profile and ProfData.
*/

/* Menu class is where the user can choose what to do with the profile.
   
Menu class have 2 methods:
ShowMenu - is where the user can choose what to do with the profile.
AccessMenu - is where the user can access the profile details.
*/

/* Profile class is where the profile details are created.
    
Profile class have 4 properties: 
Name - consists of firstName and lastName input fields / on which the Name is concatenated.
Age - is the age of the person input.
Year of Birth - is automatically assigned by subtracting the Age property from the current year.
Id - is a random number generated between 100 and 999.
*/

/* ProfData class is where the profile data is stored using a .txt and manipulated.
    
ProfData class have 5 methods:
AddProfile - is where the user inputs the profile details and a new profile is created.
ShowProfile - is where the all profile details are displayed.
SaveProfData - is where the profile details are saved in a .txt file.
LoadProfData - is where the profile details are loaded from the .txt file.
ViewProfile - is where the user inputs the Id and the profile details are displayed.
UpdateProfile - is where the user inputs the Id and the profile details are updated.
DeleteProfile - is where the user inputs the Id and the profile details are deleted.
 */

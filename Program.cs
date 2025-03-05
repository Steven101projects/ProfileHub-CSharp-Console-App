using System.Data;
using System.Diagnostics.Metrics;
using System.IO;
using ProfileHubApp;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

namespace ProfileHubApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to ProfileHub! \n");
            ProfData.LoadProfData();
            Menu.ShowMenu();
            //ProfData.ShowProfile();
        }
    }
    class Menu
    {
        public static void ShowMenu()
        {
            string userChoice;
            Console.WriteLine("-)-)-)-)-)-)-)-)-)-");
            Console.WriteLine("                  :");
            Console.WriteLine("1. Add Profile    :");
            Console.WriteLine("2. View Profile   :");
            Console.WriteLine("3. Update Profile :");
            Console.WriteLine("4. Delete Profile :");
            Console.WriteLine("5. Exit           :");
            Console.WriteLine("                  :");
            Console.WriteLine("...................");

            Console.Write("Please choose your choice: ");
            userChoice = Console.ReadLine();
            AccessMenu(userChoice);
        }
        public static void AccessMenu(string choice)
        {
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Add Profile");
                    ProfData.AddProfile();
                    Menu.ShowMenu();
                    break;
                case "2":
                    Console.WriteLine("View Profile");
                    ProfData.ViewProfile();
                    Menu.ShowMenu();
                    break;
                case "3":
                    Console.WriteLine("Update Profile");
                    ProfData.UpdateProfile();
                    Menu.ShowMenu();
                    break;
                case "4":
                    Console.WriteLine("Delete Profile");
                    ProfData.DeleteProfile();
                    Menu.ShowMenu();
                    break;
                case "5":
                    Console.WriteLine("Exit");
                    Console.WriteLine("Goodbye!");
                    break;
                case "0":
                    ProfData.ShowProfile();
                    Menu.ShowMenu();
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    ShowMenu();
                    break;
            }
        }
    }
    };
class Profile
{
    public string firstName;
    public string lastName;
    public string Name { get { return $"{lastName}, {firstName}"; }

    }
    public int Age { get; set; }

    public int Yob { get; set; } 

    public int Id { get; set; }

    public Profile(string firstName, string lastName, int age)
{
    this.firstName = firstName;
    this.lastName = lastName;
    Age = age;
    Yob = DateTime.Now.Year - age;
    Id = new Random().Next(100, 999);
    }
    public Profile(string name, int age, int yob, int id)
    {
        string[] fullName = name.Split(",");
        this.lastName = fullName[0];
        this.firstName = fullName[1].Trim();
        Age = age;
        Yob = yob;
        Id = id;
    }
    public override string ToString()
    {
        return $"{Name}\n{Age}\n{Yob}\n{Id}";
    }
}
class ProfData
{
    public static List<Profile> profiles = new List<Profile>();
    public static void AddProfile()
    {
        string firstName, lastName;
        int age;
        Console.Write("Enter First Name: ");
        firstName = Console.ReadLine();
        Console.Write("Enter Last Name: ");
        lastName = Console.ReadLine();
        Console.Write("Enter Age: ");
        age = Convert.ToInt32(Console.ReadLine());
        Profile profile = new Profile(firstName, lastName, age);
        profiles.Add(profile);
        Console.WriteLine($"Profile Added!\nYour ID: {profile.Id}");
        SaveProfData();
    }
    public static void ShowProfile()
    {
        foreach (Profile profile in profiles)
        {
            Console.WriteLine(profile);
        }
    }
    public static void SaveProfData()
    {
        TextWriter textWriter = new StreamWriter("Profile.txt");
        foreach (Profile profile in profiles)
        {
            textWriter.WriteLine(profile);
        }
        textWriter.Close();
        Console.WriteLine("Saved Successfully");
    }
    public static void LoadProfData()
    {
        TextReader reader = new StreamReader("Profile.txt");
        string lastName;
        string firstName;
        int age;
        int yob;
        int id;
        string name;

        if (File.Exists("Profile.txt"))
        {
            while ((name = reader.ReadLine()) != null)
            {
                age = Convert.ToInt32(reader.ReadLine());
                yob = Convert.ToInt32(reader.ReadLine());
                id = Convert.ToInt32(reader.ReadLine());
                profiles.Add(new Profile(name, age, yob, id));
            }
            reader.Close();
        }

    }
    public static void ViewProfile()
    {
        int userId;
        bool found = true;
        Console.Write("Enter your id: ");
        userId = Convert.ToInt32(Console.ReadLine());
        foreach (Profile profile in profiles)
        {
            if (profile.Id == userId)
            {
                Console.WriteLine("Here's your Profile! ");
                Console.WriteLine("-------------");
                Console.WriteLine($"Name: {profile.Name}\nAge: {profile.Age}\nYear of Birth: {profile.Yob}\nID: {profile.Id}\n");
                Console.WriteLine("------------- \n");
                found = true;

                break;
            }
            else
            {
                found = false;
            }
        }
        if (!found)
        {
            Console.WriteLine("We're Sorry. Your Id is not in our database. Try again.");
            ViewProfile();
        };
    }
    //this is where the updater should be
    public static void UpdateProfile()
    {
        int userId;
        bool found = true;
        Console.Write("Enter your id: ");
        userId = Convert.ToInt32(Console.ReadLine());
        foreach (Profile profile in profiles)
        {
            if (profile.Id == userId)
            {
                Console.WriteLine("PROFILE DETAILS:");
                Console.WriteLine("-------------");
                Console.WriteLine($"Name: {profile.Name}\nAge: {profile.Age}\nYear of Birth: {profile.Yob}\nID: {profile.Id}\n");
                Console.WriteLine("------------- \n");
                found = true;
                Updater(profile);
                break;
            }
            else
            {
                found = false;
            }
        }
        if (!found)
        {
            Console.WriteLine("We're Sorry. Your Id is not in our database. Try again.");
            UpdateProfile();
        };
    }
    private static void Updater(Profile profile)
    {
        Console.WriteLine("****");
        Console.WriteLine("PRESS [N] to update name\nPRESS [A] to update age\nPRESS [Y] to update year of birth");
        string userChoice = Console.ReadLine().ToLower();
        if (userChoice == "n")
        {
            Console.Write($"(PRESS Enter Key if you do not want to change FIRST NAME)\nOrginal: {profile.firstName}\nChange to: ");
            string first = Console.ReadLine();
            if (first == "")
            {
                Console.WriteLine("blank[-]");
            }
            else { profile.firstName = first; }
            Console.Write($"(PRESS Enter Key if you do not want to change LAST NAME)\nOrginal: {profile.lastName}\nChange to: ");
            string last = Console.ReadLine();
            if (last == "")
            {
                Console.WriteLine("blank[-]");
            }
            else { profile.lastName = last; }
            Console.WriteLine("Profile Updated Successfully");
            Console.WriteLine(profile);
            SaveProfData();
        }
        else if (userChoice == "a")
        {
            Console.Write($"(PRESS Enter Key if you do not want to change AGE)\nOrginal: {profile.Age}\nChange to: ");
            string age = Console.ReadLine();
            if (age == "")
            {
                Console.WriteLine("blank[-]");
            }
            else { profile.Age = Convert.ToInt32(age); }
            Console.WriteLine("Profile Updated Successfully");
            Console.WriteLine(profile);
            SaveProfData();
        }
        else if (userChoice == "y")
        {
            Console.Write($"(PRESS Enter Key if you do not want to change YEAR OF BIRTH)\nOrginal: {profile.Yob}\nChange to: ");
            string yob = Console.ReadLine();
            if (yob == "")
            {
                Console.WriteLine("blank[-]");
            }
            else { profile.Yob = Convert.ToInt32(yob); }
            Console.WriteLine("Profile Updated Successfully");
            Console.WriteLine(profile);
            SaveProfData();
        }
        else
        {
            Console.WriteLine("Invalid Choice");
            Updater(profile);
        }
    }
    public static void DeleteProfile()
    {
        int userId;
        bool found = true;
        Console.Write("Enter your id: ");
        userId = Convert.ToInt32(Console.ReadLine());
        foreach (Profile profile in profiles)
        {
            if (profile.Id == userId)
            {
                Console.WriteLine("Success! Here's your Profile! ");
                Console.WriteLine("-------------");
                Console.WriteLine($"Name: {profile.Name}\nAge: {profile.Age}\nYear of Birth: {profile.Yob}\nID: {profile.Id}\n");
                Console.WriteLine("------------- \n");
                found = true;
                Console.WriteLine("Are you sure you want to Delete it? \n [Y] Yes / [N] No");
                string userChoice = Console.ReadLine().ToLower();
                if (userChoice == "y")
                {
                    profiles.Remove(profile);
                    Console.WriteLine("Profile Deleted Successfully");
                    SaveProfData();
                }
                else
                {
                    Console.WriteLine("Profile not Deleted");
                }
                break;
            }
            else
            {
                found = false;
            }
        }
        if (!found)
        {
            Console.WriteLine("We're Sorry. Your Id is not in our database. Try again.");
            DeleteProfile();
        };
    }
}

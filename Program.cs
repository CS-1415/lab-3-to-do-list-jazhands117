//Jay Johnson 9/08/2025 Lab 3 To Do List//
//this lab allows a user to make/complete a task list via Task class//
//NTS = note to self, for future study//

//NTS: using Ctrl+C to kill program in terminal, figure out how to build a stop loop in?//
//TDD would be good to do here. Try it when you have time//

using System;
using System.Collections.Generic; //allows Lists! thanks, reddit//


//main program//
List<Task> tasks = new List<Task>(); //dynamic array - so cool!//

//making generic task list//
//note the Title, Description format -- ID count is taken care of//
tasks.Add(new Task("Meal prep", "Beef sliders, protein pancakes, and chicken potstickers."));
tasks.Add(new Task("Feed cats", "The fat one is on a diet."));
tasks.Add(new Task("Fix bike (again)", "The carburetor is acting up again."));


//calling menu again and again with user input//
while (true)
{
    Task.DisplayMenu(tasks);

    Console.WriteLine($"\nPlease enter a command:");
    Console.WriteLine($"+ = Add task\ni = View task description\nx = Toggle task completion");

    //options//
    string input = Task.ForcedValid();
    if (input == "i")
    {
        Task.ShowDescription(tasks);
        Console.WriteLine($"Please press ENTER to continue:");
        Console.ReadKey();
    }
    else if (input == "+")
    {
        Task.AddTask(tasks);
    }
    else if (input == "x")
    {
        Task.MarkAsComplete(tasks);
    }
}





//task class//
public class Task
{
    //private to avoid...unsavories//
    private int _id; //I hate it, but I'll use the book's _name format//
    private string _title;
    private string _description;
    private bool _isComplete;
    private static int _countid = 1; //ID counter//

    //constructor (non-generic)//
    public Task(string title, string description)
    {
        _id = _countid++; //increments ID//
        _title = title;
        _description = description;
        _isComplete = false; //defaults to not complete//
    }

    //getters -- the way the book does them//
    public int GetID() => _id;
    public string GetTitle() => _title;
    public string GetDescription() => _description;
    public bool GetIsComplete() => _isComplete;

    //setters -- also the way the book does 'em//
    //ID takes care of itself by incrementing!//
    public void SetTitle(string title) => _title = title;
    public void SetDescription(string description) => _description = description;
    public void SetIsComplete(bool isComplete) => _isComplete = isComplete;

    //display each task//
    public void DisplayTask()
    {
        string checkbox;
        if (_isComplete)
        {
            checkbox = "[X]";
        }
        else
        {
            checkbox = "[ ]";
        }
        Console.WriteLine($"{checkbox}\t{_id}\t{_title}");
    }

    //display task descriptions//
    public void DisplayDescription()
    {
        string status;
        if (_isComplete)
        {
            status = "Complete";
        }
        else
        {
            status = "Incomplete";
        }
        Console.WriteLine($"{_id}\t{_title}: {_description}\nStatus: {status}.");
    }

    //switching between complete and incomplete//
    public void ChangeComplete()
    {
        if (_isComplete)
        {
            _isComplete = false; //switches to incomplete if triggered when complete//
        }
        else
        {
            _isComplete = true; //if markComplete is called, it will auto-complete//
        }
    }

    //menu builder//
    public static void DisplayMenu(List<Task> tasks)
    {
        Console.WriteLine($"ID\tTask\n--------------");
        foreach (Task t in tasks)
        {
            t.DisplayTask();
        }
    }

    //show description//
    public static void ShowDescription(List<Task> tasks)
    {
        Console.WriteLine("Enter task ID for description:");
        int id = ForcedTaskID(tasks); //no wild ints, ID only//
        foreach (Task task in tasks) //can call multiple IDs for desc//
        {
            if (task.GetID() == id) //only prints ID desc called//
            {
                task.DisplayDescription();
            }
        }
    }

    //adding tasks to list//
    public static void AddTask(List<Task> tasks)
    {
        Console.WriteLine("Please enter task title:");
        string title = Console.ReadLine();
        Console.WriteLine("Please enter task description:");
        string desc = Console.ReadLine();

        tasks.Add(new Task(title, desc));
    }

    //marking task as complete//
    public static void MarkAsComplete(List<Task> tasks)
    {
        Console.WriteLine("Enter task ID to toggle completion:");
        int id = ForcedTaskID(tasks);
        foreach (Task task in tasks)
        {
            if (task.GetID() == id)
            {
                task.ChangeComplete();
            }
        }
    }

    //valid menu options//
    public static bool IsValidOption(string input)
    {
        return input == "i" || input == "+" || input == "x";
    }

    //forces valid option//
    public static string ForcedValid()
    {
        while (true)
        {
            string input = Console.ReadLine();
            if (IsValidOption(input))
            {
                return input;
            }
            else
            {
                Console.WriteLine($"Please enter i, +, or x.");
            }
        }
    }

    //forces int option to be a CURRENT ID OPTION//
    //PLEASE NOTE: I did have ChatGPT help me figure this out!!//
    //this section is NOT 100% my work! the 'allDigits' and input.length ideas are Chat's//
    public static int ForcedTaskID(List<Task> tasks)
    {
        while (true)
        {
            string input = Console.ReadLine();

            //checks for digits (like our letter lab)//
            //this foreach is NOT MINE//
            bool allDigits = true;
            foreach (char c in input)
            {
                if (c < '0' || c > '9')
                {
                    allDigits = false;
                }
            }

            if (allDigits && input.Length > 0) //Chat added the input.length, but the rest is mine//
            {
                int id = int.Parse(input);
                foreach (Task task in tasks)
                {
                    if (task.GetID() == id)
                    {
                        return id;
                    }
                }
                Console.WriteLine("Please choose a valid ID.");
            }
            else
            {
                Console.WriteLine($"Please enter a number.");
            }
        }
    }
}


# Lab-3-ToDo-List
ToDo List
General Learning Objectives

Use a modern operating system and utilities.

Use an integrated development environment to develop a program.

Solve problems and develop programs using the control structures of sequence, selection, and repetition, following a disciplined approach.

Helping vs Cheating ( a gentle reminder )

Cheating:

Efforts to have someone receive a grade that inaccurately reflects his or her level of understanding

Examples:

Helping someone fix their code without helping them understand the cause and fix

Using a fix without understanding why/how it works

Environment Setup
Accept the GitHub Classroom Assignment.
Open a terminal.
If you don't have a code directory already:
Run mkdir my-code-dir to make a new directory named 'my-code-dir'.
Navigate to your code directory (hint: cd my-code-dir).
Run git clone {yourUrl} to make a local copy of your repository.
Run code {nameOfYourRepo} to open that directory in VS Code.
Open the integrated terminal in VS Code (Ctrl+`, or the Terminal menu -> New Terminal).
Run dotnet new console to create a new project in the current folder.
Run dotnet build to compile your code.
Run dotnet run to execute your code.
Lab Steps
Create a Task Class with data members for
ID (int)
Title (string)
Description (string)
IsComplete (bool)
Inside of your class make getter/setters for these data members
Create methods inside of your class to handle the necessesary items in your ToDo list including at least:
DisplayTask()
DisplayDescription()
MarkAsCompleted()
In your program's Main method, create a list of "Task"s (whether or not you start off with an empty list or some default tasks is up to you).
Allow the user to create a Task with a title and description. Automatically assign the ID to the next available ID. (hint: this could be as simple as newTaskId = taskList.Count).
Display all Tasks (like the example below).
Prompt the user to either enter i for information on a task, + to add a task, or x to toggle whether or not a task is marked as complete.
When the user presses i the program asks which task number. If the user enters a valid task ID then task's details (including its description, which is not displayed in the task list) are printed to the console. The program then re-displays the list of tasks.
When the user presses + the program asks for a task name and a description; uses those values to create a new Task and adds that to the list of tasks. The program then re-displays the newly-updated list.
When the user presses x the program asks which task number the user wants to toggle. If the user enters a valid task ID that task has its IsComplete field toggled. The program then re-displays the newly-updated list.

Here's an example of what the user might see in the console:

    ID  Task
-----------------------------------
[ ] 1   Get car fixed
[X] 2   Buy groceries
[ ] 3   Paint house

Press "+" to add a task. Press "x" to toggle whether or not the task is complete. Press "i" to view a task's information.

Submission

Make sure you don't forget to commit and push so your code makes it back up to GitHub.

Grading

Grading must be done in person or via Teams with a TA or instructor.

Getting a TA or instructor to sign-off on your lab before you leave is the easiest and best way to get the best grade possible.

Rubric
[
    {"label": "Comment at top of Program.cs giving your name(s), the date, and the name of the lab", "points": 1},
    {"label": "Greeting describing to the user the purpose of the program", "points": 1},
    {"label": "Display all tasks showing the state of IsComplete, the task ID, and the task title", "points": 5},
    {"label": "Allow the user to add tasks with names and descriptions to a list of tasks", "points": 5},
    {"label": "Allow the user to select a specific task and view its information (including description)", "points": 5},
    {"label": "Validate user input.  Invalid input should not crash the program.", "points": 3},
    {"label": "Well-named data types, functions, and variables", "points": 3},
    {"label": "Clean and consistent vertical white space.  Leave one line between functions, leave blank lines between logically grouped blocks of code, etc.", "points": 2},
    {"label": "(2 points bonus) Implement the 'x' command for toggling completion.", "points": 0},
    {"label": "(5 points bonus) Add a Priority field to your struct, add a new key to sort the task list by priority descending.", "points": 0}
]

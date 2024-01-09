// See https://aka.ms/new-console-template for more information
using UI;
using EnrolmentSystem;

using static System.Console;

Console.WriteLine("Welcome to the Student Enrolment System");

EnrolmentSystem.EnrolmentSystem enrolments = new();

Menu mainMenu = new Menu( "", "", "Main Menu",
    new RegistrationMenuItem("1", "Register Student", enrolments.Students ),
    new SecondMenu("2", "Open the second menu", "Second Menu",
        new MenuItem("A", "Option A"),
        new MenuItem("B", "Option B"),
        new MenuItem("C", "Option C"),
        new ExitMenuItem("D", "Go back to previous menu")
    ),
    new ListEnrolledStudents("3", "List Enrolled Students", enrolments.Students),
    new MenuItem("4", "Option 4"),
    new MenuItem("5", "Option 5"),
    new ExitMenuItem("6", "Exit")
);

mainMenu.DoAction();

WriteLine("Farewell! thank you visiting my enrolment system.");
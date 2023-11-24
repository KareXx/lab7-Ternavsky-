using System;
using System.Collections.Generic;
using System.Linq;



namespace lab7._3
{
    class Program
    {
        static void Main()
        {
            TaskScheduler<string, int> scheduler = new TaskScheduler<string, int>(
                task => task.Length,
                task => Console.WriteLine($"Initializing task: {task}"),
                task => Console.WriteLine($"Resetting task: {task}")
            );

            UserInterface userInterface = new UserInterface(scheduler);

            userInterface.Run();
        }
    }
}

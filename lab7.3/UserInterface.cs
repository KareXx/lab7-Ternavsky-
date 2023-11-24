using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7._3
{
    internal class UserInterface
    {
        private readonly TaskScheduler<string, int> taskScheduler;

        public UserInterface(TaskScheduler<string, int> taskScheduler)
        {
            this.taskScheduler = taskScheduler;
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("Enter a command (ExecuteNext, AllTasks, AddTask, Exit):");
                string command = Console.ReadLine();

                switch (command.ToLower())
                {
                    case "executenext":
                        taskScheduler.ExecuteNext(task => Console.WriteLine($"Executed task: {task}"));
                        break;

                    case "alltasks":
                        taskScheduler.AllTasks();
                        break;

                    case "addtask":
                        taskScheduler.AddTaskFromConsole();
                        break;

                    case "exit":
                        return;

                    default:
                        Console.WriteLine("Invalid command. Try again.");
                        break;
                }
            }
        }
    }
}

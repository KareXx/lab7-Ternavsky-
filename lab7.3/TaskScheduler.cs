using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7._3
{
    internal class TaskScheduler<TTask, TPriority>
    {
        private SortedDictionary<TPriority, Queue<TTask>> taskQueue = new SortedDictionary<TPriority, Queue<TTask>>();
        private Func<TTask, TPriority> prioritySelector;
        private Action<TTask> taskInitializer;
        private Action<TTask> taskReset;

        public delegate void TaskExecution(TTask task);

        public TaskScheduler(Func<TTask, TPriority> prioritySelector, Action<TTask> taskInitializer, Action<TTask> taskReset)
        {
            this.prioritySelector = prioritySelector ?? throw new ArgumentNullException(nameof(prioritySelector));
            this.taskInitializer = taskInitializer ?? throw new ArgumentNullException(nameof(taskInitializer));
            this.taskReset = taskReset ?? throw new ArgumentNullException(nameof(taskReset));
        }

        public void AddTask(TTask task)
        {
            TPriority priority = prioritySelector(task);

            if (!taskQueue.TryGetValue(priority, out var priorityQueue))
            {
                priorityQueue = new Queue<TTask>();
                taskQueue[priority] = priorityQueue;
            }

            priorityQueue.Enqueue(task);
        }

        public void ExecuteNext(TaskExecution taskExecution)
        {
            if (taskQueue.Count > 0)
            {
                var highestPriority = taskQueue.Keys.Max();
                var nextTask = taskQueue[highestPriority].Dequeue();

                Console.WriteLine($"Executing task with priority {highestPriority}");
                taskExecution(nextTask);

                if (taskQueue[highestPriority].Count == 0)
                {
                    taskQueue.Remove(highestPriority);
                }
            }
            else
            {
                Console.WriteLine("No tasks to execute.");
            }
        }

        public void AllTasks()
        {
            Console.WriteLine("All tasks:");
            foreach (var priorityQueue in taskQueue.Values)
            {
                foreach (var task in priorityQueue)
                {
                    Console.WriteLine(task);
                }
            }
        }

        public void AddTaskFromConsole()
        {
            Console.WriteLine("Enter a task:");
            var taskInput = Console.ReadLine();
            AddTask((TTask)(object)taskInput);
        }

        public void ReturnToPool(TTask task)
        {
            taskReset(task);
        }
    }

}

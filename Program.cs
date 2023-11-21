using System;
using System.Collections.Generic;
using System.Linq;

enum TaskPriority
{
    Low,
    Medium,
    High
}

class TaskItem
{
    public string TaskName { get; set; }
    public TaskPriority Priority { get; set; }
    public DateTime DueDate { get; set; }
    public string Status { get; set; }
}

class TaskManager
{
    private List<TaskItem> tasks = new List<TaskItem>();

    public void AddTask(string taskName, TaskPriority priority, DateTime dueDate)
    {
        TaskItem newTask = new TaskItem
        {
            TaskName = taskName,
            Priority = priority,
            DueDate = dueDate,
            Status = "Pending"
        };

        tasks.Add(newTask);
        Console.WriteLine("Task added successfully!");
    }

    public void DeleteTask(string taskName)
    {
        TaskItem taskToDelete = tasks.FirstOrDefault(task => task.TaskName.Equals(taskName, StringComparison.OrdinalIgnoreCase));

        if (taskToDelete != null)
        {
            tasks.Remove(taskToDelete);
            Console.WriteLine("Task deleted successfully!");
        }
        else
        {
            Console.WriteLine("Task not found. Deletion failed.");
        }
    }

    public void ViewTasks()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks available.");
        }
        else
        {
            Console.WriteLine("Tasks:");

            foreach (var task in tasks)
            {
                Console.WriteLine($"- Task: {task.TaskName}, Priority: {task.Priority}, Due Date: {task.DueDate}, Status: {task.Status}");
            }
        }
    }
}

class Program
{
    static void Main()
    {
        TaskManager taskManager = new TaskManager();

        while (true)
        {
            Console.WriteLine("\n1. Add Task");
            Console.WriteLine("2. Delete Task");
            Console.WriteLine("3. View Tasks");
            Console.WriteLine("4. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddTask(taskManager);
                    break;
                case "2":
                    DeleteTask(taskManager);
                    break;
                case "3":
                    ViewTasks(taskManager);
                    break;
                case "4":
                    Console.WriteLine("Exiting the application. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void AddTask(TaskManager taskManager)
    {
        Console.Write("Enter the task name: ");
        string taskName = Console.ReadLine();

        Console.Write("Enter the priority (Low/Medium/High): ");
        if (Enum.TryParse(Console.ReadLine(), true, out TaskPriority priority))
        {
            Console.Write("Enter the due date (yyyy-MM-dd): ");
            if (DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out DateTime dueDate))
            {
                taskManager.AddTask(taskName, priority, dueDate);
            }
            else
            {
                Console.WriteLine("Invalid date format. Task not added.");
            }
        }
        else
        {
            Console.WriteLine("Invalid priority. Task not added.");
        }
    }

    static void DeleteTask(TaskManager taskManager)
    {
        Console.Write("Enter the task name to delete: ");
        string taskName = Console.ReadLine();
        taskManager.DeleteTask(taskName);
    }

    static void ViewTasks(TaskManager taskManager)
    {
        taskManager.ViewTasks();
    }
}

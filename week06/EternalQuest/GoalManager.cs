public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void DisplayMenu()
    {
        string input = "";
        while (input != "6")
        {
            Console.WriteLine("\n--- Eternal Quest ---");
            Console.WriteLine($"Score: {_score}\n");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Goal Event");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Quit");
            Console.Write("Select an option: ");
            input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    DisplayGoals();
                    break;
                case "3":
                    RecordGoalEvent();
                    break;
                case "4":
                    SaveGoals("goals.txt");
                    break;
                case "5":
                    LoadGoals("goals.txt");
                    break;
            }
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nGoal Types:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Select a goal type: ");
        string type = Console.ReadLine();

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();

        Console.Write("Enter description: ");
        string desc = Console.ReadLine();

        Console.Write("Enter points: ");
        int points = int.Parse(Console.ReadLine());

        switch (type)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, desc, points));
                break;

            case "2":
                _goals.Add(new EternalGoal(name, desc, points));
                break;

            case "3":
                Console.Write("How many times to complete? ");
                int target = int.Parse(Console.ReadLine());

                Console.Write("Bonus points on completion: ");
                int bonus = int.Parse(Console.ReadLine());

                _goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
                break;
        }

        Console.WriteLine("Goal created successfully!");
    }

    public void DisplayGoals()
    {
        Console.WriteLine("\nYour Goals:");
        int index = 1;
        foreach (var goal in _goals)
        {
            Console.WriteLine($"{index}. {goal.GetStatus()}");
            index++;
        }
        Console.WriteLine($"Total Score: {_score}");
    }

    public void RecordGoalEvent()
    {
        DisplayGoals();
        Console.Write("Enter the number of the goal to mark complete: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < _goals.Count)
        {
            int earned = _goals[index].RecordEvent();
            _score += earned;
            Console.WriteLine($"Event recorded! You earned {earned} points.");
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            foreach (var goal in _goals)
            {
                writer.WriteLine(goal.Serialize());
            }
        }

        Console.WriteLine("Goals saved!");
    }

    public void LoadGoals(string filename)
    {
        if (File.Exists(filename))
        {
            _goals.Clear();
            string[] lines = File.ReadAllLines(filename);
            _score = int.Parse(lines[0]);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split("|");
                string type = parts[0];

                if (type == "Simple")
                {
                    var goal = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]));
                    if (bool.Parse(parts[4]))
                        goal.RecordEvent(); // Mark as complete
                    _goals.Add(goal);
                }
                else if (type == "Eternal")
                {
                    _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
                }
                else if (type == "Checklist")
                {
                    var goal = new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]),
                        int.Parse(parts[4]), int.Parse(parts[6]));
                    for (int count = 0; count < int.Parse(parts[5]); count++)
                        goal.RecordEvent(); // Increment progress
                    _goals.Add(goal);
                }
            }

            Console.WriteLine("Goals loaded!");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}

using System;
using System.Collections.Generic;

// Base class
abstract class Activity
{
    private DateTime _date;
    private int _length; // in minutes

    public Activity(DateTime date, int length)
    {
        _date = date;
        _length = length;
    }

    public DateTime Date => _date;
    public int Length => _length;

    public abstract double GetDistance(); // miles or km depending on implementation
    public abstract double GetSpeed();    // mph or kph
    public abstract double GetPace();     // minutes per mile or km

    public virtual string GetSummary()
    {
        // Format date as "03 Nov 2022"
        string dateString = _date.ToString("dd MMM yyyy");

        // Compose summary string with calculations
        return $"{dateString} {this.GetType().Name} ({_length} min) - Distance: {GetDistance():0.0}, Speed: {GetSpeed():0.0}, Pace: {GetPace():0.00} min per unit";
    }
}

// Derived classes

class Running : Activity
{
    private double _distance; // in miles

    public Running(DateTime date, int length, double distance) : base(date, length)
    {
        _distance = distance;
    }

    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        // Speed = (distance / minutes) * 60
        return (_distance / Length) * 60;
    }

    public override double GetPace()
    {
        // Pace = minutes / distance
        return (double)Length / _distance;
    }
}

class Cycling : Activity
{
    private double _speed; // mph

    public Cycling(DateTime date, int length, double speed) : base(date, length)
    {
        _speed = speed;
    }

    public override double GetDistance()
    {
        // Distance = speed * (length / 60)
        return _speed * (Length / 60.0);
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetPace()
    {
        // Pace = 60 / speed
        return 60 / _speed;
    }
}

class Swimming : Activity
{
    private int _laps;
    private const double LapLengthMeters = 50;

    public Swimming(DateTime date, int length, int laps) : base(date, length)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        // Distance in miles
        // Distance (miles) = laps * 50 / 1000 * 0.62
        return _laps * LapLengthMeters / 1000 * 0.62;
    }

    public override double GetSpeed()
    {
        // Speed = (distance / minutes) * 60
        return (GetDistance() / Length) * 60;
    }

    public override double GetPace()
    {
        // Pace = minutes / distance
        return (double)Length / GetDistance();
    }
}

// Program class to test
class Program
{
    static void Main()
    {
        List<Activity> activities = new List<Activity>();

        // Create activities (use sample data)
        activities.Add(new Running(new DateTime(2022, 11, 3), 30, 3.0)); // 3 miles in 30 min
        activities.Add(new Cycling(new DateTime(2022, 11, 3), 45, 15));  // 15 mph for 45 min
        activities.Add(new Swimming(new DateTime(2022, 11, 3), 60, 40)); // 40 laps in 60 min

        // Display summaries
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}

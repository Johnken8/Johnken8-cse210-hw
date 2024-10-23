using System;
using System.Collections.Generic;

// Base class for all activities
public abstract class Activity
{
    private DateTime _date;
    private int _lengthInMinutes;

    public Activity(DateTime date, int lengthInMinutes)
    {
        _date = date;
        _lengthInMinutes = lengthInMinutes;
    }

    // Virtual methods to be overridden by derived classes
    protected abstract double GetDistance();
    protected abstract double GetSpeed();
    protected abstract double GetPace();

    // Common method that uses the virtual methods - demonstrates polymorphism
    public string GetSummary()
    {
        return $"{_date:dd MMM yyyy} {GetType().Name} ({_lengthInMinutes} min) - " +
               $"Distance {GetDistance():F1} miles, Speed {GetSpeed():F1} mph, " +
               $"Pace: {GetPace():F1} min per mile";
    }

    // Protected getter for length in minutes (needed by derived classes)
    protected int GetLengthInMinutes()
    {
        return _lengthInMinutes;
    }
}

// Running activity class
public class Running : Activity
{
    private double _distance;

    public Running(DateTime date, int lengthInMinutes, double distance) 
        : base(date, lengthInMinutes)
    {
        _distance = distance;
    }

    protected override double GetDistance()
    {
        return _distance;
    }

    protected override double GetSpeed()
    {
        return (_distance / GetLengthInMinutes()) * 60;
    }

    protected override double GetPace()
    {
        return GetLengthInMinutes() / _distance;
    }
}

// Cycling activity class
public class Cycling : Activity
{
    private double _speed;

    public Cycling(DateTime date, int lengthInMinutes, double speed) 
        : base(date, lengthInMinutes)
    {
        _speed = speed;
    }

    protected override double GetDistance()
    {
        return (_speed * GetLengthInMinutes()) / 60;
    }

    protected override double GetSpeed()
    {
        return _speed;
    }

    protected override double GetPace()
    {
        return 60 / _speed;
    }
}

// Swimming activity class
public class Swimming : Activity
{
    private int _laps;
    private const double METERS_PER_LAP = 50;
    private const double METERS_TO_MILES = 0.000621371;

    public Swimming(DateTime date, int lengthInMinutes, int laps) 
        : base(date, lengthInMinutes)
    {
        _laps = laps;
    }

    protected override double GetDistance()
    {
        return _laps * METERS_PER_LAP * METERS_TO_MILES;
    }

    protected override double GetSpeed()
    {
        double distanceInMiles = GetDistance();
        return (distanceInMiles / GetLengthInMinutes()) * 60;
    }

    protected override double GetPace()
    {
        return GetLengthInMinutes() / GetDistance();
    }
}

// Program class to demonstrate the functionality
public class Program
{
    public static void Main()
    {
        // Create a list to store activities
        List<Activity> activities = new List<Activity>
        {
            new Running(
                date: new DateTime(2024, 10, 23),
                lengthInMinutes: 30,
                distance: 3.0
            ),
            new Cycling(
                date: new DateTime(2024, 10, 23),
                lengthInMinutes: 45,
                speed: 15.0
            ),
            new Swimming(
                date: new DateTime(2024, 10, 23),
                lengthInMinutes: 40,
                laps: 20
            )
        };

        // Display summary for each activity using polymorphism
        Console.WriteLine("Exercise Tracking Summary:");
        Console.WriteLine("-------------------------");
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
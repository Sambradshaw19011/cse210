using System;

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override int RecordEvent()
    {
        return GetPoints();
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{GetName()},{GetDescription()},{GetPoints()}";
    }

    public static EternalGoal CreateFromString(string data)
    {
        string[] parts = data.Split(",");

        return new EternalGoal(
            parts[0],
            parts[1],
            int.Parse(parts[2])
        );
    }
}
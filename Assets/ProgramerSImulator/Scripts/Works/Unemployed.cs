using System.Collections.Generic;

public class Unemployed : IWork
{
    public string Title => "Безработный";

    public int GetSalary() => 0;

    public bool TryApply(int experience, List<Course> courses)
    {
        return true;
    }
}

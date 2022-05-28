using System.Collections.Generic;

public class Courier : IWork
{
    public int GetSalary() => 15_000;

    public bool TryApply(int experience, List<ICourse> courses)
    {
        return true;
    }
}
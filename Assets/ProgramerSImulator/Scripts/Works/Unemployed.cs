using System.Collections.Generic;

public class Unemployed : IWork
{
    public int GetSalary() => 0;

    public bool TryApply(int experience, List<ICourse> courses)
    {
        return true;
    }
}

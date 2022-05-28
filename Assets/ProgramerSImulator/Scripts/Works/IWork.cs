using System.Collections.Generic;

public interface IWork
{
    int GetSalary();
    bool TryApply(int experience, List<ICourse> courses);
}

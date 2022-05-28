using System.Collections.Generic;

public interface IWork
{
    string Title { get; }
    int GetSalary();
    bool TryApply(int experience, List<ICourse> courses);
}

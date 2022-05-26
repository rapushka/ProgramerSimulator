public interface IWork
{
    int GetSalary();
}


public class Unemployed : IWork
{
    public int GetSalary() => 0;
}
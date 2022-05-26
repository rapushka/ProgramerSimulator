using System;
using UnityEngine;

public class User : IDisposable
{
    private int _expirience;
    private int _money;
    private int _health;
    private int _satiety;
    private DateTime _currentDate;
    private Timer _timer;
    private IWork _work;

    public const int MaxHealth = 100;
    public const int MinHealth = 0;

    public event Action Updated;
    public event Action Died;

    public User(Timer timer)
    {
        _timer = timer;
        _currentDate = new DateTime(2_000, 1, 1);
        _health = 75;
        _money = 1_000;
        _work = new Unemployed();
        _satiety = 75;

        _timer.Tick += OnTick;
    }

    public void Dispose()
    {
        _timer.Tick -= OnTick;
    }

    public string Expirience => _expirience.ToString();
    public string Money => _money.ToString("c");
    public string Health => _health.ToString();
    public string Satiety => _satiety.ToString();
    public string CurrentDate => _currentDate.ToShortDateString();

    private void OnTick()
    {
        NextDay();

        if (_satiety > 0)
        {
            _satiety--;
        }
        else
        {
            if (_health > 0)
            {
                _health--;
            }
            else
            {
                Died?.Invoke();
            }
        }

        Updated?.Invoke();
    }

    private void NextDay()
    {
        DateTime yesterday = _currentDate;
        _currentDate = yesterday.AddDays(1);
        if (yesterday.Month != _currentDate.Month)
        {
            OnNewMonth();
        }
        if (yesterday.Year != _currentDate.Year)
        {
            OnNewYear();
        }
    }

    private void OnNewMonth()
    {
        _money += _work.GetSalary();
    }

    private void OnNewYear()
    {
        Debug.Log("С новой годой!");
    }
}

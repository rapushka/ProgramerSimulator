using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class User : IDisposable
{
    private int _expirience;
    private int _moneyAmount;
    private int _health;
    private int _satiety;
    private DateTime _currentDate;
    private Timer _timer;
    private IWork _work;
    private List<Course> _courses;

    public const int MaxHealth = 100;
    public const int MinHealth = 0;

    public event Action Updated;
    public event Action Died;

    public User(Timer timer)
    {
        _timer = timer;
        _currentDate = new DateTime(2_000, 1, 1);
        _health = 75;
        _moneyAmount = 1_000;
        _work = new Unemployed();
        _satiety = 75;
        _courses = new List<Course>();

        FillValues();

        _timer.Tick += OnTick;
    }

    public void Dispose()
    {
        _timer.Tick -= OnTick;
    }

    private void FillValues()
    {
        Values = new Dictionary<UserValues, string>()
        {
            { UserValues.Expirience, _expirience.ToString() },
            { UserValues.Money, _moneyAmount.ToString("c") },
            { UserValues.Health, _health.ToString() },
            { UserValues.Satiety, _satiety.ToString() },
            { UserValues.CurrentDate, _currentDate.ToShortDateString() },
            { UserValues.Work, _work.Title },
            { UserValues.Course, _courses.LastOrDefault()?.Title ?? "Нет пройденных курсов"},
        };
    }

    public Dictionary<UserValues, string> Values;

    public void Eat(IFood food)
    {
        if (_moneyAmount < food.Price)
        {
            return;
        }

        _moneyAmount -= food.Price;
        _satiety += food.NutritionalValue;

        Updated?.Invoke();
    }

    public void TryApplyWork(IWork work)
    {
        if (work.TryApply(_expirience, _courses) == false)
        {
            return;
        }

        _work = work;
        Updated?.Invoke();
    }

    public void TakeACourse(Course course)
    {
        if (_courses.Contains(course))
        {
            throw new InvalidOperationException();
        }

        _courses.Add(course);
    }

    private void OnTick()
    {
        NextDay();

        if (_satiety > 0)
        {
            _satiety--;
        }
        else if (_health > 0)
        {
            _health--;
        }
        else
        {
            Died?.Invoke();
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
        _moneyAmount += _work.GetSalary();
    }

    private void OnNewYear()
    {
        Debug.Log("С новой годой!");
    }
}

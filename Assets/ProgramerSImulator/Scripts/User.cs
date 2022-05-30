using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class User : IDisposable
{
    private int _expirience;
    private float _moneyAmount;
    private int _health;
    private int _satiety;
    private DateTime _currentDate;
    private Timer _timer;
    private IWork _work;
    private List<Course> _courses;

    public const int MaxHealth = 100;
    public const int MinHealth = 0;

    public event Action Updated;
    public event Action<string> Died;

    public User(Timer timer)
    {
        _timer = timer;
        _currentDate = new DateTime(2_000, 1, 1);
        _health = 75;
        _moneyAmount = 1_000;
        _work = new Unemployed();
        _satiety = 75;
        _courses = new List<Course>();

        _timer.Tick += OnTick;
    }

    public void Dispose()
    {
        _timer.Tick -= OnTick;
    }

    public string Expirience => _expirience.ToString();
    public string Money => _moneyAmount.ToString("c");
    public string Health => _health.ToString();
    public string Satiety => _satiety.ToString();
    public string CurrentDate => _currentDate.ToShortDateString();
    public string Work => _work.Title;
    public string Course => _courses.LastOrDefault()?.Title
        ?? "Нет пройденных курсов";

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
        if (_moneyAmount < course.Price
            || _courses.Contains(course))
        {
            return;
        }

        _moneyAmount -= course.Price;
        _courses.Add(course);

        Updated?.Invoke();
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
            Died?.Invoke(CurrentDate);
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

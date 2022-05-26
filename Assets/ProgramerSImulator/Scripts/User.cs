using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : IDisposable
{
    private const int StartMoney = 1_000;
    private int _expirience;
    private int _money;
    private int _health;
    private DateTime _currentDate;
    private Timer _timer;

    public const int MaxHealth = 100;
    public const int MinHealth = 0;

    public User(Timer timer)
    {
        _timer = timer;
        _currentDate = new DateTime(2_000, 1, 1);
        _health = MaxHealth;
        _money = StartMoney;

        _timer.Tick += OnTick;
    }
    public void Dispose()
    {
        _timer.Tick -= OnTick;
    }

    public event Action Updated;

    public string Expirience => _expirience.ToString();
    public string Money => _money.ToString("c");
    public string Health => _health.ToString();
    public string CurrentDate => _currentDate.ToShortDateString();

    private void OnTick()
    {
        _currentDate = _currentDate.AddDays(1);
        Updated?.Invoke();
    }
}

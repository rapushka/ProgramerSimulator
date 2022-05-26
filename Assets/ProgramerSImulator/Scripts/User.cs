using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : IDisposable
{
    private Timer _timer;

    public User(Timer timer)
    {
        _timer = timer;
        _currentDate = new DateTime(2_000, 1, 1);

        _timer.Tick += OnTick;
    }
    public void Dispose()
    {
        _timer.Tick -= OnTick;
    }

    private int _expirience;
    private int _money;
    private DateTime _currentDate;

    public event Action Updated;

    public string Expirience => _expirience.ToString();
    public string Money => _money.ToString();
    public string CurrentDate => _currentDate.ToShortDateString();

    private void OnTick()
    {
        _currentDate = _currentDate.AddDays(1);
        Updated?.Invoke();
    }
}

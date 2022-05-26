using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private TMPro.TextMeshProUGUI _date;

    private int _expirience;
    private int _money;
    private System.DateTime _currentDate;

    public int Expirience => _expirience;
    public int Money => _money;

    private void Start()
    {
        _currentDate = new System.DateTime(2_000, 1, 1);
    }

    private void OnEnable()
    {
        _timer.Tick += OnTick;
    }
    private void OnDisable()
    {
        _timer.Tick -= OnTick;
    }

    private void OnTick()
    {
        _currentDate = _currentDate.AddDays(1);
        _date.text = _currentDate.ToShortDateString();
    }
}

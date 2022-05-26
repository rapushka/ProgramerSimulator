using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class UserView : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private TMPro.TextMeshProUGUI _date;

    private User _userModel;

    private void Start()
    {
        _userModel = new User(_timer);

        _userModel.Updated += OnModelUpdated;
    }

    private void OnModelUpdated()
    {
        _date.text = _userModel.CurrentDate; 
    }
}

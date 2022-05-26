using TMPro;
using UnityEngine;

public class UserView : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private TextMeshProUGUI _date;
    [SerializeField] private TextMeshProUGUI _expirience;
    [SerializeField] private TextMeshProUGUI _money;
    [SerializeField] private TextMeshProUGUI _health;

    private User _userModel;

    private void Start()
    {
        _userModel = new User(_timer);

        _userModel.Updated += OnModelUpdated;
    }

    private void OnModelUpdated()
    {
        _date.text = _userModel.CurrentDate;
        _expirience.text = _userModel.Expirience;
        _health.text = _userModel.Health;
        _money.text = _userModel.Money;
    }
}

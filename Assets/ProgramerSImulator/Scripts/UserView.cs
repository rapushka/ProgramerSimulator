using TMPro;
using UnityEngine;

public class UserView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _date;
    [SerializeField] private TextMeshProUGUI _expirience;
    [SerializeField] private TextMeshProUGUI _money;
    [SerializeField] private TextMeshProUGUI _health;
    [SerializeField] private TextMeshProUGUI _satiety;

    private User _userModel;

    public void Construct(User model)
    {
        _userModel = model;

        _userModel.Updated += OnModelUpdated;
    }
    private void OnDestroy()
    {
        _userModel.Updated -= OnModelUpdated;
    }

    public User UserModel => _userModel;

    private void OnModelUpdated()
    {
        _date.text = _userModel.CurrentDate;
        _expirience.text = _userModel.Expirience;
        _health.text = _userModel.Health;
        _money.text = _userModel.Money;
        _satiety.text = _userModel.Satiety;
    }
}

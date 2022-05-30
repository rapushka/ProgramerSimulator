using TMPro;
using UnityEngine;

public class UserView : MonoBehaviour
{
    [SerializeField] private PanelView _date;
    [SerializeField] private PanelView _expirience;
    [SerializeField] private PanelView _health;
    [SerializeField] private PanelView _money;
    [SerializeField] private PanelView _satiety;
    [SerializeField] private PanelView _work;
    [SerializeField] private PanelView _courses;

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
        _date.Value.text = _userModel.CurrentDate;
        _expirience.Value.text = _userModel.Expirience;
        _health.Value.text = _userModel.Health;
        _money.Value.text = _userModel.Money;
        _satiety.Value.text = _userModel.Satiety;
        _work.Value.text = _userModel.Work;
        _courses.Value.text = _userModel.Course;
    }
}

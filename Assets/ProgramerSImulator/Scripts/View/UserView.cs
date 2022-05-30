using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UserView : MonoBehaviour
{
    [SerializeField] private Dossier _dossier;

    private User _userModel;
    private List<Page> _pages;

    public void Construct(User model, List<Page> pages)
    {
        _userModel = model;
        _pages = pages;

        _userModel.Updated += OnModelUpdated;
    }
    private void OnDestroy()
    {
        _userModel.Updated -= OnModelUpdated;
    }

    public User UserModel => _userModel;

    private void OnModelUpdated()
    {
        _pages.ForEach((p) => p.UpdateView());
    }
}

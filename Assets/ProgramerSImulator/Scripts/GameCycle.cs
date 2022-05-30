using System;
using TMPro;
using UnityEngine;

public class GameCycle : IDisposable
{
    private User _user;
    private GameObject _gameOverScreen;
    private TextMeshProUGUI _deathDate;

    public GameCycle(User user, GameObject gameOverScreen)
    {
        _user = user;
        _gameOverScreen = gameOverScreen;
        _deathDate = _gameOverScreen
            .GetComponentInChildren<DeathDateHolder>()
            .GetComponent<TextMeshProUGUI>();

        _gameOverScreen.SetActive(false);
        _user.Died += OnDied;
    }
    public void Dispose()
    {
        _user.Died -= OnDied;
    }

    private void OnDied(string date)
    {
        _deathDate.text += date;
        _gameOverScreen.SetActive(true);
        Debug.Log("Game over");
        Time.timeScale = 0;
    }
}

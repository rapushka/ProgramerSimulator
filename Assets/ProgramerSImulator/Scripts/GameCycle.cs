using System;
using UnityEngine;

public class GameCycle : IDisposable
{
    private User _user;
    private GameObject _gameOverScreen;

    public GameCycle(User user, GameObject gameOverScreen)
    {
        _user = user;
        _gameOverScreen = gameOverScreen;

        _user.Died += OnDied;
    }
    public void Dispose()
    {
        _user.Died -= OnDied;
    }

    private void OnDied()
    {
        _gameOverScreen.SetActive(true);
        Debug.Log("Game over");
        Time.timeScale = 0;
    }
}

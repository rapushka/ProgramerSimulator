using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(UserView))]
[RequireComponent(typeof(Timer))]
public class CompositeRoot : MonoBehaviour
{
    [SerializeField] private FoodShop _foodShop;
    [SerializeField] private HR _hr;
    [Space]
    [SerializeField] private GameObject _gameOverScreen;

    private void Start()
    {
        UserView userView = GetComponent<UserView>();
        Timer timer = GetComponent<Timer>();

        User user = new User(timer);
        GameCycle gameCycle = new GameCycle(user, _gameOverScreen);

        _foodShop.Construct(user);
        _hr.Construct(user);
        userView.Construct(user);
        timer.Construct();
    }
}

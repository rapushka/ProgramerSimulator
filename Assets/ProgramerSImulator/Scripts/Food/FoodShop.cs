using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodShop : MonoBehaviour
{
    private User _user;

    public void Construct(User user)
    {
        _user = user;
    }

    public void BuyShaurma()
    {
        _user.Eat(new Shaurma());
    }

    public void EatInMcDonalds()
    {
        _user.Eat(new McDonalds());
    }

    public void BuySushi()
    {
        _user.Eat(new Sushi());
    }
}

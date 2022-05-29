using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodShop : UserUpgrader
{
    public void EatShaurma()
    {
        User.Eat(new Shaurma());
    }

    public void EatInMcDonalds()
    {
        User.Eat(new McDonalds());
    }

    public void EatSushi()
    {
        User.Eat(new Sushi());
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodShop : UserUpgrader<Food>
{
    protected override void Use(Food food)
    {
        User.Eat(food);
    }
}
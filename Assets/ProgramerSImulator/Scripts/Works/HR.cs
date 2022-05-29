using UnityEngine;

public class HR : UserUpgrader
{
    public void Quit()
    {
        User.TryApplyWork(new Unemployed());
    }

    public void TryApplyCourier()
    {
        User.TryApplyWork(new Courier());
    }
}

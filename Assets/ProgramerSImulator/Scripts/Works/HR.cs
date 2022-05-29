using UnityEngine;

public class HR : MonoBehaviour
{
    private User _user;

    public void Construct(User user)
    {
        _user = user;
    }

    public void Quit()
    {
        _user.TryApplyWork(new Unemployed());
    }

    public void TryApplyCourier()
    {
        _user.TryApplyWork(new Courier());
    }
}

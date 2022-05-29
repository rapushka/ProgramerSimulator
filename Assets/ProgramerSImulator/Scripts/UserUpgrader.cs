using UnityEngine;

public abstract class UserUpgrader : MonoBehaviour
{
    private User _user;

    protected User User => _user;

    public void Construct(User user)
    {
        _user = user;
    }
}

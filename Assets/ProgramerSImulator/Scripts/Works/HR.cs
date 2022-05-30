using System;

public class HR : UserUpgrader<Work>
{
    protected override void Use(Work work)
    {
        User.TryApplyWork(work);
    }
}

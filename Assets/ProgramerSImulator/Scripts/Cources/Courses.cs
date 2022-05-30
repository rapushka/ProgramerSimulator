using System.Collections.Generic;
using UnityEngine;

public class Courses : UserUpgrader<Course>
{
    protected override void Use(Course course)
    {
        User.TakeACourse(course);
    }
}

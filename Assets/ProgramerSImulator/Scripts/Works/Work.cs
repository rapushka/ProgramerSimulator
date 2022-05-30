using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Work", menuName = "SO/New Work")]
public class Work : ScriptableObject, IVariant
{
    [SerializeField] private string _title;
    [SerializeField] private float _salary;
    [SerializeField] private int _requiredExpirience;
    [SerializeField] private List<Course> _requiredCourses;

    public string Title => _title;
    public float Salary => _salary;

    public string LeftValue => _title;
    public string RightValue => $"{_salary.ToString("c")} / м.";

    public bool TryApply(int expirience, List<Course> courses)
    {
        bool passedRequiredCourses = true;

        foreach (Course requiredCourse in _requiredCourses)
        {
            if (courses.Contains(requiredCourse) == false)
            {
                passedRequiredCourses = false;
                break;
            }
        }

        return expirience >= _requiredExpirience
            && passedRequiredCourses;
    }
}

using System.Collections.Generic;
using UnityEngine;

public class Courses : UserUpgrader
{
    [SerializeField] private VariantView _variantView;
    [SerializeField] private List<Course> _courses;

    private ContentContainer _container;

    private void OnValidate()
    {
        _container = GetComponentInChildren<ContentContainer>();
        if (_container is null)
        {
            throw new System.Exception($"{nameof(Courses)} need to have a {nameof(ContentContainer)}");
        }
    }

    private void Start()
    {
        foreach (Course course in _courses)
        {
            var variant = Instantiate(_variantView, _container.transform);
            variant.Construct(course);
        }
    }
}

using System.Collections.Generic;
using UnityEngine;

public class Courses : UserUpgrader
{
    [SerializeField] private VariantView _variantView;
    [SerializeField] private List<Course> _courses;

    private ContentContainer _container;
    
    private void Awake()
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
            VariantView variant = Instantiate(_variantView, _container.transform);
            variant.Construct(course);
            variant.Click += OnClick;
        }
    }

    private void OnDestroy()
    {
        foreach (var variant in _container.GetComponentsInChildren<VariantView>())
        {
            variant.Click -= OnClick;
        }
    }

    private void OnClick(IVariant variant)
    {
        if (variant is Course course)
        {
            User.TakeACourse(course);
        }
        else
        {
            throw new System.Exception();
        }
    }
}

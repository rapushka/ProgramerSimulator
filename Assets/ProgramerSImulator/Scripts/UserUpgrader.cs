using System.Collections.Generic;
using UnityEngine;

public abstract class UserUpgrader<T> : MonoBehaviour
    where T : IVariant
{
    [SerializeField] private VariantView _variantView;
    [SerializeField] private List<T> _entries;

    private User _user;
    private ContentContainer _container;

    protected User User => _user;

    public void Construct(User user)
    {
        _user = user;
    }

    private void Start()
    {
        _container = GetComponentInChildren<ContentContainer>();
        if (_container is null)
        {
            throw new System.Exception($"{nameof(T)} need to have a {nameof(ContentContainer)}");
        }

        foreach (T entry in _entries)
        {
            VariantView variant = Instantiate(_variantView, _container.transform);
            variant.Construct(entry);
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
        if (variant is T t)
        {
            Use(t);
        } 
        else
        {
            throw new System.Exception();
        }
    }

    protected abstract void Use(T t);
}

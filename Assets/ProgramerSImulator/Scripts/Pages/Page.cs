using System;
using System.Collections.Generic;
using UnityEngine;

public class Page : MonoBehaviour
{
    [SerializeField] private PanelView _template;
    [SerializeField] protected List<PanelBuilder> _builders;

    protected List<PanelView> _panelViews;
    private User _user;

    private void Start()
    {
        _panelViews = new List<PanelView>();

        foreach (PanelBuilder builder in _builders)
        {
            PanelView panelView = Instantiate(_template, transform);
            panelView.Construct(builder.Title, builder.Source);

            _panelViews.Add(panelView);
        }
    }

    public virtual void Construct(User user)
    {
        _user = user;
    }

    public void UpdateView()
    {
        foreach (PanelView panel in _panelViews)
        {
            panel.Value = _user.Values[panel.Source];
        }
    }

    [Serializable]
    protected class PanelBuilder
    {
        [SerializeField] private string _title;
        [SerializeField] private UserValues _source;

        public string Title => _title;
        public UserValues Source => _source;
    }
}

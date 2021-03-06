using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PanelView : MonoBehaviour
{
    [SerializeField] private string _headerText;
    [SerializeField] private TextMeshProUGUI _header;
    [SerializeField] private TextMeshProUGUI _value;
    [Space]
    [SerializeField] private GameObject _window;

    public TextMeshProUGUI Value => _value;

    private void OnValidate()
    {
        _header.text = _headerText;
    }

    private void Start()
    {
        if (_window == null)
        {
            return;
        }
        var button = GetComponent<Button>();
        button.enabled = true;

        button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        _window.SetActive(true);
    }
}

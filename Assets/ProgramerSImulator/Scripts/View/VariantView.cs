using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

[RequireComponent(typeof(Button))]
public class VariantView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _leftValue;
    [SerializeField] private TextMeshProUGUI _rightValue;

    private IVariant _variant;
    private Button _button;

    public void Construct(IVariant variant)
    {
        _variant = variant;

        _leftValue.text = _variant.LeftValue;
        _rightValue.text = _variant.RightValue;
    }

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(() => Click?.Invoke(_variant));
    }

    public event Action<IVariant> Click;

    public IVariant Variant => _variant;
}
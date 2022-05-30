using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class VariantView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _leftValue;
    [SerializeField] private TextMeshProUGUI _rightValue;

    private IVariant _variant;

    public void Construct(IVariant variant)
    {
        _variant = variant;

        _leftValue.text = _variant.LeftValue;
        _rightValue.text = _variant.RightValue;
    }

    public IVariant Variant => _variant;

    public void OnClick()
    {

    }
}
using UnityEngine;
using TMPro;

public class VariantView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _leftValue;
    [SerializeField] private TextMeshProUGUI _rightValue;

    public void Construct(IVariant variant)
    {
        _leftValue.text = variant.LeftValue;
        _rightValue.text = variant.RightValue;
    }
}
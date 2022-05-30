using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PanelView : MonoBehaviour
{
    [SerializeField] private string _headerText;
    [SerializeField] private TextMeshProUGUI _header;
    [SerializeField] private TextMeshProUGUI _value;

    public TextMeshProUGUI Value => _value;

    private void OnValidate()
    {
        _header.text = _headerText;
    }
}

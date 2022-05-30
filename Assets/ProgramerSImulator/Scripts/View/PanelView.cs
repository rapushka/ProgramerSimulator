using TMPro;
using UnityEngine;

public class PanelView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _header;
    [SerializeField] private TextMeshProUGUI _value;

    private UserValues _source;

    public void Construct(string header, UserValues source)
    {
        _header.text = header;
        _source = source;
    }

    public UserValues Source => _source;
    public string Value
    {
        set => _value.text = value;
    }
}

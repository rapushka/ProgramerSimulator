using UnityEngine;

[CreateAssetMenu(fileName = "New Course", menuName = "SO/New Course")]
public class Course : ScriptableObject, IVariant
{
    [SerializeField] private float _price;
    [SerializeField] private string _title;

    public string Title => _title;
    public float Price => _price;

    public string LeftValue => _title;
    public string RightValue => _price.ToString("c");
}

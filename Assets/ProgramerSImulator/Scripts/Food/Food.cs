using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

[CreateAssetMenu(fileName = "New Food", menuName = "SO/New Food")]
public class Food : ScriptableObject, IVariant
{
    [SerializeField] private string _title;
    [SerializeField] private float _price;
    [Tooltip("Пищевая ценность")]
    [SerializeField] private int _nutritionalValue;

    public string Title => _title;
    public float Price => _price;
    public int NutritionalValue => _nutritionalValue;

    public string LeftValue => _title;
    public string RightValue => _price.ToString("c");
}
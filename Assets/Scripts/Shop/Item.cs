using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item", order = 66)]
public class Item : ScriptableObject
{
    [field: SerializeField] public int Id { get; private set; }
    [field: SerializeField] public Sprite Icon { get; private set; }
    [field: SerializeField] public Sprite ActualSprite { get; private set; }
    [field: SerializeField] public int Price { get; private set; }
    [field: SerializeField] public float xPosition { get; private set; }
    [field: SerializeField] public float yPosition { get; private set; }
    [field: SerializeField] public float xScale { get; private set; }
    [field: SerializeField] public float yScale { get; private set; }
    [field: SerializeField] public TYPE Type { get; private set; }
    public enum TYPE
    {
        SKIN,
        HAT,
        GLASSES,
        MOUSTACHE,
        COLOR
    }
}
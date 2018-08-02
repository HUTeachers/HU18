using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum KeyEnum
{
    None,
    Blue,
    Red,
    Green,
    Yellow
} //They are all made out of ticky tacky and they all look just the same!

[CreateAssetMenu(fileName = "LootItem", menuName = "Frignis/LootItem")]
public class LootItem : ScriptableObject {
    [SerializeField]
    public Sprite InGameSprite = null;
    [SerializeField]
    public Color InGameColor = Color.white;
    [SerializeField]
    public KeyEnum key = KeyEnum.None;


}

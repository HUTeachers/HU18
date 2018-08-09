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
public class LootItem : ScriptableObject, IComparer<LootItem> {
    [SerializeField]
    public Sprite InGameSprite = null;
    [SerializeField]
    public Color InGameColor = Color.white;
    [SerializeField]
    public KeyEnum key = KeyEnum.None;

    public int Compare(LootItem x, LootItem y)
    {
        if (x.InGameSprite == y.InGameSprite || x.InGameColor == y.InGameColor)
        {
            return 0;
        }
        else
        {
            int returnvalue = (int)((x.InGameColor.r - y.InGameColor.r) + (x.InGameColor.g - y.InGameColor.g) + (x.InGameColor.b - y.InGameColor.b)) * 255;
            return returnvalue;
        }
    }
}

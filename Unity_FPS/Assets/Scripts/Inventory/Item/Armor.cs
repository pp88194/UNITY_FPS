using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ArmorType
{
    shoes,
    lowerBody,
    upperBody,
    hat
}
[CreateAssetMenu(fileName = "Armor", menuName = "Item/Item_Armor", order = 1)]
public class Armor : ItemData
{
    public int armorId;
    public int desense;
    public ArmorType type;
}

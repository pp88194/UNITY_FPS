using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    bow,
    sword
}
[CreateAssetMenu(fileName = "Weapon", menuName = "Item/Item_Weapon", order = 1)]
public class Weapon : ItemData
{
    public int weaponId;
    public int offense;
    public WeaponType type;
}

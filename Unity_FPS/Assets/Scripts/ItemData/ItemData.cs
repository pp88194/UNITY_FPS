using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemData : ScriptableObject
{
    public int id;
    public string itemName;
    public int maxAmount;
    public Sprite icon;
}

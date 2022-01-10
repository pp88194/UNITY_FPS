using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitData : ScriptableObject
{
    [SerializeField] string unitName;
    [SerializeField] int maxHp;
    public abstract Unit CreateUnit();
}
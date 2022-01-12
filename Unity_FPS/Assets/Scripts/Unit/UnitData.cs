using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitData : ScriptableObject
{
    public string UnitName => unitName;

    public Stat UnitStat => stat;
    [SerializeField] string unitName;
    [SerializeField] Stat stat;
    //public abstract Unit CreateUnit();
}

[System.Serializable]
public struct Stat
{
    public int MaxHp => _MaxHp;
    public int STR => _STR;
    public int INT => _INT;
    public int WIS => _WIS;
    public int DEX => _DEX;
    public int CHA => _CHA;
    public int CON => _CON;

    [SerializeField] int _MaxHp; //최대체력
    [SerializeField] int _STR; //힘
    [SerializeField] int _INT; //지능
    [SerializeField] int _WIS; //지혜
    [SerializeField] int _DEX; //민첩
    [SerializeField] int _CHA; //매력
    [SerializeField] int _CON; //건강
}
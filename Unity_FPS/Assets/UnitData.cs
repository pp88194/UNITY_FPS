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
    public int STR => _STR;
    public int INT => _INT;
    public int WIS => _WIS;
    public int DEX => _DEX;
    public int CHA => _CHA;
    public int CON => _CON;

    [SerializeField] int _STR; //Èû
    [SerializeField] int _INT; //Áö´É
    [SerializeField] int _WIS; //ÁöÇı
    [SerializeField] int _DEX; //¹ÎÃ¸
    [SerializeField] int _CHA; //¸Å·Â
    [SerializeField] int _CON; //°Ç°­
}
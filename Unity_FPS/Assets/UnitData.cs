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

    [SerializeField] int _STR; //��
    [SerializeField] int _INT; //����
    [SerializeField] int _WIS; //����
    [SerializeField] int _DEX; //��ø
    [SerializeField] int _CHA; //�ŷ�
    [SerializeField] int _CON; //�ǰ�
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    public UnitData Data => data;
    protected UnitData data;

    [SerializeField] int hp;
    public int Hp
    {
        get 
        {
            return hp; 
        }
        set
        {
            hp = Mathf.Clamp(value, 0, 199);
        }
    }
    /// <summary>
    /// 피격당했을 때 호출
    /// </summary>
    public virtual void Hit(int value)
    {
        Hp -= value;
        if (Hp <= 0) Dead();
    }
    /// <summary>
    /// 죽을 데미지를 입었을때 호출
    /// </summary>
    protected abstract void Dead();
}

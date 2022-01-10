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
    /// �ǰݴ����� �� ȣ��
    /// </summary>
    public virtual void Hit(int value)
    {
        Hp -= value;
        if (Hp <= 0) Dead();
    }
    /// <summary>
    /// ���� �������� �Ծ����� ȣ��
    /// </summary>
    protected abstract void Dead();
}

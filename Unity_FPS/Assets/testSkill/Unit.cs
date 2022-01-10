using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    protected float moveSpeed;

    [SerializeField] float hp;
    public float Hp
    {
        get 
        {
            return hp; 
        }
        set
        {
            if (value <= 0)
                Dead();
            else if (value < hp)
                Hit();
        }
    }
    /// <summary>
    /// �ǰݴ����� �� ȣ��
    /// </summary>
    protected abstract void Hit();
    /// <summary>
    /// ���� �������� �Ծ����� ȣ��
    /// </summary>
    protected abstract void Dead();
}

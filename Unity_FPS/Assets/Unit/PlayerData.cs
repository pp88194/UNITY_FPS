using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum JobType
{
    Warrior,//����
    Archer,//�ü�
    Thief //����
}
[CreateAssetMenu(menuName = "UnitData/PlayerData")]
public class PlayerData : UnitData
{
    public JobType jobType => _jobType;
    [SerializeField] JobType _jobType;
}
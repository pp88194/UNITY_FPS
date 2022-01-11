using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum JobType
{
    Warrior,//전사
    Archer,//궁수
    Thief //도적
}
[CreateAssetMenu(menuName = "UnitData/PlayerData")]
public class PlayerData : UnitData
{
    public JobType jobType => _jobType;
    [SerializeField] JobType _jobType;
}
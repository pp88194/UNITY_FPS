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
    //private void Awake()
    //{
    //    switch(jobType)
    //    {
    //        case JobType.Warrior:
    //            PlayerJob = new Warrior(UnitStat);
    //            break;
    //        case JobType.Archer:
    //            PlayerJob = new Archer(UnitStat);
    //            break;
    //        case JobType.Thief:
    //            PlayerJob = new Thief(UnitStat);
    //            break;
    //    }
    //}
    //public override Unit CreateUnit()
    //{
    //    switch (jobType)
    //    {
    //        case JobType.Warrior:
    //            PlayerJob = new Warrior(UnitStat);
    //            Debug.Log("555");
    //            break;
    //        case JobType.Archer:
    //            PlayerJob = new Archer(UnitStat);
    //            break;
    //        case JobType.Thief:
    //            PlayerJob = new Thief(UnitStat);
    //            break;
    //    }
    //}
}
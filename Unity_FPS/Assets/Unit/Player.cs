using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CameraController), typeof(Movement))]
public class Player : Unit
{
    public PlayerData playerData => _playerData;
    [SerializeField] PlayerData _playerData;

    public Job PlayerJob { get; private set; }
    private void Awake()
    {
        data = _playerData;
        switch (playerData.jobType)
        {
            case JobType.Warrior:
                PlayerJob = new Warrior(playerData.UnitStat);
                break;
            case JobType.Archer:
                PlayerJob = new Archer(playerData.UnitStat);
                break;
            case JobType.Thief:
                PlayerJob = new Thief(playerData.UnitStat);
                break;
        }
        Debug.Log(PlayerJob.AttackDamage());
    }

    protected override void Dead()
    {

    }
}

public abstract class Job
{
    protected Stat stat;
    public Job(Stat _stat) => stat = _stat;

    /// <summary>
    /// 직업에 맞는 스탯에 따라 공격 데미지 산출
    /// </summary>
    /// <returns>공격데미지</returns>
    public abstract int AttackDamage();
    /// <summary>
    /// 직업에 맞는 스탯에 따라 최대체력 산출
    /// </summary>
    /// <returns>최대체력</returns>
    public abstract int MaxHp();
    /// <summary>
    /// 스탯에 따라 체력재생량 산출
    /// </summary>
    /// <returns>초당 체력재생량</returns>
    public abstract int HpRegen(); //초당 체력재생량
}
/// <summary>
/// STR(힘)을 주 스탯으로 하는 근접 클래스
/// </summary>
public class Warrior : Job
{
    public Warrior(Stat _stat) : base(_stat) { }
    public override int AttackDamage() => stat.STR * 4;
    public override int MaxHp() => stat.CON * 100;
    public override int HpRegen() => stat.CON;
}
/// <summary>
/// Dex와Wis를 주 스탯으로 하는 원거리 클래스
/// </summary>
public class Archer : Job
{
    public Archer(Stat _stat) : base(_stat) { }
    public override int AttackDamage()
    {
        return 109;
    }
    public override int MaxHp() => 100;
    public override int HpRegen() => 3;
}
/// <summary>
/// Wis와 Dex를 주 스탯으로 하는 근거리 클래스
/// </summary>
public class Thief : Job
{
    public Thief(Stat _stat) : base(_stat) { }
    public override int AttackDamage()
    {
        return 109;
    }
    public override int MaxHp() => 100;
    public override int HpRegen() => 3;
}
//int와 Wis를 주 스탯으로 하는 클래스
public class Sorcerer : Job
{
    public Sorcerer(Stat _stat) : base(_stat) { }
    public override int AttackDamage()
    {
        return 109;
    }
    public override int MaxHp() => 100;
    public override int HpRegen() => 3;
}
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
    /// ������ �´� ���ȿ� ���� ���� ������ ����
    /// </summary>
    /// <returns>���ݵ�����</returns>
    public abstract int AttackDamage();
    /// <summary>
    /// ������ �´� ���ȿ� ���� �ִ�ü�� ����
    /// </summary>
    /// <returns>�ִ�ü��</returns>
    public abstract int MaxHp();
    /// <summary>
    /// ���ȿ� ���� ü������� ����
    /// </summary>
    /// <returns>�ʴ� ü�������</returns>
    public abstract int HpRegen(); //�ʴ� ü�������
}
/// <summary>
/// STR(��)�� �� �������� �ϴ� ���� Ŭ����
/// </summary>
public class Warrior : Job
{
    public Warrior(Stat _stat) : base(_stat) { }
    public override int AttackDamage() => stat.STR * 4;
    public override int MaxHp() => stat.CON * 100;
    public override int HpRegen() => stat.CON;
}
/// <summary>
/// Dex��Wis�� �� �������� �ϴ� ���Ÿ� Ŭ����
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
/// Wis�� Dex�� �� �������� �ϴ� �ٰŸ� Ŭ����
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
//int�� Wis�� �� �������� �ϴ� Ŭ����
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
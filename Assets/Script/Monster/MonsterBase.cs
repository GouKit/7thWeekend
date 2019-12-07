using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBase : MonoBehaviour
{
    public Monster monster;

    [SerializeField]
    public int power; //몬스터 전투력

    [SerializeField]
    public int hp; //몬스터 체력

    [SerializeField]
    private int exp; //몬스터 경험치
    public int Exp => exp;

    [SerializeField]
    private int gold; //보상골드
    public int Gold => gold;

    [SerializeField]
    private int possibility; //공략 가능성
    public int Possibility => possibility;

    [SerializeField]
    private float time; //공략 시간
    public float Time => time;

    [SerializeField]
    private float exitTime; // 몬스터 소멸 시간
    public float ExitTIme => exitTime;

    private void Start()
    {
        hp = monster.Hp;
        power = monster.Power;
        exp = monster.Exp;
        gold = monster.Gold;
        possibility = monster.Possibility;
        time = monster.Time;
        exitTime = monster.ExitTIme;
    }
}

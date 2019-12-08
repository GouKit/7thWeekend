using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBase : MonoBehaviour
{
    public Monster monster;

    [HideInInspector]
    public int power; //몬스터 전투력

    [HideInInspector]
    public int hp; //몬스터 체력

    private void Start()
    {
        hp = monster.Hp;
        power = monster.Power;
    }
}

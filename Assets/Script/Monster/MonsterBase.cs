﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBase : MonoBehaviour
{
    public Monster monster;

    [HideInInspector]
    public int power; //몬스터 전투력

    [HideInInspector]
    public int hp; //몬스터 체력

    public int Exp => monster.Exp;

    public int Gold => monster.Gold;

    public int Possibility => monster.Possibility;

    public float Time => monster.Time;

    public float ExitTIme => monster.ExitTIme;

    private void Start()
    {
        hp = monster.Hp;
        power = monster.Power;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Monster Templete", menuName = "Monsters")]
public class Monster : ScriptableObject
{
    [SerializeField]
    private Sprite image; //몬스터 이미지
    public Sprite Image => image;

    [SerializeField]
    private new string name; //몬스터 이름 
    public string Name => name;

    [SerializeField]
    private int power; //몬스터 전투력
    public int Power => power;

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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Monster Templete", menuName = "Monsters")]
public class Monster : ScriptableObject
{
    public Sprite image; //몬스터 이미지
    public new string name; //몬스터 이름 
    public int power; //몬스터 전투력
    public int exp; //몬스터 경험치
    public int gold; //보상골드
    public int possibility; //공략 가능성
    public float time; //공략 시간
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerType
{
    public enum Player_Type
    {
        WARRIOR,
        MAGICIAN,
        ARCHER,
        THIEF,
        PRIEST
    }    
}

[CreateAssetMenu(fileName = "Player Templete", menuName = "Players")]
public class Player : ScriptableObject
{
    public Sprite image; //병사 이미지
    public PlayerType.Player_Type type; //병사의 클래스
    public RuntimeAnimatorController animator;
    public new string name; //병사 이름 
    public string rank; //병사 등급
    public int hp; //병사 체력
    public int power; //병사 전투력
    public int level = 1; //병사 레벨 
    public int needExp; //필요 경험치
    public int reinforce; //강화수치
    public int employ; //고용 비용
    public int rewardDown; //보상 감소율
    public int deadPenalty; //사망 비용
    public int nowExp; //현재 경험치
}

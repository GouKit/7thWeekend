using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    public Player player;
    public PlayerType.Player_Type type; //병사의 클래스
    public new string name; //병사 이름 
    public string rank; //병사 등급
    public int hp; //병사 체력
    public int power; //병사 전투력
    private int level; //병사 레벨 
    public int Level 
    { 
        get { return level; } 
        set 
        { 
            level = value;
            if(level >= 30)
                level = 30; 
        } 
    }
    public int needExp; //필요 경험치
    private int reinforce; //강화수치
    public int employ; //고용 비용
    public int rewardDown; //보상 감소율
    public int deadPenalty; //사망 비용

    void Start()
    {
        type = player.type;
        name = player.name;
        rank = player.rank;
        hp = player.hp;
        power = player.power;
        level = player.level;
        needExp = player.needExp;
        reinforce = player.reinforce;
        employ = player.employ;
        rewardDown = player.rewardDown;
        deadPenalty = player.deadPenalty;
    }

    void Upgrade(int level)
    {
        if(type == PlayerType.Player_Type.MAGICIAN)
            power += (level - 1)*reinforce;
        
        if(level < 10)
            hp += reinforce;
        else
            hp += 2 * reinforce;

        if(level < 6)
            needExp = (level + 1) * 50;
        else
            needExp = 300 + (level + 1 - 6) * 100;


        Debug.Log("Lv: " + level + " Hp: " + hp + " NeedExp: " + needExp);
    }

    public void LevelUp()
    {
        Level++;
        Upgrade(Level);
    }

    void OnMouseDown()
    {
        if(Level < 30)
            LevelUp();
    }

}

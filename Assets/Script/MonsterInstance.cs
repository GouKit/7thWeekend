using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterInstance : MonoBehaviour
{
    private MonsterBase monster;
    public List<GameObject> players = new List<GameObject>();
    private List<PlayerBase> deadList = new List<PlayerBase>();
    public int allPower;
    public bool SpendMoney = false;
    private float time = 0;

    void Start()
    {
        monster = GameManager.instance.EM.MonsterList.GetRandomElement().GetComponent<MonsterBase>();
    }

    public void AddPlayer()
    {
        if (players.Count > 4)
            return;

        GameManager.instance.selectObject.SetActive(false);
        players.Add(GameManager.instance.selectObject);
    }

    public void Go()
    {
        allPower = 0;
        for(int i = 0; i < players.Count; i++)
        {
            PlayerBase pb = players[i].GetComponent<PlayerBase>();
            allPower += pb.power;
        }
    }

    void Update()
    {
        time += Time.deltaTime;
        if(monster.Time < time || SpendMoney)
        {
            Result();
            SpendMoney = false;
        }
    }

    public void Express(int need) //빠른 완료
    {
        if(need <= GameManager.instance.crystal)
        {
            GameManager.instance.crystal -= need;
            SpendMoney = true;
        }
    }

    public void Revival() //부활
    {
        for(int i = 0; i < deadList.Count; i++)
        {
            GameManager.instance.crystal -= deadList[i].deadPenalty;
        }
    }

    public void Die() //사망
    {
        for (int i = 0; i < deadList.Count; i++)
        {
            Destroy(deadList[i].gameObject );
        }
    }

    void Result()
    {
        //100- (100+ 몬스터 전투력-캐릭터 체력)		
        for(int i = 0; i < players.Count; i++)
        {
            PlayerBase pb = players[i].GetComponent<PlayerBase>();
            int playerSafe = 100 - (100 + monster.power - pb.hp);
            if(Random.Range(0,100) > playerSafe)
            {
                //사망
                deadList.Add(pb);
            }
        }

        //공략 가능성 * (100+파티 전투력- 몬스터 전투력)
        int possible = monster.Possibility * (100 + allPower - monster.power);
        if(Random.Range(0,100) > possible)
        {
            //실패UI 띄우기

            //현재 체력= 현제체력+ 현재체력 * 0.5 * (몬스터전투력-유저 전투력) / 100	
            monster.hp = (int)(monster.hp + monster.hp * 0.5f * (monster.power - allPower));
            //현재 전투력 = 전투력 /2 *  (1+현재체력/100)		
            monster.power = monster.power / 2 * (1 + monster.hp / 100);
        }
        else
        {
            //성공
            GameManager.instance.gold += monster.Gold;
            for(int i = 0; i < players.Count; i++)
            {
                PlayerBase pb = players[i].GetComponent<PlayerBase>();
                pb.nowExp += monster.Exp;
                if(pb.nowExp >= pb.needExp)
                {
                    pb.LevelUp();
                }
            }
        }
    }

}

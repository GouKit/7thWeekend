using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterInstance : MonoBehaviour
{
    private MonsterBase monster;
    public List<GameObject> players = new List<GameObject>();
    public int allPower;
    public bool SpendMoney = false;
    private float time = 0;

    void Start()
    {
        monster = GameManager.instance.EM.MonsterList.GetRandomElement().GetComponent<MonsterBase>();
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
        }
    }

    void Result()
    {
        //100- (100+ 몬스터 전투력-캐릭터 체력)		
        for(int i = 0; i < players.Count; i++)
        {
            PlayerBase pb = players[i].GetComponent<PlayerBase>();
            int playerSafe = 100 - (100 + monster.Power - pb.hp);
            if(Random.Range(0,100) > playerSafe)
            {
                //사망
                GameManager.instance.crystal -= pb.deadPenalty;
            }
        }

        //공략 가능성 * (100+파티 전투력- 몬스터 전투력)
        int possible = monster.Possibility * (100 + allPower - monster.Power);
        if(Random.Range(0,100) > possible)
        {
            //실패UI 띄우기
        }
        else
        {
            //성공(무기획득 확률)
        }
    }

}

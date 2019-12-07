using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventLoader : MonoBehaviour
{
    private GameObject monster;
    private MonsterBase mb;
    public List<GameObject> players = new List<GameObject>();
    public int allPower;
    public bool SpendMoney = false;
    private float time = 0;

    void Start()
    {
        monster = GameManager.instance.EM.MonsterList[Random.Range(0, GameManager.instance.EM.MonsterList.Count)];
        mb = monster.GetComponent<MonsterBase>();
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
        if(mb.time < time || SpendMoney)
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
            int playerSafe = 100 - (100 + mb.power - pb.hp);
            if(Random.Range(0,100) > playerSafe)
            {
                //플레이어 사망
            }
        }

        //공략 가능성 * (100+파티 전투력- 몬스터 전투력)
        int possible = mb.possibility * (100 + allPower - mb.power);
        if(Random.Range(0,100) > possible)
        {
            //실패
        }
        else
        {
            //성공
        }
    }

}

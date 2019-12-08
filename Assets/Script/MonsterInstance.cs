using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterInstance : MonoBehaviour
{
    public EventPopup popup;
    public LosePopup lose;
    public WinPopup win;
    public GameObject startBtn;
    public Text text;
    private MonsterBase monster;
    public List<Image> slot = new List<Image>();
    public List<GameObject> players = new List<GameObject>();
    public List<GameObject> deadPlayers = new List<GameObject>();
    public int allPower;
    public bool SpendMoney = false;
    private float time = 0;
    bool isStart = false;

    void Start()
    {
        Instantiate(popup).SetEvent(monster, x => PopupOnOff.instance.QuestPopup());
        monster = GameManager.instance.EM.MonsterList.GetRandomElement().GetComponent<MonsterBase>();
        slot[4].sprite = monster.monster.Image;
    }

    public void AddPlayer()
    {
        if (GameManager.instance. selectObject != null && players.Count < 4)
        {
            players.Add(GameManager.instance.selectObject);
            PlayerBase pb = GameManager.instance.selectObject.GetComponent<PlayerBase>();
            slot[players.Count-1].sprite = pb.player.image;
            GameManager.instance.selectObject.SetActive(false);
            startBtn.SetActive(true);
        }
    }

    public void Go()
    {
        allPower = 0;
        for(int i = 0; i < players.Count; i++)
        {
            PlayerBase pb = players[i].GetComponent<PlayerBase>();
            allPower += pb.power;
        }
        isStart = true;
    }

    void Update()
    {
        if(isStart)
        {
            time += Time.deltaTime;
            text.text = time + " / " + monster.Time;
            if(monster.Time < time || SpendMoney)
            {
                Result();
            }
        }
    }

    public void Express(int need)
    {
        if(GameManager.instance.crystal >= need)
        {
            GameManager.instance.crystal -= need;
            SpendMoney = true;
        }
    }
    
    public void PlayerSafty()
    {
        for (int i = 0; i < deadPlayers.Count; i++)
        {
            PlayerBase pb = deadPlayers[i].GetComponent<PlayerBase>();
            GameManager.instance.crystal -= pb.deadPenalty;
        }
    }

    public void Die()
    {
        for(int i = 0; i <deadPlayers.Count; i++)
        {
            Destroy(deadPlayers[i]);
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
                deadPlayers.Add(pb.gameObject);
            }
        }

        //공략 가능성 * (100+파티 전투력- 몬스터 전투력)
        int possible = monster.Possibility * (100 + allPower - monster.power);
        if(Random.Range(0,100) > possible)
        {
            //현재 체력 = 현제체력 + 현재체력 * 0.5 * (몬스터전투력 - 유저 전투력) / 100
            monster.hp = (int)(monster.hp + monster.hp * 0.5f * (monster.power - allPower));
            //현재 전투력 = 전투력 / 2 * (1 + 현재체력 / 100)
            monster.power = monster.power / 2 * (1 + monster.hp / 100);
            //실패UI 띄우기
            Instantiate(lose).SetLoseAction(Die, PlayerSafty);
        }
        else
        {
            //성공(무기획득 확률)
            Instantiate(win).SetRebornAction(Die, PlayerSafty);
            GameManager.instance.gold += monster.Gold;
            for(int i = 0; i < players.Count; i++)
            {
                PlayerBase pb = players[i].GetComponent<PlayerBase>();
                pb.nowExp += monster.Exp;
                if (pb.nowExp >= pb.needExp)
                    pb.LevelUp();
            }
        }
    }

}

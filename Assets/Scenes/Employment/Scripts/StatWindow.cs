using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatWindow : MonoBehaviour
{
    public Text soldierHealth;
    public Text soldierPower;
    public GameObject panel;
    SoldierStat soldierStat;
    SoldierNumber soldierNumber;
    SoldierFactory soldierFactory;
    public GameObject acceptBtn;
    public GameObject cancelBtn;
    public GameObject soldier;
    PlayerBase pb;

    // Start is called before the first frame update
    void Start()
    {
        pb = transform.root.gameObject.GetComponent<PlayerBase>();
        soldier = transform.root.gameObject;
        soldierStat = transform.root.gameObject.GetComponent<SoldierStat>();
        soldierNumber =FindObjectOfType<SoldierNumber>();
        soldierFactory = FindObjectOfType<SoldierFactory>();
        soldierHealth.text = pb.hp + "/" + pb.hp;
        soldierPower.text = pb.power + "/" + pb.power;
    }

    private void Update()
    {
        soldierHealth.text = pb.hp + "/" + pb.hp;
        soldierPower.text = pb.power + "/" + pb.power;
    }

    public void OnClick(string type)
    {
        switch (type)
        {
            case "Accept":
                if (soldierNumber.maxPeopleNum > soldierNumber.curPeopleNum)
                {
                    soldierNumber.curPeopleNum++;
                    soldierFactory.curNum--;
                    soldierStat.isEmployment = true;
                    SoldierMgr.instance.AddSoldier(soldier);
                    //panel.SetActive(false);
                    Destroy(acceptBtn);
                    Destroy(cancelBtn);
                }
                else {}
                break;
            case "Cancel":
                soldierStat.isCancel = true;
                soldierFactory.curNum--;
                Destroy(gameObject);
                break;
        }
    }
    
}

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

    // Start is called before the first frame update
    void Start()
    {
        soldierStat = FindObjectOfType<SoldierStat>();
        soldierNumber = FindObjectOfType<SoldierNumber>();
        soldierFactory = FindObjectOfType<SoldierFactory>();
        soldierHealth.text = soldierStat.health + "/" + soldierStat.health;
        soldierPower.text = soldierStat.power + "/" + soldierStat.power;
    }

    

    public void OnClick(string type)
    {
        switch (type)
        {
            case "Accept":
                if (soldierNumber.maxPeopleNum > soldierNumber.curPeopleNum)
                {
                    soldierNumber.curPeopleNum++;
                    soldierStat.isEmployment = true;
                    panel.SetActive(false);
                    Destroy(acceptBtn);
                    Destroy(cancelBtn);
                    soldierFactory.curNum--;
                    
                }
                else {}
                break;
            case "Cancel":
                soldierStat.isCancel = true;
                soldierFactory.curNum--;
                Destroy(panel);
                break;
        }
    }
    
}

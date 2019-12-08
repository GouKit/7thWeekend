using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValueSetting : MonoBehaviour
{
    public Text Gold;
    public Text Crystal;
    public Text Population;

    // Update is called once per frame
    void Update()
    {
        Gold.text = "" + GameManager.instance.gold;
        Crystal.text = "" + GameManager.instance.crystal;
        Population.text = SoldierMgr.instance.Soldier.Count+"/"+ GameManager.instance.maxPeople;
    }
}

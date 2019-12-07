using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{

    public void OnClick()
    {
        for (int i = 0; i < SoldierMgr.instance.Soldier.Count; i++) 
        {
            PlayerBase pb = SoldierMgr.instance.Soldier[i].GetComponent<PlayerBase>();
            pb.LevelUp();
        }
    }
}

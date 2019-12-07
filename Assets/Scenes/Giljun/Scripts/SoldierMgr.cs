using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierMgr : MonoBehaviour
{
    public List<GameObject> Soldier;

    public static SoldierMgr instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void AddSoldier(GameObject soldier)
    {
        Soldier.Add(soldier);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierNumber : MonoBehaviour
{
    public static SoldierNumber instance;

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
    public int curPeopleNum = 0;
    public int maxPeopleNum = 10;
}

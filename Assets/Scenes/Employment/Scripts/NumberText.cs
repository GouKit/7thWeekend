using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberText : MonoBehaviour
{
    public Text number;
    SoldierNumber soldierNumber;
    // Start is called before the first frame update
    void Start()
    {
        soldierNumber = FindObjectOfType<SoldierNumber>();
        number.text = soldierNumber.curPeopleNum + "/" + soldierNumber.maxPeopleNum;
    }

    // Update is called once per frame
    void Update()
    {
        number.text = soldierNumber.curPeopleNum + "/" + soldierNumber.maxPeopleNum;
    }
}

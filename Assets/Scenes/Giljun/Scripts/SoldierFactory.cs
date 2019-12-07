using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierFactory : MonoBehaviour
{
    public int maxNum;
    public int curNum;
    public GameObject soldier;
    public Player[] type;

    private void Start()
    {
        maxNum = GameManager.instance.maxPeople;
        StartCoroutine(MakeSoldier());
    }

    IEnumerator MakeSoldier()
    {
        while (true)
        {
            if (curNum < maxNum)
            {
                int random = Random.Range(0, type.Length);

                GameObject hello = Instantiate(soldier);
                PlayerBase pb = hello.GetComponent<PlayerBase>();
                pb.player = type[random];
                hello.transform.position = transform.position;
                curNum++;
            }
            yield return new WaitForSeconds(3f);
        }
    }
}

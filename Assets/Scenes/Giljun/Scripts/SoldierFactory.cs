using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierFactory : MonoBehaviour
{
    public int maxNum;
    public int curNum;
    public GameObject soldier;
    // Start is called before the first frame update
    private void OnEnable()
    {
       if(curNum < maxNum)
        {
            StartCoroutine(MakeSoldier());
        }
    }

    private void Update()
    {
              
    }

    IEnumerator MakeSoldier()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            if (maxNum > curNum)
            {
                GameObject hello = Instantiate(soldier);
                hello.transform.position = transform.position;
                curNum++;
            }
            else { }
        }
    }
}

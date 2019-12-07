using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public List<GameObject> MonsterList = new List<GameObject>();
    public Transform questList;
    public GameObject quest;

    private int maxQuest = 4;
    float time = 300, currentTime = 0; 

    private void Start()
    {
        CreateQuest();
    }

    public void CreateQuest()
    {
        //퀘스트 생성 ui 발생
        GameObject em = Instantiate(quest, Vector3.zero, Quaternion.identity);
        em.transform.SetParent(questList);
    }
    
    private void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime >= time)
        {
            CreateQuest();
            currentTime = 0;
        }
    }


}

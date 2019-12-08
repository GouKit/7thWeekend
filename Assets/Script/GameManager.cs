using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public EventManager EM;
    public GameObject selectObject;
    public List<GameObject> MonsterList = new List<GameObject>();

    public int crystal = 300;
    public int gold = 1000;
    public int maxPeople = 10;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        EM = GetComponent<EventManager>();
    }
}

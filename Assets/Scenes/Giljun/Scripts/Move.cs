using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    SoldierStat soldierStat;
    // Start is called before the first frame update
    void Start()
    {

        soldierStat = FindObjectOfType<SoldierStat>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(-2f, 0) * Time.deltaTime);
        if (soldierStat.isEmployment)
        {
            transform.Translate(new Vector2(-2f,0) * Time.deltaTime);
        }
        if (soldierStat.isCancel)
        {
            transform.Translate(new Vector2(2f, 0) * Time.deltaTime);
            Destroy(gameObject, 5f);       
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            transform.Translate(new Vector2(2f, 0) * Time.deltaTime);
        }
        else
        {
            transform.Translate(new Vector2(-2f, 0) * Time.deltaTime);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineUp : MonoBehaviour
{
    public bool isMove = true;
    public float speed = 2f;
    bool flip = false;
    SoldierStat soldierStat;
    BoxCollider2D col;
    // Start is called before the first frame update
    void Start()
    {
        soldierStat = GetComponent<SoldierStat>();
        col = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMove)
        {
            transform.Translate(new Vector2(speed*-1,0) * Time.deltaTime);
        }
        if (soldierStat.isEmployment)
        {
            isMove = false;
            col.isTrigger = true;
            if (!flip)
            {
                transform.Translate(new Vector2(speed * -1, 0) * Time.deltaTime);
            }
            if (flip)
            {
                transform.Translate(new Vector2(speed, 0) * Time.deltaTime);
            }
        }
        if (soldierStat.isCancel)
        {
            isMove = false;
            col.enabled = false;
            transform.Translate(new Vector2(speed, 0) * Time.deltaTime);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player")|| collision.gameObject.CompareTag("House"))
        {
            isMove = false;
        }
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isMove = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Left"))
        {
            Debug.Log(collision.gameObject.name);
            if (flip)
            {
                flip = false;
            }
            else
            {
                flip = true;
            }
        }
    }
}

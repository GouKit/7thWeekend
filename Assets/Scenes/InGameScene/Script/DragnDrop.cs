using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DragnDrop : MonoBehaviour
{

    public List<Transform> slot = new List<Transform>();

    private Vector3 propose;//기존위치

    List<Vector2> llist = new List<Vector2>();
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < slot.Count; i++)
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(slot[i].transform.position);
            pos.x += 3.7f;
            pos.y += 18.3f;
            llist.Add(pos);
            //Debug.Log(pos);
        }
    }

    private void OnMouseDown()
    {
        propose = transform.position;
    }

    private void OnMouseUp()
    {
        for (int i = 0; i < llist.Count; i++)
        {
            float dist = Vector3.Distance(llist[i], transform.position);

            if (dist < 3)
            {
                transform.position = llist[i];
                return;
            }
            else
                transform.position = propose;
        }
    }

    private void OnMouseDrag()
    {
        Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        point.z = gameObject.transform.position.z;
        gameObject.transform.position = point;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DragnDrop : MonoBehaviour
{
    private Vector3 propose;//기존위치

    void Start()
    {
        gameObject.GetComponent<SpriteOutline>().enabled = false;
    }

    private void OnMouseDown()
    {
        propose = transform.position;
        gameObject.GetComponent<SpriteOutline>().enabled = true;
        GameManager.instance.selectObject = gameObject;
    }

    private void OnMouseUp()
    {
        gameObject.GetComponent<SpriteOutline>().enabled = false;
        GameManager.instance.selectObject = null;
    }

    private void OnMouseDrag()
    {
        Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        point.z = gameObject.transform.position.z;
        gameObject.transform.position = point;
    }

}

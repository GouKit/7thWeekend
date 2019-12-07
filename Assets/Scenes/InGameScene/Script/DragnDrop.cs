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
        GameManager.instance.selectObject = gameObject;
        gameObject.GetComponent<SpriteOutline>().enabled = true;
    }

    private void OnMouseUp()
    {
        GameManager.instance.selectObject = null;
        gameObject.GetComponent<SpriteOutline>().enabled = false;
    }

    private void OnMouseDrag()
    {
        Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        point.z = gameObject.transform.position.z;
        gameObject.transform.position = point;
    }
}

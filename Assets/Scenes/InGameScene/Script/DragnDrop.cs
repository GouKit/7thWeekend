using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DragnDrop : MonoBehaviour
{
    EventLoader papi;
    public List<Transform> slot = new List<Transform>();

    private Vector3 propose;//기존위치

    List<Vector2> llist = new List<Vector2>();

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {

        gameObject.GetComponent<SpriteOutline>().enabled = false;
       // papi = player.GetComponent<EventLoader>();


}

private void OnMouseDown()
    {
        propose = transform.position;
        gameObject.GetComponent<SpriteOutline>().enabled = true;
    }

    private void OnMouseUp()
    {
        gameObject.GetComponent<SpriteOutline>().enabled = false;
        //transform.position = propose;
    }

    private void OnMouseDrag()
    {
        Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        point.z = gameObject.transform.position.z;
        gameObject.transform.position = point;
    }

    public void mando()
    {
        Debug.Log("asdf");
        //papi.players.Add(gameObject);
        gameObject.SetActive(false);
    }

}

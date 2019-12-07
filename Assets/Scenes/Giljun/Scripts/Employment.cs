using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Employment : MonoBehaviour
{
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (gameObject.CompareTag("Player"))
        {
            panel.SetActive(true);
            StartCoroutine(Wait());
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5f);
        panel.SetActive(false);
    }
}

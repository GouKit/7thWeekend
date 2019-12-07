using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Employment : MonoBehaviour
{
    public GameObject panel;
    SoldierStat st;
    // Start is called before the first frame update
    void Start()
    {
        st = GetComponent<SoldierStat>();
        panel.SetActive(false);
    }

    private void Update()
    {
        if (st.isCancel)
        {
            Destroy(gameObject, 3f);
        }
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

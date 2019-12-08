using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupOnOff : SingletonBehaviour<PopupOnOff>
{
    public GameObject quest;

    public void QuestPopup()
    {
        if (!quest.gameObject.activeSelf)
            quest.gameObject.SetActive(true);
        else
            quest.gameObject.SetActive(false);
    }
}

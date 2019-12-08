using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventPopup : MonoBehaviour
{
	public Image image;
	private MonsterBase monsterBase;
	private Action<MonsterBase> action;
    public List<Monster> monsters;

	public void SetEvent(MonsterBase monsterBase, Action<MonsterBase> action = null)
	{
		this.monsterBase = monsterBase;
        // image.sprite = monsterBase.monster.Image;
        image.sprite = monsters.GetRandomElement().Image;
        this.action = action;
	}

	public void _Go()
	{
		action?.Invoke(monsterBase);
		GetComponent<PopupWindow>()._Close();
	}
}

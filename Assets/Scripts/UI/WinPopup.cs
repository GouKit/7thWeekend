using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinPopup : MonoBehaviour
{
	public List<Image> unit_imgs;
	private int index;
	private Action answerNo;
	private Action answerYes;

	public WinPopup AddPlayerState(PlayerLLL[] player)
	{
		for (int i = 0; i < unit_imgs.Count; i++)
		{
			unit_imgs[i].color = player[i].player == null ? new Color(0, 0, 0, 0) : Color.white;
			if (player[i].player == null)
			{
				unit_imgs[i].sprite = player[i].player.player.image;
				unit_imgs[i].color = player[i].dead ? new Color(0, 0, 0, 0.5f) : Color.white;
			}
		}
		return this;
	}

	public void SetRebornAction(Action answerNo, Action answerYes)
	{
		this.answerNo = answerNo;
		this.answerYes = answerYes;
	}

	public void _Reborn()
	{
		GetComponent<PopupWindow>()?._Close();
		answerYes?.Invoke();
	}

	public void _Nono()
	{
		GetComponent<PopupWindow>()?._Close();
		answerNo?.Invoke();
	}
}

public struct PlayerLLL
{
	public PlayerBase player;
	public bool dead;
	public bool levelup;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinPopup : MonoBehaviour
{
	public List<Image> unit_imgs;
	private int index;
	public void AddPlayerState(PlayerBase player, bool dead, bool levelup)
	{
		Image image = unit_imgs[index++];
		image.color = dead ? new Color(0, 0, 0, 0.5f) : Color.white;

	}
}

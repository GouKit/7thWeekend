using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelUpPopup : MonoBehaviour
{
	public string format;
	public TextMeshProUGUI text;

	public void SetPlayerBase(PlayerBase player)
	{
		text.text = string.Format(format, player.Level);
	}
}

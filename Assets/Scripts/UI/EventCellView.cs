using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnhancedUI.EnhancedScroller;

public class EventCellView : EnhancedScrollerCellView
{
	public RectTransform slots;
	public RectTransform slotOrigine;
	public int slotAmount = 4;

	private void Awake()
	{
		for (int i = 1; i < slotAmount; i++)
		{
			Instantiate(slotOrigine, slots);
		}
	}


}

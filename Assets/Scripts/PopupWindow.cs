using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UniRx;

public class PopupWindow : EscapePanel
{
	public DragPopup popup;
	public CanvasGroup layer;

	private float timer;

	public void Start()
	{
		popup.now.Subscribe(x => layer.alpha = x);
		popup.toggle = true;
	}

	private new void Update()
	{
		base.Update();
		timer += Time.deltaTime;
	}

	public void _Close()
	{
		if(timer >= 1)
		{
			layer.blocksRaycasts = false;
			popup.toggle = false;
			Destroy(gameObject, 1);
		}
	}
}

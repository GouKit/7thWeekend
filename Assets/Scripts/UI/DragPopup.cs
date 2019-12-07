using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class DragPopup : MonoBehaviour
{
	public bool toggle;
	public Dicrection dir;
	private bool negative;
	public float speed = 1;
	private RectTransform rect;
	private ReactiveProperty<float> now = new ReactiveProperty<float>();

	protected void Awake()
	{
		rect = GetComponent<RectTransform>();
		negative = dir == Dicrection.Right || dir == Dicrection.Up;
		now.Value = negative ?
			toggle ? 1 : 0 :
			toggle ? 0 : 1;

		if (dir == Dicrection.Up || dir == Dicrection.Down)
		{
			now.Subscribe(x => rect.pivot = new Vector2(0.5f, x)).AddTo(this);
		}
		else
		{
			now.Subscribe(x => rect.pivot = new Vector2(x, 0.5f)).AddTo(this);
		}
	}

	protected void Update()
	{
		if (negative)
		{
			if (toggle)
			{
				var f = now.Value;
				f += Time.deltaTime * speed;
				f = f > 1 ? 1 : f;
				now.Value = f;
			}
			else
			{
				var f = now.Value;
				f -= Time.deltaTime * speed;
				f = f < 0 ? 0 : f;
				now.Value = f;
			}
		}
		else
		{
			if (toggle)
			{
				var f = now.Value;
				f -= Time.deltaTime * speed;
				f = f < 0 ? 0 : f;
				now.Value = f;
			}
			else
			{
				var f = now.Value;
				f += Time.deltaTime * speed;
				f = f > 1 ? 1 : f;
				now.Value = f;
			}
		}
	}

	protected IEnumerator Cor(float delay, Action action)
	{
		yield return new WaitForSeconds(delay);
		action();
	}
}

public enum Dicrection
{
	Up,
	Down,
	Left,
	Right
}
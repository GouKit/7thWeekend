using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapePanel : MonoBehaviour
{
	protected List<EscapePanel> children = new List<EscapePanel>();
	protected EscapePanel parent;

	protected void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (children.Count == 0)
			{
				_DestroySelf();
			}
		}
	}

	public void _DestroySelf()
	{
		Destroy(gameObject);
	}

	public void _CreateChild(EscapePanel panelPrefab)
	{
		var panel = Instantiate(panelPrefab);
		AddChild(panel);
	}

	public void AddChild(EscapePanel panel)
	{
		children.Add(panel);
		if (panel.parent != null)
		{
			panel.parent.children.Remove(panel);
		}
		panel.parent = this;
	}

	public void _ChangePanel(EscapePanel panel)
	{
		_DestroySelf();
		Instantiate(panel);
	}

	public T ChangePanel<T>(T panel) where T : EscapePanel
	{
		_DestroySelf();
		return Instantiate(panel);
	}

	public EscapePanel CreateChild(EscapePanel panelPrefab)
	{
		var panel = Instantiate(panelPrefab);
		AddChild(panel);
		return panel;
	}

	protected void OnDestroy()
	{
		foreach (var child in children)
		{
			child._DestroySelf();
		}
		if (parent != null)
		{
			parent.children.Remove(this);
		}
	}
}

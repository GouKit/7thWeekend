using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonBehaviour<T> : MonoBehaviour where T : SingletonBehaviour<T>
{
	public static T instance
	{
		get
		{
			if(_instance == null)
			{
				try
				{
					_instance = FindObjectOfType<T>();
				}
				catch (Exception) { }
			}
			return _instance;
		}
	}
	protected static T _instance;
	protected void Awake()
	{
		if(!(_instance == null || _instance == this))
		{
			Destroy(this);
		}
		else
		{
			_instance = (T)this;
		}
	}
}

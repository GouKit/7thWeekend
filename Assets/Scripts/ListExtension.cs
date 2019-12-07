using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ListExtension
{
	public static T GetRandomElement<T>(this List<T> list)
	{
		if (list.Count == 0)
		{
			return default;
		}
		var index = Random.Range(0, list.Count);
		return list[index];
	}
}

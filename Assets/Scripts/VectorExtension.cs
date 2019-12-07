using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VectorExtension 
{
	public static Vector3 ToVector3(this Vector2 vector2, float z = 0)
	{
		return new Vector3(vector2.x, vector2.y, z);
	}

	public static Vector3 Multiple(this Vector3 a, Vector3 b)
	{
		return new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
	}

}

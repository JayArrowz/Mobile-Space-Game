using UnityEngine;
using System.Collections;

public class MethodScript {


	public static bool inArea(Transform toCreate, Transform toCheck) {
		Bounds bounds1 = toCreate.GetComponent<Bounds>();
		Bounds bounds2 = toCheck.GetComponent<Bounds>();
		return bounds1.Intersects (bounds2);

	}



}

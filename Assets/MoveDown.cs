using UnityEngine;
using System.Collections;

public class MoveDown : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}

	public float incrementY = 0.5f;

	// Update is called once per frame
	void Update () {
		float y = (incrementY+ScoreScript.getSpeedIncrement()) * -1;

		Vector3 vec3 = transform.position;
		if (Lava.inLava(vec3)) {
			Destroy(gameObject);
			ScoreScript.increaseScore(1);
			return;
		}

		transform.position += new Vector3(0, y, 0);
	}
}

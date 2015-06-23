using UnityEngine;
using System.Collections;

public class MoveBeamDown : MonoBehaviour {

	public int Y_BOUND = -389;
	public int Y_RESPAWN = 1177;

	public float speed = 1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 vec = transform.position;
		if (transform.position.y > Y_BOUND) {
			transform.position += new Vector3(0, (ScoreScript.getSpeedIncrement() + speed)*-1, 0);
		} else {
			transform.position = new Vector3(transform.position.x, Y_RESPAWN, 0);
		}
	}
}

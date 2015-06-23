using UnityEngine;
using System.Collections;

public class InstantDeath : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		GameObject go = GameObject.Find("Ship");
		SpaceShipScript script = (SpaceShipScript) go.GetComponent(typeof(SpaceShipScript));
		script.respawn ();
	}
}

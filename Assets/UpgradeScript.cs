using UnityEngine;
using System.Collections;

public class UpgradeScript : MonoBehaviour {


	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag.Equals("Player")) {
			DoUpgrade(gameObject.tag);
		}
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void DoUpgrade(string tag) {
		switch(tag) {
		case "Heart": 
			HealthScript.setHealth(HealthScript.getHealth()+1);
			break;

		case "Ghost": 
			makeGhost();
			break;
		}
		Destroy (gameObject);
	}

	void makeGhost() {
		GameObject go = GameObject.Find("Ship");
		SpaceShipScript script = (SpaceShipScript) go.GetComponent(typeof(SpaceShipScript));
		script.flash (20);
	}
}

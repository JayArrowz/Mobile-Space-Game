using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {

	static int hearts = 6;
	static int maxHearts = 6;
	static SpriteRenderer ren;
	static Sprite[] staticSprites;

	public Sprite[] sprites;

	// Use this for initialization
	void Start () {
		ren = GetComponent<SpriteRenderer> ();
		staticSprites = sprites;
		ren.sprite = staticSprites [0];
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void setHealth(int health) {
		if (health > maxHearts) {
			health = maxHearts;
		}
		hearts = health;
		ren.sprite = staticSprites [maxHearts-health];
	}

	public static int getHealth() {
		return hearts;
	}

}

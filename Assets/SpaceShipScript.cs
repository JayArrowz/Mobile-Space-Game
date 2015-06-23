using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpaceShipScript : MonoBehaviour {

	public static bool GAME_STARTED = false;

	float speed = 90.0f;
	public Rigidbody2D rb;
	public float health = 100f;
	public static bool isImmune = false;
	

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}


	// Update is called once per frame
	void FixedUpdate () {
		if (Lava.inLava (rb.position)) {
			respawn();
			return;
		}
		//#if UNITY_STANDALONE || UNITY_WEBPLAYER || UNITY_EDITOR
		Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
		Debug.Log (move);
		rb.MovePosition(transform.position + move * (speed+ScoreScript.getSpeedIncrement()) * Time.deltaTime);

		if(Input.touchCount == 1) {
			Touch myTouch = Input.touches[0];
				if(myTouch.position.x < Screen.width/2) {
					move = new Vector3(-1, 0, 0);
				rb.MovePosition(transform.position + move * (speed+ScoreScript.getSpeedIncrement()) * Time.deltaTime);
				} else if (myTouch.position.x > Screen.width/2) {
					move = new Vector3(1, 0, 0);
				rb.MovePosition(transform.position + move * (speed+ScoreScript.getSpeedIncrement()) * Time.deltaTime);
				}		
		}

	}

	public void flash(int numTimes) {
		SpriteRenderer[] sprites = GetComponentsInChildren<SpriteRenderer>();
		StartCoroutine(FlashSprites(sprites, numTimes, 0.5f, false));
	}

	public void respawn() {
		if (isImmune) {
			return;
		}
		HealthScript.setHealth (HealthScript.getHealth () - 1);
		rb.transform.position = new Vector3(0,0,0);		
		flash (5);

		

	}

	
	/**
     * Coroutine to create a flash effect on all sprite renderers passed in to the function.
     *
     * @param sprites   a sprite renderer array
     * @param numTimes  how many times to flash
     * @param delay     how long in between each flash
     * @param disable   if you want to disable the renderer instead of change alpha
     */
	IEnumerator FlashSprites(SpriteRenderer[] sprites, int numTimes, float delay, bool disable) {
		// number of times to loop
		//GetComponent<PolygonCollider2D> ().isTrigger = true;
		isImmune = true;

		for (int loop = 0; loop < numTimes; loop++) {            
			// cycle through all sprites
			for (int i = 0; i < sprites.Length; i++) {                
				if (disable) {
					// for disabling
					sprites[i].enabled = false;
				} else {
					// for changing the alpha
					sprites[i].color = new Color(sprites[i].color.r, sprites[i].color.g, sprites[i].color.b, 0.5f);
				}
			}
			
			// delay specified amount
			yield return new WaitForSeconds(delay);
			
			// cycle through all sprites
			for (int i = 0; i < sprites.Length; i++) {
				if (disable) {
					// for disabling
					sprites[i].enabled = true;
				} else {
					// for changing the alpha
					sprites[i].color = new Color(sprites[i].color.r, sprites[i].color.g, sprites[i].color.b, 1);
				}
			}
			
			// delay specified amount
			yield return new WaitForSeconds(delay);
		}

		//GetComponent<PolygonCollider2D> ().isTrigger = false;
		isImmune = false;
	}

}

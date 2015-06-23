using UnityEngine;
using System.Collections;

public class ScoreScript : MonoBehaviour {
	
	public static TextMesh scoreText;
	public static int score = 0;

	// Use this for initialization
	void Start () {		
		scoreText = GetComponent<TextMesh> ();
		scoreText.text = "Score: " + score;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void increaseScore(int scoreIncrement) {
		score += scoreIncrement;
		scoreText.text = "Score: " + score;
	}

	public static float getSpeedIncrement() {
		return score / 30;
	}
}

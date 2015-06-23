using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class RandomGeneration : MonoBehaviour {

	public const int WALL_Y_SIZE = 300;

	public float startX;
	public float startY;
	public GameObject playerTransform;
	public GameObject[] obstaclePrefab; 
	WallGameObject[] WallObjects;
	public static GameObject[] staticPrefabs;

	public static List<GameObject> getAllObjects() {
		List<GameObject> list = new List<GameObject>();
		foreach (GameObject obj in staticPrefabs) {
			GameObject[] tempObjects = GameObject.FindGameObjectsWithTag(obj.tag);
			foreach(GameObject tempObj in tempObjects) {
				list.Add(tempObj);
			}
		}
		return list;
	}

	void Start(){
		staticPrefabs = obstaclePrefab;
		WallObjects = new WallGameObject[obstaclePrefab.Length];
		int count = 0;
		foreach (GameObject transform in obstaclePrefab) {
			if(transform.tag.Contains("Fire")) {				
				WallObjects[count] = new WallGameObject(playerTransform, transform, 20, 60);
				count++;
				continue;
			} else if(transform.tag.Contains("Heart")) {				
				WallObjects[count] = new WallGameObject(playerTransform, transform, 40, 100);
				count++;
				continue;
			}
			WallObjects[count] = new WallGameObject(playerTransform, transform);
			count++;
		}
	}
	
	void Update () {
		foreach(WallGameObject objects in WallObjects) {
			objects.process();
		}
	}

	public static Vector3 getStartValues(GameObject gameObject) {
		switch (gameObject.tag) {
		case "RightRock": //Right purple rock
			return new Vector3(112+UnityEngine.Random.Range(0, 120), 100);
		case "LeftRock": //Left purple rock
			return new Vector3(-118-UnityEngine.Random.Range(0, 130), 100);
		case "RightRockFire": //Right purple rock
			return new Vector3(112+UnityEngine.Random.Range(0, 120), 100);
		case "LeftRockFire": //Left purple rock
			return new Vector3(-118-UnityEngine.Random.Range(0, 130), 100);
		case "Coin":
			return new Vector3(UnityEngine.Random.Range(-144, 128),UnityEngine.Random.Range(101, 332),0);
		}
		return new Vector3(0, 0);
	}


	public class WallGameObject {
		int ySpread = 300;
		int minYSpread = 100;	

		int minCoolDown = 5;
		int maxCoolDown = 40;
		
		
		DateTime waitTime;
		GameObject transform;
		GameObject player;
		float decidedYPos;
		GameObject gameObject;

		public WallGameObject(GameObject player, GameObject transform) {
			this.transform = transform;
			this.player = player;
			waitTime = DateTime.Now + TimeSpan.FromSeconds(UnityEngine.Random.Range(minCoolDown, maxCoolDown));
		}

		public WallGameObject(GameObject player, GameObject transform, int minCoolDown, int maxCoolDown) {
			this.transform = transform;
			this.player = player;
			this.minCoolDown = minCoolDown;
			this.maxCoolDown = maxCoolDown;
			waitTime = DateTime.Now + TimeSpan.FromSeconds(UnityEngine.Random.Range(minCoolDown, maxCoolDown));
		}


		public void process() {
			if (DateTime.Now >= waitTime) {
				float lanePos = UnityEngine.Random.Range (0, 3);

				int yAdd = 400;

				Vector3 vec3 = getStartValues(transform);
				float startY = vec3.y;
				float startX = vec3.x;

				float yPos = startY + player.transform.position.y + yAdd + UnityEngine.Random.Range(0, 200) + UnityEngine.Random.Range (minYSpread, ySpread);

				vec3.Set(startX, yPos, 0);

				Vector3 newPos = getNewPos(vec3);

				decidedYPos = yPos;
				gameObject = Instantiate (transform, newPos, Quaternion.identity) as GameObject;
				
				waitTime = DateTime.Now + TimeSpan.FromSeconds(UnityEngine.Random.Range(minCoolDown, maxCoolDown));
			}
		}

		public float getDecidedYPos() {
			return decidedYPos;
		}

		public GameObject getGameObject() {
			return gameObject;
		}

		public Vector3 getNewPos(Vector3 pos) {
			List<GameObject> combined = getAllObjects ();
			foreach(GameObject go in combined) {
				if(go.GetComponent<Collider2D>() == null) {
					continue;
				}
				if(go.GetComponent<Collider2D>().bounds.Contains(pos)) {
					pos.Set(pos.x, pos.y+WALL_Y_SIZE, 0);
				}
			}
			return pos;
		}


	}


	

}

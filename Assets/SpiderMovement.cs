using UnityEngine;
using System.Collections;

public class SpiderMovement : MonoBehaviour {
	public static SpiderMovement instance;

	private Vector3 currentPosition;
	private Vector3 nextPosition;
	private float moveU;
	private float moveElapsed;
	private bool isSpiderMoving;

	public float duration = 1.5f;
	void Awake(){
		if (instance == null) {
			instance = this;
		}
	}
	// Use this for initialization
	void Start () {
		isSpiderMoving = false;
	}
	
	// Update is called once per frame

	public void UpdateNextPosition(Vector3 position){
		nextPosition = position;
		isSpiderMoving = true;
	}

	void Update () {
		if (isSpiderMoving) {
			moveElapsed += Time.deltaTime;
			moveU = moveElapsed / duration;
			gameObject.transform.position = Vector3.Lerp(currentPosition, nextPosition, moveU);
			if (moveElapsed >= duration){
				isSpiderMoving = false;
				moveElapsed = 0;
				currentPosition = transform.position;
			}  
		}
	}
}

using UnityEngine;
using System.Collections;

public class SpiderMovement : MonoBehaviour {
	public static SpiderMovement instance;

	private Quaternion currentRotation;
	private Quaternion nextRotation;
	private Animation spiderAnim;


	private Vector3 currentPosition;
	private Vector3 nextPosition;
	private float moveU;
	private float slideU;

	private float moveElapsed;
	private float slideElapsed;

	private bool isSpiderMoving;
	private bool isSpiderTurning;

	public float duration = 1.5f;

	public float spinDuration = .5f;

	void Awake(){
		if (instance == null) {
			instance = this;
		}
	}
	// Use this for initialization
	void Start () {
		isSpiderMoving = false;
		isSpiderTurning = false;
		currentRotation = transform.rotation;
		spiderAnim = GameObject.FindGameObjectWithTag ("spider").GetComponent<Animation> (); //.Play();

	}
	
	// Update is called once per frame

	public void UpdateNextPosition(Vector3 position){
		nextPosition = position;
		isSpiderMoving = true;
		spiderAnim.Play ("walk");
		spiderAnim["walk"].speed= 7.5f;
	}

	public void UpdateNextRotation(Quaternion position){
		nextRotation = position;

		isSpiderTurning = true;
	}

	public void crawlDown(){
		// Move to set position under chair

		// wait with corutine 

		// crawl down
		
	}

	void Update () {
		if (isSpiderMoving) {
			moveElapsed += Time.deltaTime;
			moveU = moveElapsed / duration;
			gameObject.transform.position = Vector3.Lerp(currentPosition, nextPosition, moveU);
			if (moveElapsed >= duration){
				isSpiderMoving = false;
				spiderAnim.Play ("shake1");

				moveElapsed = 0;
				currentPosition = transform.position;
			}  
		}

		if  (isSpiderTurning) {
			slideElapsed += Time.deltaTime;
			slideU = slideElapsed / spinDuration;
			gameObject.transform.rotation = Quaternion.Slerp(currentRotation, nextRotation, slideU);

			if (slideElapsed >= spinDuration){
				isSpiderTurning = false;
				spiderAnim.Play ("shake1");

				slideElapsed = 0;
				currentRotation = transform.rotation;
			}  
		}
	}
}

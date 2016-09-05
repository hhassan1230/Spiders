using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpiderController : MonoBehaviour {
	private SpiderMovement spiderScript;
	private GameObject spider;
	public List<GameObject>  positionArray;
	private int count; 
	private int arrayLength;
	private Vector3 currentPosition;
	private float angle;

	// Use this for initialization
	void Start () {
		spider = GameObject.FindGameObjectWithTag ("SpiderContainer");
		spiderScript = spider.GetComponent<SpiderMovement> ();
		arrayLength = positionArray.Count;
		count = 0;
		InvokeRepeating("UpdatePosition", 2f, 2f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void UpdatePosition(){
		if (arrayLength > count) {
			currentPosition = positionArray [count].transform.position;
			spider.transform.rotation = Quaternion.LookRotation(spider.transform.position - positionArray [count].transform.position);

			spiderScript.UpdateNextPosition (currentPosition);
			count++;	
		} else {
			count = 0;
			currentPosition = positionArray [count].transform.position;
			spider.transform.rotation = Quaternion.LookRotation(spider.transform.position - positionArray [count].transform.position);

			spiderScript.UpdateNextPosition (currentPosition);
			count++;
		}

	}
}

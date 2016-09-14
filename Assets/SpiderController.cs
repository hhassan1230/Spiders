using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpiderController : MonoBehaviour {
	private SpiderMovement spiderScript;
	private GameObject spider;
	private Animation spiderAnim;
	public List<GameObject>  positionArray;

	private Vector3 originPoint;
	private int count; 
	private int arrayLength;
	private Vector3 currentPosition;
	private float angle;
	private bool isCrawling;

	// Use this for initialization
	void Start () {
		spider = GameObject.FindGameObjectWithTag ("SpiderContainer");
		spiderAnim = GameObject.FindGameObjectWithTag ("spider").GetComponent<Animation> (); //.Play();
		spiderScript = spider.GetComponent<SpiderMovement> ();
		arrayLength = positionArray.Count;
		count = 0;
		InvokeRepeating("UpdatePosition", 2f, 2f);
		isCrawling = true;
		originPoint = new Vector3 (0f, 0f, 0f);
	}

	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator CrawlDown() {
		yield return new WaitForSeconds (2f);
		spiderScript.UpdateNextPosition (new Vector3 (spider.transform.position.x, spider.transform.position.y + 2f, spider.transform.position.z));

//		spider.transform.transform.position = new Vector3 (spider.transform.position.x, spider.transform.position.y + 2f, spider.transform.position.z);
//		spider.transform.rotation = Quaternion.Euler(90f, spider.transform.rotation.y, spider.transform.rotation.z);
		spiderScript.UpdateNextRotation(Quaternion.Euler(90f, spider.transform.rotation.y, spider.transform.rotation.z));
	}

	private void UpdatePosition(){
		if (arrayLength > count) {
			currentPosition = positionArray [count].transform.position;
			spider.transform.rotation = Quaternion.LookRotation(spider.transform.position - positionArray [count].transform.position);

			spiderScript.UpdateNextPosition (currentPosition);

			count++;	
		} else {
//			count = 0;
//			currentPosition = positionArray [count].transform.position;
//			spider.transform.rotation = Quaternion.LookRotation(spider.transform.position - positionArray [count].transform.position);
//
//			spiderScript.UpdateNextPosition (currentPosition);
//			count++;
			if (isCrawling) {
//				spider.transform.rotation = Quaternion.LookRotation(spider.transform.position - originPoint);
				spiderScript.UpdateNextRotation(Quaternion.LookRotation(spider.transform.position - originPoint));
				spiderScript.UpdateNextPosition (originPoint);
//				RotationDriveMode x
				StartCoroutine("CrawlDown");
				isCrawling = false;
			}
		}

	}
}

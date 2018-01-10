using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gift : MonoBehaviour {

	[SerializeField]
	public float screenX;
	public float screenY;
	private int count = 0;
	private GameObject[] gifts;

	// Use this for initialization


	void Start () {
		this.randomLocation ();
	/*	this.gifts = new GameObject[3];
		foreach (Transform i in this.transform) {
			this.gifts [this.count] = i.gameObject;
			this.count++;
		}*/

	}


	void randomLocation(){
		var tempx = Random.Range (-5, 5) + Random.value;
		var tempy = Random.Range (-3, 3) + Random.value;

		this.transform.position = new Vector3(tempx, tempy,0f);
	}

	void OnCollisionEnter2D(){
		Debug.Log ("destroy");
		Destroy (this.gameObject);
	}

	// Update is called once per frame
	void Update () {
		
	}
}

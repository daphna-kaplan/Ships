using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void testing (){
		var startScreen  = GameObject.Find ("start");
		startScreen.SetActive (false);
		var startButton  = GameObject.Find ("startButton");
		startButton.SetActive (false);

	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerImage : MonoBehaviour {
	public Rigidbody2D playerRigid;
	public GameObject playerObject;
	// Use this for initialization
	void Start () {
		playerObject = GameObject.Find ("playerA");
		playerRigid = playerObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = playerObject.transform.position;
		//transform.rotation = new Vector3(playerRigid.velocity.x,playerRigid.velocity.y, 0f) ;
	//	transform.rotation = Quaternion.LookRotation(playerRigid.velocity.normalized);
		Vector2 v = playerRigid.velocity;
		var angle = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
		//transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

	}
}

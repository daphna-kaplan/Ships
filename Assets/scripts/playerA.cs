using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class playerA : MonoBehaviour {
	[SerializeField]
	public float vel;

	public bool started = false;
	public float life;
	private Rigidbody2D rb;
	public Vector3 drift;
	private GameObject image;
	private Vector3 innerVelocity;
	private Vector3 oldinnerVelocity;
	public float rotationAngle;
	private GameObject headA;
	public float speed;
	public TextMesh countText;


	// Use this for initialization


	void Start () {
		this.speed = 1f;
		this.countText = this.gameObject.GetComponent<TextMesh>();
		this.countText.text = "GO";
		this.rotationAngle = this.rotationAngle * Mathf.Deg2Rad ;
		this.rb = GetComponent<Rigidbody2D>();
		this.drift = new Vector3 (0f, -0.5f, 0f);
		this.image = GameObject.Find ("playerAImage");
		this.innerVelocity = new Vector3 (0f, vel, 0f);
		this.oldinnerVelocity = this.innerVelocity;
		this.rb.velocity = this.drift + this.innerVelocity;
		this.headA = GameObject.Find ("headAcollider");

	}
	
	// Update is called once per frame
	void Update () {
		this.setText (this.life.ToString());

		this.startGame ();
		var temp = new Vector3(this.innerVelocity.x, this.innerVelocity.y, 0f);
		var tempdouble = temp / 2 ;
		//this.headA.transform.position = this.transform.position + tempdouble;


	}

	void FixedUpdate(){
		this.controlNew ();

		}

	void startGame(){
		if (!this.started) {
			if (Input.anyKeyDown && !(Input.GetKeyDown (KeyCode.Mouse0))) {
				//gameObject.GetComponentInChildren<Transform> ().gameObject.SetActive (false);
				//GameObject.Find ("buttonsA").SetActive (false);
				this.started =true;
			}
		}
	}

	void setText(string tex){
		this.countText.text = tex;
	}



	void OnCollisionEnter2D(Collision2D collision){
		Debug.Log (collision.gameObject.name);

		if (collision.gameObject.name == "playerB") {
			var playerBvar = collision.gameObject.GetComponent<playerB> ();
			Debug.Log ("CALLING");
			this.gotHit (playerBvar);
			//this.gotHit( (playerB)(GameObject.Find("playerB")));

		}

	}

	public float getSpeed(){
		return this.speed;
	}


	void gotHit(playerB other){
		this.setText ("GOT HIT");
		if (other.getSpeed () == 1f) {
			this.life -= 10;
			Debug.Log ("LIFE left : " + this.life.ToString());
		}

		if (other.getSpeed () == 2f) {
			this.life -= 20;

		}
		if (other.getSpeed() >= 3f) {
			this.life -= 30;

		}
		if (this.life <= 0) {
			this.die ();

		}
	}



	void die(){
		Debug.Log ("DIE");
		Destroy (this.gameObject);
		SceneManager.LoadScene("game");

	}

	void ramming(){

	}

	Vector3 rotateAroundP(float angle, float Vecx, float Vecy){
		var x = Vecx * Mathf.Cos (angle) - Vecy * Mathf.Sin (angle);
		var y = Vecx * Mathf.Sin (angle) + Vecy * Mathf.Cos (angle);
		return new Vector3 (x, y, 0f);


	}

	void controlNew(){

		if (Input.GetKey (KeyCode.A)){
			var old = this.innerVelocity;

			this.innerVelocity = this.rotateAroundP (this.rotationAngle, this.innerVelocity.x, this.innerVelocity.y);
			this.image.transform.RotateAround(this.image.transform.position, new Vector3(0f,0f,1f), Vector3.Angle(old, this.innerVelocity));
			this.transform.RotateAround(this.transform.position, new Vector3(0f,0f,1f), Vector3.Angle(old, this.innerVelocity));

			var vec = this.innerVelocity + this.drift;
			this.rb.velocity = vec;


		}
		if (Input.GetKey (KeyCode.W)){
			var old = this.innerVelocity;

			var vec = this.innerVelocity + this.innerVelocity+ this.drift;
			this.rb.velocity = vec;



		}
		if (Input.GetKey (KeyCode.S)){
			


		}
		if (Input.GetKey (KeyCode.D)){
			var old = this.innerVelocity;

			this.innerVelocity = this.rotateAroundP (-this.rotationAngle, this.innerVelocity.x, this.innerVelocity.y);
			this.image.transform.RotateAround(this.image.transform.position, new Vector3(0f,0f,1f), -1f * Vector3.Angle(old, this.innerVelocity));

			var vec = this.innerVelocity + this.drift;
			this.rb.velocity = vec;

		}
	}


}

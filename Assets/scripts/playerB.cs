using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerB : MonoBehaviour {

	[SerializeField]
	public float vel;
	public Vector3 drift;
	public bool started = false;
	public float life;
	public float rotationAngle;
	private Rigidbody2D rb;
	private GameObject image;
	private Vector3 innerVelocity;
	private Vector3 oldinnerVelocity;
	private GameObject headB;
	private float speed;
	public TextMesh countText;


	// Use this for initialization


	void Start () {
		this.countText = this.gameObject.GetComponent<TextMesh>();
		this.speed = 1f;
		//this.countText.text = "GO";
		this.setText("start");
		this.rotationAngle = this.rotationAngle * Mathf.Deg2Rad ;
		this.rb = GetComponent<Rigidbody2D>();
		this.drift = new Vector3 (0f, -0.5f, 0f);
		this.image = GameObject.Find ("playerBImage");
		this.innerVelocity = new Vector3 (0f, vel, 0f);
		this.oldinnerVelocity = this.innerVelocity;
		this.rb.velocity = this.drift + this.innerVelocity;
		this.headB = GameObject.Find ("headBcollider");

	}

	// Update is called once per frame
	void Update () {

		this.setText (this.life.ToString());
		this.countText = this.gameObject.GetComponent<TextMesh>();
		this.startGame ();
		this.image.transform.position = this.transform.position;
		var test = GameObject.Find ("testing");
		var temp = new Vector3(this.innerVelocity.x, this.innerVelocity.y, 0f);
		var tempdouble = temp / 2;
		this.headB.transform.position = this.transform.position + tempdouble;


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

	public float getSpeed(){
		return this.speed;
	}

	void OnCollisionEnter2D(Collision2D collision){
		Debug.Log (collision.gameObject.name);

		if (collision.gameObject.name == "playerA") {
			var playerBvar = collision.gameObject.GetComponent<playerA> ();
			Debug.Log ("CALLING");
			this.gotHit (playerBvar);
			//this.gotHit( (playerB)(GameObject.Find("playerB")));

		}
	}

	void gotHit(playerA other){
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
		if (this.life <= 0){
			
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


	void setText(string tex){
		this.countText.text = tex;
	}


	void controlNew(){
		if (Input.GetKey (KeyCode.LeftArrow)){
			var old = this.innerVelocity;

			this.innerVelocity = this.rotateAroundP (this.rotationAngle, this.innerVelocity.x, this.innerVelocity.y);
			this.image.transform.RotateAround(this.image.transform.position, new Vector3(0f,0f,1f), Vector3.Angle(old, this.innerVelocity));

			var vec = this.innerVelocity + this.drift;
			this.rb.velocity = vec;


		}
		if (Input.GetKey (KeyCode.UpArrow)){
			var old = this.innerVelocity;

			var vec = this.innerVelocity + this.innerVelocity+ this.drift;
			this.rb.velocity = vec;



		}
		if (Input.GetKey (KeyCode.DownArrow)){



		}
		if (Input.GetKey (KeyCode.RightArrow)){
			var old = this.innerVelocity;

			this.innerVelocity = this.rotateAroundP (-this.rotationAngle, this.innerVelocity.x, this.innerVelocity.y);
			this.image.transform.RotateAround(this.image.transform.position, new Vector3(0f,0f,1f), -1f * Vector3.Angle(old, this.innerVelocity));

			var vec = this.innerVelocity + this.drift;
			this.rb.velocity = vec;

		}
	}


}

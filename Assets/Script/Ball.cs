using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	
	// Cannot set paddle to be public because prefab will lose its connection with object.
	//public Paddle paddle;
	private Paddle paddle;
	private bool hasStarted = false;
	
	// the vector from the centor of paddle to the center of the ball
	private Vector3 paddleToBallVector;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position-paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if( !hasStarted ) {
			// Lock the ball to the position on the paddle
			this.transform.position = paddle.transform.position+ paddleToBallVector;
		
		
			// Listen to the mouse click event
			if (Input.GetMouseButtonDown(0)) {
				hasStarted=true;
				print ("mouse click");	
				this.GetComponent<Rigidbody2D>().velocity=new Vector2(2f, 10f);
			}
		}
	}
	
	void OnCollisionEnter2D(Collision2D collision) {
	
		Vector2 randomTweak = new Vector2(Random.Range(0f,0.2f), Random.Range(0f,0.2f));
		if(hasStarted) {
			
			GetComponent<AudioSource>().Play ();
			GetComponent<Rigidbody2D>().velocity += randomTweak;
		}
	}
}

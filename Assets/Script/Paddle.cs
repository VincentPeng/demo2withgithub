using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool autoPlay = false;
	
	private Ball ball;
	float unitx;
	float unity;
	Vector3 paddlePos;
	
	// Use this for initialization
	void Start () {
		paddlePos = new Vector3(8.0f, 0.5f, -3.0f);
		this.transform.position = paddlePos;
		ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!autoPlay) {
			MoveWithMouse();
		} else {
			AutoPlay();
		}
	}
	
	void MoveWithMouse() {
		unitx = Input.mousePosition.x / Screen.width * 16;
		paddlePos.x = Mathf.Clamp(unitx,1.07f,14.86f);
		this.transform.position = paddlePos;
	}
	
	void AutoPlay() {
		paddlePos.x = ball.transform.position.x;
		this.transform.position = paddlePos;
	}
}

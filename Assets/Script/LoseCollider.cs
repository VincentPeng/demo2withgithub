using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	// Cannot set levelmanager to public because prefab will lose its connection with object when
	// reuse.
	//public LevelManager levelManager;
	
	private LevelManager levelManager;

	void OnCollisionEnter2D(Collision2D collision) {
		print ("collision");
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		levelManager.LoadLevel("Lose");
	}
	
	void OnTriggerEnter2D(Collider2D collider) {
		print ("Trigger");
	}

}

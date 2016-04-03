using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public AudioClip crack;
	public Sprite[] sprites;
	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable = false;
	public GameObject Smoke;
	
	// Use this for initialization
	void Start () {
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		
		if(this.tag == "breakable") {
			isBreakable = true;
			levelManager.AddBrickCount();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter2D(Collision2D collision) {
		//print ("hits "+levelManager.getBrickCount() + "brickcounts left");
		AudioSource.PlayClipAtPoint(crack,transform.position, 0.5f);
		if(isBreakable) {
			HandleBreakable();
		}
	}

	void HandleBreakable ()
	{
		int maxHits = sprites.Length;
		timesHit++;
		//int spriteIndex = timesHit - 1;
		
		if (timesHit >= maxHits) {
			//print ("destroy");
			levelManager.minusBrickCount();
			GameObject smokePuff = Instantiate(Smoke, this.transform.position, Quaternion.identity) as GameObject;
			smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
			Destroy (gameObject);
			if(levelManager.getBrickCount()<=0) {
				levelManager.LoadNextLevel();
			}
		} else if (sprites[timesHit]) {
			gameObject.GetComponent<SpriteRenderer>().sprite = sprites[timesHit];
		}
	}
}

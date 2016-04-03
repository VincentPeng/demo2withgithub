using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {


	private int brickCount;
	// name: name of the level should be loaded
	public void LoadLevel(string name) {
		Debug.Log ("Level load request for" + name );
		brickCount = 0;
		Application.LoadLevel(name);
	}
	
	public void QuitQuest() {
		Debug.Log ("Now quit");
		Application.Quit();
	}
	
	public void LoadNextLevel ()
	{
		print ("level = "+Application.loadedLevel);
		brickCount = 0;
		Application.LoadLevel(Application.loadedLevel + 1);
	}
	
	public void AddBrickCount() {
		brickCount++;
	}
	
	public void minusBrickCount() {
		brickCount--;
	}
	
	public int getBrickCount() {
		return brickCount;
	}
}

using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	enum GameStates { Menu, Game };
	private GameStates state;
	private GameObject leftCamera;
	private GameObject rightCamera;
	public ScissorSpawner scissorSpawner;

	// Use this for initialization
	void Start () {
		state = GameStates.Menu;
		
		leftCamera = GameObject.Find("CameraLeft");
		rightCamera = GameObject.Find("CameraRight");
		leftCamera.camera.enabled = false;
		rightCamera.camera.enabled = false;
		Debug.Log("Starting game.");
		this.camera.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
	
		switch (state) {
		
			case GameStates.Menu:
				if (Input.GetKey(KeyCode.Space)) {
					Debug.Log("Space key was pressed in menu state.");
					//Application.LoadLevel("GameplayScene");
					this.camera.enabled = false;
					leftCamera.camera.enabled = true;
					rightCamera.camera.enabled = true;
					state = GameStates.Game;
					scissorSpawner.Spawn();
				}
				break;
			case GameStates.Game:
			//	if (Input.GetKey(KeyCode.Space)) {
			//		Debug.Log("Space key was pressed in game state.");
			//		Application.LoadLevel("GameplayScene");
			//	}
				break;
			default:
				Debug.Log("Unknown game state.");
				break;
		}
	}
}

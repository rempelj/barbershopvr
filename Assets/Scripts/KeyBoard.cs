using UnityEngine;
using System.Collections;

public class KeyBoard : MonoBehaviour {

	enum GameStates { Menu, Game };
	private GameStates state;

	// Use this for initialization
	void Start () {
		state = GameStates.Menu;
	}
	
	// Update is called once per frame
	void Update () {
	
		switch (state) {
		
			case GameStates.Menu:
				if (Input.GetKey(KeyCode.Space)) {
					Debug.Log("Space key was pressed.");
					Application.LoadLevel("GameplayScene");
				}
				break;
			default:
				Debug.Log("Unknown game state.");
				break;
		}
	}
}

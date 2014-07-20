using UnityEngine;
using System.Collections;

public class KeyBoard : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Space)) {
			Debug.Log("Space key was pressed.");
			Application.LoadLevel("GameplayScene");
		}
	}
}

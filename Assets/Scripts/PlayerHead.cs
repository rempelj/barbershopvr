using UnityEngine;
using System.Collections;

public class PlayerHead : MonoBehaviour {

	public AudioSource hurtSound;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter (Collider other) {
		var scissors = other.transform.root.GetComponent<Scissors>();
		
		if (scissors != null)
		{
			scissors.stopped = true;
			scissors.transform.root.parent = transform;
			scissors.stabSound.Play();
			hurtSound.Play();
			Debug.Log("stabbed");
		}
		
	}
}

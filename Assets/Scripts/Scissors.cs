using UnityEngine;
using System.Collections;

public class Scissors : MonoBehaviour {

	public Animation snipAnimation;
	
	public float snipRate;
	
	private float lastSnipTime;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > lastSnipTime + snipRate) {
			lastSnipTime = Time.time;
			Snip();
		}
	}
	
	public void Snip()
	{
		snipAnimation.Play();
		// play sfx
	}
}

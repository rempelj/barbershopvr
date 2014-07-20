using UnityEngine;
using System.Collections;

public class Scissors : MonoBehaviour {

	public Animation snipAnimation;
	
	public float snipRate;
	
	private bool mStopped;
	public bool stopped {
		get { return mStopped; }
		set { 
			mStopped = value;
			snipAnimation.enabled=value;
		}
	}
	
	public AudioSource stabSound;
	public AudioSource snipSound;
	
	private float lastSnipTime;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (!stopped && Time.time > lastSnipTime + snipRate) {
			lastSnipTime = Time.time;
			Snip();
		}
	}
	
	public void Snip()
	{
		snipAnimation.Play();
		snipSound.Play();
	}
}

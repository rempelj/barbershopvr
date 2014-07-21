using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Scissors : MonoBehaviour {

	public Animation snipAnimation;
	public float snipRate;
	public GameObject hairContainer;
	
	private List<Hair> allHairs;
	private Hair currentTarget;
	
	private bool mStopped;
	public bool stopped {
		get { return mStopped; }
		set { 
			mStopped = value;
			snipAnimation.enabled= !value;
		}
	}
	
	public AudioSource stabSound;
	public AudioSource snipSound;
	
	private float lastSnipTime;

	void Awake() {
	
	}

	// Use this for initialization
	void Start () {
		allHairs = new List<Hair>();
		
		var children = hairContainer.GetComponentsInChildren<Transform>();
		foreach (var child in children) {
			var row = child.GetComponentsInChildren<Hair>();
			
			foreach (var hair in row) {
				if (!hair.cut)
					allHairs.Add(hair);
			}
			
			
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!stopped && Time.time > lastSnipTime + snipRate) {
			lastSnipTime = Time.time;
			Snip();
		}
		
		if (currentTarget == null && allHairs.Count > 0) {
			var rnd = new System.Random();
			int index = rnd.Next(0, allHairs.Count);
			currentTarget = allHairs[index];
			allHairs.RemoveAt(index);
		} 
		
		if (currentTarget != null) {
			if (!stopped)
			{
				transform.position = Vector3.Lerp(transform.position, currentTarget.transform.position, 3 * Time.deltaTime);
				transform.LookAt(currentTarget.transform);
			}
		}
	}
	
	void OnTriggerStay(Collider other) {	
		var hair = other.transform.GetComponent<Hair>();
		if (hair != null && snipAnimation.isPlaying) {
			other.gameObject.rigidbody.useGravity = true;
			allHairs.Remove(hair);
			hair.cut = true;
			currentTarget = null;
		}
	}
	
	public void Snip()
	{
		snipAnimation.Play();
		snipSound.Play();
	}
}

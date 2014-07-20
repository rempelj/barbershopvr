using UnityEngine;
using System.Collections;

public class ScissorSpawner : MonoBehaviour {

	public Transform scissorsPrefab;
	public GameObject hairContainer;

	// Use this for initialization
	void Start () {
		Spawn();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void Spawn()
	{
		Transform t = Instantiate(scissorsPrefab, transform.position, transform.rotation) as Transform;
		
		var s = t.GetComponent<Scissors>();
		
		s.hairContainer = hairContainer;
	}
}

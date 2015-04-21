using UnityEngine;
using System.Collections;

public class SoundCube : MonoBehaviour {

	public Vector3 startPosition;
	public GameObject soundcube;

	// Use this for initialization
	void Start () {
		startPosition = this.gameObject.transform.position;
		soundcube = this.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

using UnityEngine;
using System.Collections;

public class SoundCubeLabel : MonoBehaviour {

	public Vector3 labelPosition;

	// Use this for initialization
	void Start () {
		labelPosition = new Vector3 (20, 30, -35);
		iTween.FadeTo(this.gameObject, iTween.Hash ("alpha", 0, "time", .5f));
	}
	
	// Update is called once per frame
	void Update () {
		//var rotation = Quaternion.LookRotation(Vector3.up , Vector3.forward);
		//var rotation = Quaternion.LookRotation(Vector3.forward);
		this.transform.rotation = Quaternion.Euler (0, 0, 0);
		//transform.rotation = rotation;
		//this.transform.localPosition = labelPosition;
	}
}

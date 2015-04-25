/******************************************************************************\
* Copyright (C) Leap Motion, Inc. 2011-2014.                                   *
* Leap Motion proprietary. Licensed under Apache 2.0                           *
* Available at http://www.apache.org/licenses/LICENSE-2.0.html                 *
\******************************************************************************/

using UnityEngine;
using System.Collections;

public class GrabbableCube : GrabbableObject {
/*	
	public bool useAxisAlignment = false;
	public Vector3 rightHandAxis;
	public Vector3 objectAxis;
	
	public bool rotateQuickly = true;
	public bool centerGrabbedObject = false;
	
	public Rigidbody breakableJoint;
	public float breakForce;
	public float breakTorque;
	
	protected bool grabbed_ = false;
	protected bool hovered_ = false;*/

	//public GameObject label;

	//[SerializeField]
	//private Texture2D texture = null;

	[SerializeField]
	public GUIContent content;

	private GUIStyle style;
	public GUISkin skin;

	public void Start() {
		/*if (this.gameObject.transform.Find ("Label") != null) {
			label = this.gameObject.transform.Find ("Label").gameObject;
			var text = label.GetComponent<TextMesh> ().text;
			Debug.Log (text);
		}*/

		style = new GUIStyle();
		//style.fontStyle = FontStyle.Bold;
		style.normal.textColor = new Color(0, 0, 0, 0);
	}
	/*
	public bool IsHovered() {
		return hovered_;
	}
	
	public bool IsGrabbed() {
		return grabbed_;
	}*/
	
	public override void OnStartHover() {
		hovered_ = true;
	}
	
	public override void OnStopHover() {
		hovered_ = false;
	}
	
	public override void OnGrab() {
		grabbed_ = true;
		hovered_ = false;
		//Debug.Log ("Grabbed cube yo");
		/*if (label != null) {
			Debug.Log ("label fade in");
			iTween.FadeTo (label, iTween.Hash ("alpha", 1, "time", .5f));
		}*/
		if (breakableJoint != null) {
			Joint breakJoint = breakableJoint.GetComponent<Joint>();
			if (breakJoint != null) {
				breakJoint.breakForce = breakForce;
				breakJoint.breakTorque = breakTorque;
			}
		}
	}
	
	public override void OnRelease() {
		grabbed_ = false;
		/*
		if (label != null) {
			iTween.FadeTo (label, iTween.Hash ("alpha", 0, "time", .5f));
		}	*/	
		if (breakableJoint != null) {
			Joint breakJoint = breakableJoint.GetComponent<Joint>();
			if (breakJoint != null) {
				breakJoint.breakForce = Mathf.Infinity;
				breakJoint.breakTorque = Mathf.Infinity;
			}
		}
	}

	private void OnGUI () {	
		//var position = this.gameObject.transform.position;
		//var rect = new Rect (64, 64, 512, 64);
		var rect = new Rect (Screen.width - 320, 64, 256, 64);
		
		//var rect = new Rect (10, 10, 256, 32);
		GUI.skin = skin;
		if (grabbed_) {
			GUI.Label (rect, content, style);
			var color = new Color(0, 0, 0, 1);
			style.normal.textColor = color;
			//iTween.ColorTo (GUI.Label, color, .5f);
		}
	}
	
}

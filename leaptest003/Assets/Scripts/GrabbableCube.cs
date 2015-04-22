/******************************************************************************\
* Copyright (C) Leap Motion, Inc. 2011-2014.                                   *
* Leap Motion proprietary. Licensed under Apache 2.0                           *
* Available at http://www.apache.org/licenses/LICENSE-2.0.html                 *
\******************************************************************************/

using UnityEngine;
using System.Collections;

public class GrabbableCube : GrabbableObject {
	
	public bool useAxisAlignment = false;
	public Vector3 rightHandAxis;
	public Vector3 objectAxis;
	
	public bool rotateQuickly = true;
	public bool centerGrabbedObject = false;
	
	public Rigidbody breakableJoint;
	public float breakForce;
	public float breakTorque;
	
	protected bool grabbed_ = false;
	protected bool hovered_ = false;

	public GameObject label;

	public void Start() {
		label = this.gameObject.transform.Find ("Label").gameObject;
	}

	public bool IsHovered() {
		return hovered_;
	}
	
	public bool IsGrabbed() {
		return grabbed_;
	}
	
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
		if (label != null) {
			iTween.FadeTo (label, iTween.Hash ("alpha", 1, "time", .5f));
		}
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

		if (label != null) {
			iTween.FadeTo (label, iTween.Hash ("alpha", 0, "time", .5f));
		}		
		if (breakableJoint != null) {
			Joint breakJoint = breakableJoint.GetComponent<Joint>();
			if (breakJoint != null) {
				breakJoint.breakForce = Mathf.Infinity;
				breakJoint.breakTorque = Mathf.Infinity;
			}
		}
	}
}

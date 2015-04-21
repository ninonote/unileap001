/******************************************************************************\
* Copyright (C) Leap Motion, Inc. 2011-2014.                                   *
* Leap Motion proprietary. Licensed under Apache 2.0                           *
* Available at http://www.apache.org/licenses/LICENSE-2.0.html                 *
\******************************************************************************/

using UnityEngine;
using System.Collections;

public class GrabbableSphere : GrabbableObject {
	
	public bool IsHovered() {
		Debug.Log ("YO");
		return hovered_;
	}
	
	public bool IsGrabbed() {
		Debug.Log ("YO");

		return grabbed_;
	}
	
	public void OnStartHover() {
		Debug.Log ("YO");

		hovered_ = true;
	}
	
	public void OnStopHover() {
		Debug.Log ("YO");

		hovered_ = false;
	}
	
	public void OnGrab() {
		grabbed_ = true;
		hovered_ = false;
		Debug.Log ("YO");

		
		if (breakableJoint != null) {
			Joint breakJoint = breakableJoint.GetComponent<Joint>();
			if (breakJoint != null) {
				breakJoint.breakForce = breakForce;
				breakJoint.breakTorque = breakTorque;
			}
		}
	}
	
	public virtual void OnRelease() {
		grabbed_ = false;
		Debug.Log ("YO");

		
		if (breakableJoint != null) {
			Joint breakJoint = breakableJoint.GetComponent<Joint>();
			if (breakJoint != null) {
				breakJoint.breakForce = Mathf.Infinity;
				breakJoint.breakTorque = Mathf.Infinity;
			}
		}
	}
}

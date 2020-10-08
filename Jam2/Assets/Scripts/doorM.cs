using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorM : MonoBehaviour {

    public bool IsLocked = false;
	public float RotationSpeed = 3f;
	private bool Opened = false;
	void FixedUpdate () {
		if(Opened && !IsLocked)
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, transform.eulerAngles.y+90, 0), Time.deltaTime * RotationSpeed);
	}
	public void open()
	{
		Opened = true;
	}
}

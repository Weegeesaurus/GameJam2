using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorM : MonoBehaviour {

    public bool IsLocked = false;
	public float RotationSpeed = 3f;
	public bool NormalRotationCW = true;
	private bool Opened = false;
	private bool LockStart = false;
	private float YStart = 0;
	void Start()
	{
		YStart = transform.eulerAngles.y;
		LockStart = IsLocked;
	}
	void FixedUpdate () {
		if(Opened && !IsLocked)
			if(NormalRotationCW)
				transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, YStart + 90, 0), Time.deltaTime * RotationSpeed);
			else
				transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, YStart - 90, 0), Time.deltaTime * RotationSpeed);
	}
	public void Open()
	{
		if (!IsLocked)
			Opened = true;
	}
	public void Reset()
	{
		Opened = false;
		IsLocked = LockStart;
		transform.eulerAngles = new Vector3(0,YStart,0);
	}
}

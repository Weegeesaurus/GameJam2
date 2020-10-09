using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorM : MonoBehaviour {

    public bool IsLocked = false;
	public float RotationSpeed = 3f;
	private bool Opened = false;
	private bool LockStart;
	private float YStart = 0;
	private int cw = 1;
	void Start()
	{
		YStart = transform.eulerAngles.y;
		LockStart = IsLocked;
	}
	void FixedUpdate () {
		if(Opened && !IsLocked)
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, YStart+ cw * 90, 0), Time.deltaTime * RotationSpeed);
	}
	public void OpenClockWise()
	{
		if (!IsLocked)
			Opened = true;
	}
	public void OpenCounterClockWise()
	{
		if (!IsLocked)
		{
			Opened = true;
			cw = -1;
		}
	}
	public void Unlock()
	{
		IsLocked = false;
	}
	public void Reset()
	{
		Opened = false;
		IsLocked = LockStart;
		transform.eulerAngles = (0,YStart,0);
	}
}

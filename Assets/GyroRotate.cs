using UnityEngine;
using System.Collections;

public class GyroRotate : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
		//Input..enabled = true;
	}
	
	void Update () 
	{
		transform.Rotate (Input.acceleration.x, Input.acceleration.y, 0);	
	}
}

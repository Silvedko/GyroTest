using UnityEngine;
using System.Collections;

public class JoystickLook : MonoBehaviour 
{
	[SerializeField]
	NonVRJoystick joystick;

	[SerializeField]
	float speed = 2f;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void LateUpdate () 
	{
		Camera.main.transform.Rotate (Vector3.up, joystick.Horizontal() * speed, Space.World);
		Camera.main.transform.Rotate (Vector3.left, joystick.Vertical() * speed, Space.Self);
	}
}

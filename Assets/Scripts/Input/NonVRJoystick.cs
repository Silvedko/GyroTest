using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class NonVRJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
	public bool isPressed = false;

	private Image bgImage;
	private Image joystickImage;
	private Vector3 inputVector;

	void Awake () 
	{
		bgImage = GetComponent <Image> ();
		joystickImage = transform.GetChild (0).GetComponent <Image> ();
	}

	public void SetActiveJoystick (bool isActive) 
	{
		bgImage.enabled = isActive;
		joystickImage.enabled = isActive;
	}

	public virtual void OnPointerDown (PointerEventData eventData)
	{
		isPressed = true;
		OnDrag (eventData);
	}

	public virtual void OnPointerUp (PointerEventData eventData)
	{
		isPressed = false;
		inputVector = Vector3.zero;
		joystickImage.rectTransform.anchoredPosition = Vector3.zero;
	}
		

	public void OnDrag (PointerEventData data)
	{
		Vector2 pos;
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle (bgImage.rectTransform, data.position, data.pressEventCamera, out pos)) 
		{
			pos.x = (pos.x / bgImage.rectTransform.sizeDelta.x);
			pos.y = (pos.y / bgImage.rectTransform.sizeDelta.y);

			inputVector = new Vector3 (pos.x * 2 + 1, 0, pos.y * 2 - 1);
			inputVector = (inputVector.magnitude > 1) ? inputVector.normalized : inputVector;
			joystickImage.rectTransform.anchoredPosition = new Vector3 (inputVector.x * bgImage.rectTransform.sizeDelta.x / 4,
																		inputVector.z * bgImage.rectTransform.sizeDelta.y / 4);
		}
	}

	public float Horizontal ()
	{
		if (inputVector.x != 0)
			return inputVector.x;
		else
			return Input.GetAxis ("Horizontal");
	}

	public float Vertical ()
	{
		if (inputVector.z != 0)
			return inputVector.z;
		else
			return Input.GetAxis ("Vertical");
	}

}

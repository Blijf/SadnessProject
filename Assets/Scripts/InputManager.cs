using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//static de esta forma tenemos acceso rápido a los métodos en las otras clases
public static class InputManager
{
	//MOVIMIENTO
	public static float MainHorizontal()
	{
		float r = 0.0f;
		r+= Input.GetAxis("Horizontal");//joystick

		return Mathf.Clamp(r,-1.0f,1.0f); //valor medio entre dos valores
	}
	public static float MainVertical()
	{
		float r = 0.0f;
		r+= Input.GetAxis("Vertical");//keyboard

		return Mathf.Clamp(r,-1.0f,1.0f); //valor medio entre dos valores
	}
	//BOTONES
	public static bool dashButton()
	{

		return Input.GetButtonDown("Dash");
	}

}

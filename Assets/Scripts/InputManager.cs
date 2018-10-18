using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//static de esta forma tenemos acceso rápido a los métodos en las otras clases
public static class InputManager
{
	//MOVIMIENTO
	public static float MainHorizontal()
	{
		return Input.GetAxis ("Horizontal");
	}
	public static float MainVertical()
	{
		return Input.GetAxis ("Vertical");
	}
	//BOTONES
	public static bool dashButton()
	{
		return Input.GetButtonDown("Dash");
	}

}

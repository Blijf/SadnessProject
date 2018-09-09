using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//clase la cual ejecutara todo los métodos del player
public class PlayerController : MonoBehaviour 
{
	public float life,speed,damage;
	private Player player;
	
	void Start () 
	{
		Character character= new Character(life, damage, speed);
		player = (Player) character;//usamos polimorfismo
	}
	
	void Update () 
	{
		//------------------MOVIMIENTO------------------------
		//		 tanto del teclado como del yoystick
		//----------------------------------------------------
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		
		Vector2 movement= new Vector2(moveHorizontal,moveVertical);

		this.transform.Translate(movement*speed*Time.deltaTime);
	}

}

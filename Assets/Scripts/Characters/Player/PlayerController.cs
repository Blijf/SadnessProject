using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//clase la cual ejecutara todo los métodos del player
public class PlayerController : MonoBehaviour 
{
	public float life,speed,damage;
	private float moveHorizontal,moveVertical;
	private Player player;
	private Rigidbody2D rb;
	
	void Start () 
	{
		rb= GetComponent<Rigidbody2D>();
		player= new Player(life, damage, speed,rb);
	}
	
	void Update () 
	{

		 moveHorizontal = Input.GetAxis("Horizontal");
		 moveVertical = Input.GetAxis("Vertical");

	}

	void FixedUpdate() 
	{
		//------------------MOVIMIENTO------------------------
		//		 Tanto del teclado como del yoystick
		//----------------------------------------------------
		player.move(moveHorizontal,moveVertical);

 	}
}

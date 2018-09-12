using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//clase la cual ejecutara todo los métodos del player
public class PlayerController : MonoBehaviour 
{
	//VARIABLES
	[Header("Caractrísticas del personaje")]
	public float life;
	public float damage;
	[Header("Movimiento")]
	public float speed;
	public float dashDistance;
	public float dashCooldown;
	
	private float moveHorizontal,moveVertical;
	private Player player;
	private Rigidbody2D rb;
	private float dashClick;

	void Start () 
	{
		rb= GetComponent<Rigidbody2D>();
		player= new Player(life, damage, speed,dashDistance,dashCooldown,rb);

	}
	
	void Update () 
	{
		//------------------INPUTS------------------------
		//movimiento
		 moveHorizontal = Input.GetAxis("Horizontal");
		 moveVertical = Input.GetAxis("Vertical");
		//dash
		dashClick=Input.GetAxis("Dash");//botón segundario del ratón
	}

	void FixedUpdate() 
	{
		//------------------MOVIMIENTO------------------------
		//		 Tanto del teclado como del yoystick
		//----------------------------------------------------
		player.move(moveHorizontal,moveVertical);
		//---------------------DASH------------------------
		//		 Salto del personaje a una dirección
		//----------------------------------------------------
		player.dash(dashClick);

 	}
}

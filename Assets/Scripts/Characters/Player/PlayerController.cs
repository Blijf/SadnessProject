using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//clase la cual ejecutara todo los métodos del player
public class PlayerController : MonoBehaviour 
{
	
	//-------------------------------------------------
	//					VARIABLES
	//-------------------------------------------------
	[Header("Caractrísticas del personaje")]
	public int health;
	public int damage;
	[Header("Movimiento")]
	public float speed=0.1f;
	[Header("Dash")]
	public float dashDistance;
	public float dashCooldown;
	[Header("Otros")]
	private float moveHorizontal,moveVertical;
	private bool dashClick;
	
	private Rigidbody playerRigibody;
	private Vector3 vectorMove;
	private Animator anim;
	private Quaternion quartenionRot;
	
	//-------------------------------------------------
	//				MAIN METHODS
	//-------------------------------------------------
	void Start () 
	{
		playerRigibody= GetComponent<Rigidbody>();
		anim=GetComponent<Animator>();
	}
	
	void Update () 
	{
		//INPUTS
		//movimiento
		 moveHorizontal = InputManager.MainHorizontal();
		 moveVertical = InputManager.MainVertical();
		//dash
		dashClick=InputManager.dashButton();//botón segundario del ratón y A

	}

	void FixedUpdate() 
	{
		//MOVIMIENTO
		//Tanto del teclado como del yoystick
		move();
		//DASH
		//Salto del personaje a una dirección

		//ANIMACIONES
		animating();

 	}

	//-------------------------------------------------
	//					METHODS
	//-------------------------------------------------
	private void move()
	{
		if(moveHorizontal!=0f || moveVertical!=0f)
		{
			vectorMove.Set(moveHorizontal,0f,moveVertical);//la y es 0 ya que no se movera verticalmente
			vectorMove=vectorMove.normalized*speed*Time.deltaTime;

			playerRigibody.MovePosition(transform.position + vectorMove);

			quartenionRot= Quaternion.LookRotation(vectorMove);
			playerRigibody.MoveRotation(quartenionRot);

		}
		else
		{
			transform.rotation= quartenionRot;
		}
		
	}

	private void animating()
	{
		//movimiento
		bool move=moveHorizontal!=0f || moveVertical!=0f;
		anim.SetBool("isMove",move);

		//Ataque basico espada

	}

}

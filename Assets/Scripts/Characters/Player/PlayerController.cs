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
	private bool dashClick,attack1Click;
	//__________________________________________________
	//Varianles internas
	Rigidbody playerRigibody;
	Vector3 vectorMove;
	Animator anim;
	bool playerIsMoving;
	Quaternion quartenionRot;
	//__________________________________________________
	//Fmod
	[FMODUnity.EventRef]
	public string stepsSound;


	//-------------------------------------------------
	//				MAIN METHODS
	//-------------------------------------------------
	void Start () 
	{
		playerRigibody= GetComponent<Rigidbody>();
		anim=GetComponent<Animator>();

		InvokeRepeating("callFootStepsSound",0,speed);
	}
	
	void Update () 
	{
		//INPUTS
		//movimiento
		 moveHorizontal = InputManager.MainHorizontal();
		 moveVertical = InputManager.MainVertical();
		//dash
		dashClick=InputManager.dashButton();//botón segundario del ratón y A
		//ataque 1
		attack1Click=InputManager.attack1Button();
		
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
		//Se mueve
		if(moveHorizontal!=0f || moveVertical!=0f)
		{
			vectorMove.Set(moveHorizontal,0f,moveVertical);//la y es 0 ya que no se movera verticalmente
			vectorMove=vectorMove.normalized*speed*Time.deltaTime;

			playerRigibody.MovePosition(transform.position + vectorMove);

			quartenionRot= Quaternion.LookRotation(vectorMove);
			playerRigibody.MoveRotation(quartenionRot);

			playerIsMoving=true;
			//reproducimos el sonido de pasos cada vez que el personaje esta en movimiento.
			FMODUnity.RuntimeManager.PlayOneShot(stepsSound);

		}
		else
		{
			playerIsMoving=false;
			transform.rotation= quartenionRot;
		}
		
	}

	void animating()
	{
		//movimiento
		anim.SetBool("isMove",playerIsMoving);

		bool attack= attack1Click;
		//Ataque basico espada
		anim.SetBool("isAttack", attack);
	}

	
}

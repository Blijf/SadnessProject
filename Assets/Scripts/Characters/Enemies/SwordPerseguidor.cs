using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordPerseguidor : MonoBehaviour 
{
	//-------------------------------------------------
	//					VARIABLES
	//-------------------------------------------------
	public int damage;

	//__________________________________________________
	GameObject playerGameObject;
	PlayerHealth playerHealth;
	Animator animator;
	bool isAvaliableToAttack;

	//-------------------------------------------------
	//				MAIN METHODS
	//-------------------------------------------------
	void Start () 
	{
		playerGameObject= GameObject.FindGameObjectWithTag ("Player");
		playerHealth = playerGameObject.GetComponent <PlayerHealth> ();
		animator= GetComponentInParent<Animator>();
		isAvaliableToAttack=true;
		
	}
	
	void Update () 
	{	
		Debug.Log(isAvaliableToAttack);
	}

	//La espada entra en contacto con el personaje
	void OnTriggerEnter(Collider enterCollider)
	{
		//Comprobamos si es el player el que se esta dañando, si no esta muerto y si esta haciendo el daño con animación activa.
		if(enterCollider.gameObject == playerGameObject && playerHealth.currentHealth>0 && 
			animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") && isAvaliableToAttack == true)
		{
			//El daño se realice solamente una vez
			playerHealth.takeDamage(damage);
			Debug.Log(this.name+": ha hecho daño al player");

			isAvaliableToAttack=false;

			//Espera un segundo, el daño esta activo durante este tiempo
			StartCoroutine(Timers.perseguidorAttack());

		}
	}

	void OnTriggerExit(Collider exitCollider)
	{
		if(exitCollider.gameObject == playerGameObject)
		{
			Debug.Log(this.name+": el player ha salido");
			isAvaliableToAttack=true;
		}
	}
	//-------------------------------------------------
	//					METHODS
	//-------------------------------------------------

}

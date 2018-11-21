using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordPerseguidor : MonoBehaviour 
{
	//-------------------------------------------------
	//					VARIABLES
	//-------------------------------------------------
	public int damage;
	public Perseguidor perseguidor;

	//__________________________________________________
	GameObject playerGameObject;
	PlayerHealth playerHealth;
	Animator animator;

	//-------------------------------------------------
	//				MAIN METHODS
	//-------------------------------------------------
	void Start () 
	{
		playerGameObject= GameObject.FindGameObjectWithTag ("Player");
		playerHealth = playerGameObject.GetComponent <PlayerHealth> ();
		animator= GetComponentInParent<Animator>();
		
	}
	
	void Update () 
	{	
		
	}

	//La espada entra en contacto con el personaje
	void OnTriggerEnter(Collider enterCollider)
	{
		//Comprobamos si es el player el que se esta dañando, si no esta muerto y si esta haciendo el daño con animación activa.
		if(enterCollider.gameObject == playerGameObject && playerHealth.currentHealth>0 && 
			animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") )
		{
			playerHealth.takeDamage(damage);
			Debug.Log(this.name+": ha hecho daño al player");
		}
	}
	//-------------------------------------------------
	//					METHODS
	//-------------------------------------------------

}

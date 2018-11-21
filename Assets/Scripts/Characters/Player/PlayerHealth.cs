using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

	//-------------------------------------------------
	//					VARIABLES
	//-------------------------------------------------
	[Header("Variables de la vida")]
	public int startingHealth = 100; //vida inicial
	//__________________________________________________
	Animator anim;//animación de daño y muerte.
	bool isDead; //saber si el personaje a muerto.
    bool damaged; //saber si el personaje es dañado.
	PlayerController playerController;
	
	//-------------------------------------------------
	//					PROPIEDADES
	//-------------------------------------------------
	public int currentHealth{get; set;}//vida actual del personaje.

	//-------------------------------------------------
//						MAIN METHODS
	//-------------------------------------------------
	void Start () 
	{
        anim = GetComponent <Animator> ();
		playerController= GetComponent<PlayerController>();
		currentHealth=startingHealth;
	}
	
	void Update () 
	{
		Debug.Log("Vida actual del personaje: "+currentHealth+"%");
		damaged=false;
	}
	//-------------------------------------------------
	//					METHODS
	//-------------------------------------------------
	//El player muere
	void death()
	{
		isDead=true;
		anim.SetTrigger ("Die");

		playerController.enabled= false;

	}
	//El player recibe daño
	public void takeDamage(int amount)
	{
		damaged = true;
		currentHealth -=amount;

		if(currentHealth<=0 && !isDead)
		{
			death();
		}
	}
}

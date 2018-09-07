using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
	//VARIABLES
	public float life,damage,speed;
	public GameObject characterObject;

	//CONSTRUCTORES
	public Character(){}
	public Character (GameObject character, float life, float damage, float speed)
	{
		this.characterObject= character;
		this.life= life;
		this.damage= damage;
		this.speed= speed;
	}
	
	//MÉTODOS
	public void takeDamage()
	{

	}
}

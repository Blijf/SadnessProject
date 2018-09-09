using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
	//VARIABLES
	public float life{get{return life;}set{life=value;}}
	public float damage,speed;

	//CONSTRUCTORES
	public Character(){}
	public Character (float life, float damage, float speed)
	{
		this.life= life;
		this.damage= damage;
		this.speed= speed;
	}
	
	//MÉTODOS
	public void takeDamage()
	{

	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
	//VARIABLES

	protected float damage {get; set;}
	protected float life {get; set;}
	protected float speed{get; set;}
	protected Rigidbody2D rb{get;set;}

	//CONSTRUCTORES
	public Character(){}
	public Character (float life, float damage, float speed, Rigidbody2D rb)
	{
		this.life= life;
		this.damage= damage;
		this.speed= speed;
		this.rb= rb;
	}
	
	//MÉTODOS
	public void takeDamage()
	{

	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
	//VARIABLES

	protected int damage {get; set;}
	protected int health {get; set;}
	protected float speed{get; set;}
	protected Rigidbody2D rb{get;set;}

	//CONSTRUCTORES
	public Character(){}
	public Character (int health, int damage, float speed, Rigidbody2D rb)
	{
		this.health= health;
		this.damage= damage;
		this.speed= speed;
		this.rb= rb;
	}
	
	//MÉTODOS
	public void takeDamage(int amount){}
}

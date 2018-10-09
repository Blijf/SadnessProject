using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player
{
	private float dashDistance,dashCooldown, currentdashCooldown;
	private Vector2 savedVelocity;
	protected int damage {get; set;}
	protected int health {get; set;}
	protected float speed{get; set;}

	//CONSTRUCTOR
	public Player(){
	}
	public Player (int health, int damage, float speed,float dashDistance,float dashCooldown)
	{
		this.health= health;
		this.damage= damage;
		this.speed= speed;
		this.dashDistance=dashDistance;
		this.dashCooldown=dashCooldown;
		this.currentdashCooldown= dashCooldown;
	}

	//-----------------------------------------------------------------------
    //COMBATE
	//-----------------------------------------------------------------------
    public void doDamage(){

	}
	
    public void takeDamage(int amount, Slider healthSlider)
    {
		health-=amount;
		healthSlider.value= health;
		if(health<=0)
		{
			health=0;
			Debug.Log("Dead!");
		}		
    }
	//-----------------------------------------------------------------------
	//MOVIMIENTO
	//-----------------------------------------------------------------------
	public void move(float moveHorizontal, float moveVertical)
	{


	}

	public void dash(bool dashClick)
	{
		
	}

}

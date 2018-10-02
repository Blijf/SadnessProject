using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Character
{
	private float dashDistance,dashCooldown, currentdashCooldown;
	private Vector2 savedVelocity;

	//CONSTRUCTOR
	public Player(){
	}
	public Player (int health, int damage, float speed,float dashDistance,float dashCooldown,Rigidbody2D rb)
	{
		this.health= health;
		this.damage= damage;
		this.speed= speed;
		this.rb =rb;
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
			//Movimiento
			Vector2 movement_vector= new Vector2 (moveHorizontal, moveVertical);
			movement_vector= movement_vector.normalized*speed;

			rb.velocity= movement_vector*Time.deltaTime;
			// rb.MovePosition(rb.position+movement_vector*Time.deltaTime);
			// this.transform.Translate(movement_vector*Time.deltaTime);

	}

	public void dash(bool dashClick)
	{
		string dashState="";

		//Dash
		//Si se ha pulsado el dash
		if(dashClick){ dashState= "ready";}

		switch(dashState)
		{
			case "ready":
				savedVelocity=rb.velocity;
				rb.velocity= new Vector2 (rb.velocity.x*dashDistance, rb.velocity.y*dashDistance);
				dashState="dashing";

			break;

			case "dashing":
				currentdashCooldown+=Time.deltaTime*dashDistance;

				if(currentdashCooldown>=dashCooldown)
				{
					currentdashCooldown=dashCooldown;
					rb.velocity=savedVelocity;
					dashState="Time";
				}

			break;

			case "Time":
				currentdashCooldown-=Time.deltaTime;
				
				if(currentdashCooldown<=0)
				{
					currentdashCooldown=0;
					dashState="ready";
				}

			break;

		}

	}

}

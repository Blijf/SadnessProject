using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{


	//CONSTRUCTOR
	public Player(){
	}
	public Player (float life, float damage, float speed, Rigidbody2D rb)
	{
		this.life= life;
		this.damage= damage;
		this.speed= speed;
		this.rb =rb;
	}



    //MÉTODOS
    public void doDamage()
	{

	}

	public void move(float moveHorizontal, float moveVertical)
	{

		Vector2 movement_vector= new Vector2 (moveHorizontal, moveVertical);
		rb.MovePosition(rb.position+movement_vector*Time.deltaTime*speed);

							
		// Vector2 movement= new Vector2(moveHorizontal,moveVertical);
		// this.transform.Translate(movement*speed*Time.deltaTime);
	}
}

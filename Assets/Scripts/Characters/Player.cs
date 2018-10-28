using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player
{
	protected int damage {get; set;}
	protected int health {get; set;}

	//CONSTRUCTOR
	public Player(){
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


	public void dash(bool dashClick)
	{
		
	}

}

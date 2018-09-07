using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//clase la cual ejecutara todo los métodos del player
public class PlayerExe : MonoBehaviour 
{
	public float life,speed,damage;
	public GameObject gameObject;
	
	void Start () 
	{
		Character player= new Character(gameObject, life, damage, speed);
	}
	
	void Update () 
	{
		
	}
}

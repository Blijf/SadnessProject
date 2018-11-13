using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Perseguidor : MonoBehaviour {
	//-------------------------------------------------
	//					VARIABLES
	//-------------------------------------------------
	[Header("Caractrísticas del Enemigo")]
	public int health;
	[Header("Seguimiento")]
	public float maxDist = 10;
	[Header("Ataque")]
	public int damage;
	public float cooldown;
	public float distToAttack=1;
	//__________________________________________________
	GameObject targetGameobject;
	Transform targetTransform;
	NavMeshAgent nav;
	Animator anim;
	float distanciaToPLayer;
	bool playerInRange;
	float timer;//contador para el cooldown del ataque
	//-------------------------------------------------
	//				MAIN METHODS
	//-------------------------------------------------
	void Start () 
	{
		targetGameobject= GameObject.FindGameObjectWithTag ("Player");
		targetTransform= targetGameobject.transform;
		nav=GetComponent<NavMeshAgent>();
		anim=GetComponent<Animator>();

	}
	
	void Update () 
	{
		distanciaPlayer();
		aproxMov();

		distToattackPlayer();
		whenAttack();
	}
	
	//-------------------------------------------------
	//					METHODS
	//-------------------------------------------------
	//MOVIMIENTO
	//___________________________________________________
	//El enemigo sigue al personaje cuando se encuentra a una cierta distancia indicada en las variables de arriba.
    void aproxMov ()
	{
        //Movimiento del player cuando este en su area de influencia
        if(distanciaToPLayer <= maxDist)
        {
        //Le indica al enemigo en que posición se encunetra el player en cada momento
            nav.SetDestination (targetTransform.position);
            anim.SetBool("isMove",true);
        }
        else
        {
            anim.SetBool("isMove",false);
			nav.isStopped = true;
			nav.ResetPath();
         }
    }
	
	//calcula la distancia de del player al enemigo.
	void distanciaPlayer()
	{
        distanciaToPLayer = Vector3.Distance(transform.position,targetTransform.position);
	}

	//-------------------------------------------------
	//ATAQUE
	//___________________________________________________
	void distToattackPlayer()
	{
		if (distanciaToPLayer<=distToAttack)
		{	
			playerInRange=true;
		}
		else
		{
			playerInRange=false;
		}
	}
	
	void attack()
	{
		timer=0f;
		anim.SetBool("isAttack", true);
	}


	void whenAttack()
	{
		timer += Time.deltaTime;

		if(timer>=cooldown && playerInRange)
		{
			attack();
		}
		else
		{
			anim.SetBool("isAttack", false);
		}
	}

}


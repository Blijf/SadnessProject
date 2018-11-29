using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PerseguidorController : MonoBehaviour {
	//-------------------------------------------------
	//					VARIABLES
	//-------------------------------------------------
	[Header("Caractrísticas del Enemigo")]
	public int health;
	[Header("Seguimiento")]
	public float maxDist = 10;
	[Header("Ataque")]
	public float cooldown;
	public float distToAttack=1;
	//__________________________________________________
	GameObject playerGameObject;
	Transform playerTransform;
	PlayerHealth playerHealth;
	NavMeshAgent navAgent;
	Animator anim;
	float distanciaToPLayer;
	bool playerInRange;
	float timer;//contador para el cooldown del ataque

	//-------------------------------------------------
	//				MAIN METHODS
	//-------------------------------------------------
	void Start () 
	{
		playerGameObject= GameObject.FindGameObjectWithTag ("Player");
		playerTransform= playerGameObject.transform;
		navAgent=GetComponent<NavMeshAgent>();
		anim=GetComponent<Animator>();
		playerHealth = playerGameObject.GetComponent <PlayerHealth> ();

	}
	
	void Update () 
	{
		//Esta vivo el Player?
		if(playerHealth.currentHealth<=0)
		{
			GetComponent <UnityEngine.AI.NavMeshAgent> ().enabled = false;//el enemigo ya no se moverá.
        	GetComponent <Rigidbody> ().isKinematic = true;// deja de ser influenciado por la físicas del mundo 3D.
		}
		else
		{
			//MOVIMIENTO
			distanciaPlayer();
			aproxMov();

			//ATAQUE
			distToattackPlayer();
			whenAttack();
		}
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
        //Indica al enemigo en que posición se encunetra el player en cada momento
            navAgent.SetDestination (playerTransform.position);
            anim.SetBool("isMove",true);
        }
        else
        {
            anim.SetBool("isMove",false);
			navAgent.isStopped = true;
			navAgent.ResetPath();//limpia el camino actual
         }
    }
	
	//calcula la distancia del player al enemigo.
	void distanciaPlayer()
	{
        distanciaToPLayer = Vector3.Distance(transform.position,playerTransform.position);
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

		//para mientras el ataque esta activo
		navAgent.isStopped = true; 
		// anim.SetTrigger("isAttack");

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
			// anim.SetTrigger("isAttack");

		}


	}
}


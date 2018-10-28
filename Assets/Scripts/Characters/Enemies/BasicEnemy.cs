using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicEnemy : MonoBehaviour {
	//-------------------------------------------------
	//					VARIABLES
	//-------------------------------------------------
	private GameObject targetGameobject;
	private Transform targetTransform;
	private NavMeshAgent nav;
	private Animator anim;
	[Header("Caractrísticas del Enemigo")]
	[Header("Seguimiento")]
	public float maxDist = 10;
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
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		aproxMov();
		// nav.SetDestination (targetTransform.position);

	}

	//-------------------------------------------------
	//					METHODS
	//-------------------------------------------------
	//el enemigo sigue al personaje cuando se encuentra a una cierta distancia indicada en las variables de arriba.
    void aproxMov (){
    // aproximación por
        float distanciaToPLayer = Vector3.Distance(transform.position,targetTransform.position);
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
			
        }
    }
}


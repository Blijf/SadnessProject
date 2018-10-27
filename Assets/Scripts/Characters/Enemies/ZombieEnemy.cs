using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieEnemy : MonoBehaviour {
	//-------------------------------------------------
	//					VARIABLES
	//-------------------------------------------------
	private GameObject targetGameobject;
	private Transform targetTransform;
	private NavMeshAgent nav;
	private Animator anim;
	[Header("Caractrísticas del Enemigo")]
	public float distInfluencia=10f;
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
	void Update () 
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
        float distanciaToPLayer = Vector3.Distance(targetTransform.position, transform.position);
        //Movimiento del player cuando este en su area de influencia
        if(distanciaToPLayer < distInfluencia)
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


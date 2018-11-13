using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class lighFollow : MonoBehaviour {
	//-------------------------------------------------
	//					VARIABLES
	//-------------------------------------------------
	public GameObject targetGameobject; 
	Transform targetTransform;
	public float maxDist = 10;
	Light light ;
	//-------------------------------------------------
	//					MAIN METHODS
	//-------------------------------------------------

	void Start()
	{
		light= GetComponent<Light>();
		light.enabled=false;
	}
		 
	void Update () 
	{
		follow();
	}
	//-------------------------------------------------
	//					METHODS
	//-------------------------------------------------
	
	//Se activa cuando el objetivo esta cerca.
	void follow()
	{		

		targetTransform=targetGameobject.transform;
 
         if (Vector3.Distance(transform.position, targetTransform.position) <= maxDist)
         {
 
			transform.LookAt(targetTransform.position);
			light.enabled=true;

         } 
		 else
		 {
			light.enabled=false;
		 }
	}


}

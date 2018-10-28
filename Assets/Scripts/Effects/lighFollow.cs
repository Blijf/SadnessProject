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

	//-------------------------------------------------
	//					MAIN METHODS
	//-------------------------------------------------
	
	void Update () 
	{
		targetTransform=targetGameobject.transform;
		follow();
	}
	//-------------------------------------------------
	//					METHODS
	//-------------------------------------------------
	void follow()
	{		

 
         if (Vector3.Distance(transform.position, targetTransform.position) <= maxDist)
         {
 
			transform.LookAt(targetTransform.position);
 
         }
	}


}

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
		transform.LookAt(targetTransform.position);
	}


}

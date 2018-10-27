using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SweetAndSour.Effects{

	public class floating : MonoBehaviour {
	//-------------------------------------------------
	//					VARIABLES
	//-------------------------------------------------
		[Header("AMPLITUDE")]
		public float frequency = 0.2f;
		public float amplitude = 0.1f;
		[Header("ROTATION")]
		public float degreesPerSecond = 2f;
		public float maxRotate=0.0f;
		public float minRotate=30.0f;
		public bool isRightRotate= true;

		// Position Storage Variables
		private Vector3 posOffset = new Vector3 ();
		private Vector3 tempPos = new Vector3 ();
	
		//-------------------------------------------------
		//				MAIN METHODS
		//-------------------------------------------------
		void Start () 
		{
			// Store the starting position & rotation of the object
			posOffset = transform.position;
		}
		
		void Update () 
		{
			
			//ROTATION
			float rotationSpeed= Time.deltaTime * degreesPerSecond;

			switch(isRigthRotation())
			{
				case true: 		
					transform.Rotate(new Vector3(-rotationSpeed,0,0), Space.World);
					break;
				case false:
					transform.Rotate(new Vector3(rotationSpeed,0,0), Space.World);
					break;	
			}

			//AMPLITUDE
			// Float up/down with a Sin()
			tempPos = posOffset;
			tempPos.y += Mathf.Sin (Time.fixedTime * Mathf.PI * frequency) * amplitude;
		
	
			transform.position = new Vector3(transform.position.x,tempPos.y,transform.position.z);
		}
		//-------------------------------------------------
		//					MÉTODOS
		//-------------------------------------------------
		private bool isRigthRotation()
		{
			float currentrot=transform.rotation.eulerAngles.x;
			if(currentrot==maxRotate)
			{
				isRightRotate=false;
			}
			else if(currentrot==minRotate)
			{
				isRightRotate=true;
			}

			return isRightRotate;
		}
}

	
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SweetAndSour.Camera
{
	
	public class TopDownCamera : MonoBehaviour 
	{
		//-------------------------------------------------
		//					VARIABLES
		//-------------------------------------------------
		private Transform target;//objeto a seguir
		public GameObject targetGameobject;
		public float Height=15;//zoom de la cámara
		public float distance=20; 
		public float angle=30;
		public float speed=0.5f;

		private Vector3 refVelocity;
		//-------------------------------------------------
		//					MAIN METHODS
		//-------------------------------------------------
		// Use this for initialization
		void Start () 
		{
			targetGameobject= GameObject.FindGameObjectWithTag ("Player");
			target=targetGameobject.transform;
			cameraRun();
		}
		
		// Update is called once per frame
		void Update () 
		{
			cameraRun();
		}
		//-------------------------------------------------
		//					MÉTODOS
		//-------------------------------------------------
		protected virtual void cameraRun()
		{
			if(!target)
			{
				return;
			}

			//distancia y altura determinan el vecto de posición global de la cámara
			Vector3 worldPosition = (Vector3.forward*-distance)+(Vector3.up*Height);
			// Debug.DrawLine(target.position, worldPosition, Color.red);

			Vector3 rotatedVector= Quaternion.AngleAxis(angle, Vector3.up)*worldPosition;
			// Debug.DrawLine(target.position, rotatedVector, Color.green);

			//mover nuestra posición
			Vector3 targetPosition= target.position;
			targetPosition.y=0f;//solamente se mueve z y x
			Vector3 finalPosition = targetPosition+rotatedVector;//posición final de la cá
			//Debug.DrawLine(target.position, finalPosition, Color.blue);

			transform.position= Vector3.SmoothDamp(transform.position,finalPosition, ref refVelocity,speed);
			transform.LookAt(target.position);

		}

		private void OnDrawGizmos() 
		{
			if(target)
			{
				Gizmos.DrawLine(transform.position, target.position);
				// Gizmos.DrawSphere(target.position,1.5f);
			}
			// Gizmos.DrawSphere(transform.position,1.5f);
		}
	}
}

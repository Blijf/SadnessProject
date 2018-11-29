using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Timers
{
	//-------------------------------------------------
	//					VARIABLES, seg
	//-------------------------------------------------
	public const int timePerseguidorAttack=2;

	//-------------------------------------------------
	//					METHODS
	//-------------------------------------------------
	public static IEnumerator globalTimer(int sec)
	{
		yield return new WaitForSeconds(sec);
	}
	public static IEnumerator perseguidorAttack()//duración del ataque del enemigo perseguidor
	{
		yield return new WaitForSeconds(timePerseguidorAttack);
	}
}

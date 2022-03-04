using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaAccumulator : MonoBehaviour
{
	[SerializeField] private float accumulationTime;


	[SerializeField] private Abillity ability;
	[SerializeField] private Abillity ultimateAbility;

	private float staminaValue;

	public void StartAccumulat() {
		staminaValue = 0;
	}

	private void Update()	{
		staminaValue += Time.deltaTime;
	}

	public Abillity GetAbbility() {
		if (staminaValue > accumulationTime)
		{
			return ultimateAbility;
		}
		return ability;
	}
}

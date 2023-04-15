using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
	public float enemyLife = 100f;
	public float revivalLife = 100f;
	public AudioSource revivalClip;

	public void EnemyTakeDamage(float amount)
	{
		enemyLife -= amount;
		if (enemyLife <= 0) 
		{
			EnemyDeath ();
		}
	}

	void EnemyDeath()
	{
		bool isALiar = (Random.value > 0.5f);
		if (isALiar == true)
		{
			revivalClip.Play();
			enemyLife += revivalLife;
			Debug.Log ("Enemy is revived");
		} 
		else
		{
			Destroy (gameObject);
		}
	}
}

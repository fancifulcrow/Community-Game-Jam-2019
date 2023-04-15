using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
	public int attackFromEnemy = 30;
	public GameObject player;
	public AudioSource attackClip;

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Player") 
		{	
			PlayerHealth playerHealth = player.GetComponent<PlayerHealth> ();
			playerHealth.TakeDamage (attackFromEnemy);
			attackClip.Play();
		}
	}
}

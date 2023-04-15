using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUp : MonoBehaviour
{
	public GameObject player;
	public AudioSource goodClip;
	public AudioSource badClip;

   void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player")) 
		{
			Pickup(other);
			Destroy(gameObject);
		}
	}

	void Pickup (Collider Player)
	{
		int number = Random.Range (1, 7);

		if (number == 1) 
		{
			PlayerHealth playerHealth = player.GetComponent<PlayerHealth> ();
			playerHealth.TakeDamage (-10);
			goodClip.Play();
		} 
		else if (number == 2) 
		{
			PlayerHealth playerHealth = player.GetComponent<PlayerHealth> ();
			playerHealth.TakeDamage (10);
			badClip.Play();
		}
		else if (number == 3) 
		{
			PlayerHealth playerHealth = player.GetComponent<PlayerHealth> ();
			playerHealth.TakeDamage (-20);
			goodClip.Play();
		}
		else if (number == 4) 
		{
			PlayerHealth playerHealth = player.GetComponent<PlayerHealth> ();
			playerHealth.TakeDamage (20);
			badClip.Play();
		}
		else if (number == 5) 
		{
			PlayerHealth playerHealth = player.GetComponent<PlayerHealth> ();
			playerHealth.TakeDamage (30);
			goodClip.Play();
		}
		else
		{
			PlayerHealth playerHealth = player.GetComponent<PlayerHealth> ();
			playerHealth.TakeDamage (-30);
			badClip.Play();
		}
	}
}

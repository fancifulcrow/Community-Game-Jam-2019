using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
	public Transform gunPoint;
	public float gunDamage = 10f;
	public LineRenderer lineRenderer;
	public GameObject impactEffect;
	public float pokeForce = 1;
	public float range = 100f;
	private AudioSource shootClip;

    void Start ()
	{
		shootClip = GetComponent<AudioSource>();
	}

	// Update is called once per frame
    void Update()
    { 
		if (Input.GetButtonDown("Jump")) 
		{
			shootClip.Play();
			StartCoroutine(Shoot());
		}
    }

	IEnumerator Shoot()
	{
		RaycastHit hit;
		if (Physics.Raycast (gunPoint.transform.position, gunPoint.forward, out hit, range)) {
			EnemyHealth enemyHealth = hit.transform.GetComponent<EnemyHealth> ();

			if (enemyHealth != null) {
				enemyHealth.EnemyTakeDamage (gunDamage);
				hit.rigidbody.AddForceAtPosition (hit.point * pokeForce, hit.point);
			}

			lineRenderer.enabled = true;

			GameObject impactObject = Instantiate (impactEffect, hit.point, Quaternion.identity);

			yield return  new WaitForSeconds (0.02f);

			Destroy (impactObject);
			lineRenderer.enabled = false;
		} else {
			lineRenderer.enabled = true;
			yield return  new WaitForSeconds (0.02f);
			lineRenderer.enabled = false;
		}
	}
}
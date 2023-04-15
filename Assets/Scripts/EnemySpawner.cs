using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	public GameObject enemy;
	public float spawnTime = 10f;
	public float height = 1f;
	private float countdown;

	// Start is called before the first frame update
    void Start()
    {
		countdown = spawnTime;
    }

    // Update is called once per frame
    void Update()
    {
		countdown -= Time.deltaTime;
		if (countdown <= 0f) 
		{
			SpawnEnemy ();
			countdown = spawnTime;
		}
    }

	void SpawnEnemy()
	{
		float x = Random.Range(-24, 24);
		float y = height;
		float z = Random.Range(-24, 24);
		
		Vector3 generatedPosition = new Vector3 (x, y, z); 

		Instantiate(enemy, generatedPosition, transform.rotation);
	}
}
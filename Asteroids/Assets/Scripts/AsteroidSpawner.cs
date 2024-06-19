using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public Asteroid asteroidPrefab;
    public float spawnRate = 2f;
    public float spawnDistance = 15.0f;
    public float spawnAmount = 1f;

    public float trajectoryVariance = 15.0f;

    private void Start()
    {
        InvokeRepeating("Spawn", spawnRate,spawnRate);
    }

    void Spawn()
    {
        for(int i = 0; i < spawnAmount; i++)
        {
            Vector3 spawnDirection = Random.insideUnitCircle.normalized * spawnDistance;
            Vector3 spawnPoint = transform.position + spawnDirection;

            float variance = Random.Range(-trajectoryVariance, trajectoryVariance);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

            Asteroid asteroid = Instantiate(asteroidPrefab, spawnPoint,rotation);
            asteroid.size = Random.Range(asteroid.maxsize, asteroid.maxsize);
            asteroid.SetTrajectory(rotation * -spawnDirection);
        }
    }
}

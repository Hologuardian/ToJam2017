using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;
using UnityStandardAssets.Utility;

public class AsteroidBelt : MonoBehaviour
{
    public Material asteroidMaterial;
    public GameObject roidPrefab;
    public List<GameObject> roids = new List<GameObject>();
    private int total = 0;



    private void Start()
    {
        
    }
    float timer = 0.0f;
    private void Update()
    {
        //if(Input.GetKeyDown(KeyCode.G))
        if (timer <= 0)
        {
            timer = 0.1f;

            while (roids.Count < 1500)
            {
                MakeAsteroids();
            }
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    private void MakeAsteroids()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject obj = Instantiate(roidPrefab); ;
            obj.transform.rotation = Random.rotation;
            Vector3 pos = Random.insideUnitSphere * 140.0f;
            pos.y *= 0.05f;
            pos += pos.normalized * 300.0f;
            pos.y = 0;
            obj.transform.position = pos;
            AsteroidPrefab roid = obj.AddComponent<AsteroidPrefab>();
            roid.asteroidSize = (Size)(int)((((Random.value * Random.value)) * 5.0f) + 1.0f);
            //MeshRenderer rend = obj.AddComponent<MeshRenderer>();
            //rend.material = asteroidMaterial;
            //Rigidbody body = obj.AddComponent<Rigidbody>();
            //body.useGravity = false;
            obj.AddComponent<Orbit>();
            //NavMeshObstacle tempNavMeshObstacle = obj.GetComponent<NavMeshObstacle>();
            //tempNavMeshObstacle.shape = NavMeshObstacleShape.Box;
            //tempNavMeshObstacle.size = obj.GetComponent<MeshRenderer>().bounds.size;
            obj.layer = 8;
            roids.Add(obj);
            //roids[roids.Count - 1].GetComponent<NavMeshObstacle>().size = obj.GetComponent<MeshRenderer>().bounds.size;
        }
    }
}
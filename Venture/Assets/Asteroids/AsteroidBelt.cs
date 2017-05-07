using UnityEngine;
using System.Collections.Generic;
using UnityStandardAssets.Utility;

public class AsteroidBelt : MonoBehaviour
{
    public Material asteroidMaterial;
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
            MakeAsteroids();
            while (roids.Count > 1500)
            {
                GameObject obj = roids[0];
                roids.RemoveAt(0);
                Destroy(obj);
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
            GameObject obj = new GameObject();
            obj.transform.rotation = Random.rotation;
            Vector3 pos = Random.insideUnitSphere * 140.0f;
            pos.y *= 0.05f;
            pos += pos.normalized * 300.0f;
            obj.transform.position = pos;
            Asteroid roid = obj.AddComponent<Asteroid>();
            roid.size = (Size)(int)((((Random.value * Random.value)) * 5.0f) + 1.0f);

            MeshRenderer rend = obj.AddComponent<MeshRenderer>();
            rend.material = asteroidMaterial;
            //Rigidbody body = obj.AddComponent<Rigidbody>();
            //body.useGravity = false;

            AutoMoveAndRotate rot = obj.AddComponent<AutoMoveAndRotate>();
            rot.rotateDegreesPerSecond = new AutoMoveAndRotate.Vector3andSpace() { value = Random.insideUnitSphere * 50.0f * Random.value * Random.value * Random.value, space = Space.Self};
            rot.moveUnitsPerSecond = new AutoMoveAndRotate.Vector3andSpace() { value = Vector3.zero, space = Space.Self };
            obj.name = "roid" + total++;
            roids.Add(obj);
        }
    }
}
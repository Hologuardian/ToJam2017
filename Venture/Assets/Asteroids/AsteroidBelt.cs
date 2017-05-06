using UnityEngine;

public class AsteroidBelt : MonoBehaviour
{
    public Material asteroidMaterial;

    private void Start()
    {
        for(int i = 0; i < 100; i++)
        {
            GameObject obj = new GameObject();
            obj.transform.rotation = Random.rotation;
            obj.transform.position = Random.insideUnitSphere * 50.0f;
            Asteroid roid = obj.AddComponent<Asteroid>();
            roid.size = (Size)(int)((((Random.value * Random.value * Random.value)) * 5.0f) + 1.0f);

            MeshRenderer rend = obj.AddComponent<MeshRenderer>();
            rend.material = asteroidMaterial;
        }
    }
}
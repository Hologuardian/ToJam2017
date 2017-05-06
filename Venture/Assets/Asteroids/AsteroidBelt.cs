using UnityEngine;

public class AsteroidBelt : MonoBehaviour
{
    private void Start()
    {
        for(int i = 0; i < 100; i++)
        {
            GameObject obj = new GameObject();
            obj.transform.rotation = Random.rotation;
            obj.transform.position = Random.insideUnitSphere * 50.0f;
            obj.AddComponent<Asteroid>();
        }
    }
}
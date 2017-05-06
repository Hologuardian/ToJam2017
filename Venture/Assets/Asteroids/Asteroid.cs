using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    struct Mineral
    {
        public Vector3 pos;
        public Color col;
    }
    
    List<Mineral> cloud = new List<Mineral>();

    private void Start()
    {
        Color c;
        c = Random.ColorHSV(0, 1, 0.5f, 0.75f);
        for (int i = 0; i < Random.Range(7, 30); i++)
        {
            Vector3 sphere = Random.insideUnitSphere + Random.insideUnitSphere;
            float dims = 10.0f;
            float rand = Random.value * dims;
            dims -= rand;
            float x = sphere.x * Random.value * rand;
            rand = Random.value * dims;
            dims -= rand;
            float y = sphere.y * Random.value * rand;
            rand = Random.value * dims;
            dims -= rand;
            float z = sphere.z * Random.value * rand;
            Vector3 vec = new Vector3(x, y, z);

            vec += Random.insideUnitSphere + Random.insideUnitSphere + Random.insideUnitSphere;
            cloud.Add(new Mineral() { pos = vec * 0.4f + transform.position, col = c + Random.ColorHSV(0, 1.0f, 0.0f, 0.2f) });
        }
    }

    private void OnDrawGizmos()
    {
        foreach(Mineral min in cloud)
        {
            Gizmos.color = min.col;
            Gizmos.DrawSphere(transform.rotation * min.pos + transform.position, 0.25f);
        }
    }
}

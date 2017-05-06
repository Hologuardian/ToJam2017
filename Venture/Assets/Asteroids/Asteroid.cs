using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public Size size;
    public MeshCollider coll;
    struct Mineral
    {
        public Vector3 pos;
        public Color col;
    }
    
    List<Mineral> cloud = new List<Mineral>();

    private void Start()
    {
        float sizeVal = (int)size * 20.0f;
        Color c;
        c = Random.ColorHSV(0, 1, 0.5f, 0.75f);
        for (int i = 0; i < Random.Range(7, 30); i++)
        {
            Vector3 sphere = Random.insideUnitSphere + Random.insideUnitSphere;
            float dims = 0.2f * sizeVal ;
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

        List<Vector3> positions = new List<Vector3>();
        List<Color> colors = new List<Color>();
        List<int> indicies = new List<int>();
        

        for(int n = 2; n < cloud.Count; n++)
        {
            int m = (n - 2) * 3;
            positions.Add(cloud[n].pos);
            colors.Add(cloud[n].col);
            indicies.Add(m);
            positions.Add(cloud[n - 1].pos);
            colors.Add(cloud[n].col);
            indicies.Add(m + 1);
            positions.Add(cloud[n - 2].pos);
            colors.Add(cloud[n - 2].col);
            indicies.Add(m + 2);
        }

        Mesh mesh = new Mesh();
        mesh.SetVertices(positions);
        mesh.SetColors(colors);
        mesh.SetTriangles(indicies, 0);
        coll = transform.gameObject.AddComponent<MeshCollider>();
        coll.convex = true;
        coll.sharedMesh = mesh;
        first = true;
    }
    bool first = false;
    private void Update()
    {
        if(first)
        {
            first = false;
            MeshFilter filter = transform.gameObject.AddComponent<MeshFilter>();
            int i = 0;
            Mesh m = CreateMesh(cloud);
            m.colors.ToList().ForEach(x => x = cloud[(i++) % cloud.Count].col);
            filter.sharedMesh = m;
        }
    }

    private void OnDrawGizmos()
    {
        foreach(Mineral min in cloud)
        {
            //Gizmos.color = min.col;
            //Gizmos.DrawSphere(transform.rotation * min.pos + transform.position, 0.1f * (int)size * 5.0f);
        }
    }

    Mesh CreateMesh(IEnumerable<Mineral> stars)
    {
        Mesh m = new Mesh();
        m.name = "ScriptedMesh";
        List<int> triangles = new List<int>();

        var vertices = stars.Select(x => new Vertex(x.pos)).ToList();
        var colors = stars.Select(x => x.col).ToArray();

        var result = MIConvexHull.ConvexHull.Create(vertices);
        m.vertices = result.Points.Select(x => x.ToVec()).ToArray();
        var xxx = result.Points.ToList();

        foreach (var face in result.Faces)
        {
            triangles.Add(xxx.IndexOf(face.Vertices[0]));
            triangles.Add(xxx.IndexOf(face.Vertices[1]));
            triangles.Add(xxx.IndexOf(face.Vertices[2]));
        }

        m.triangles = triangles.ToArray();

        m.RecalculateNormals();
        return m;
    }
}

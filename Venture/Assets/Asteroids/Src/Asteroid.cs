using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public Size size;
    public float sizeVal;
    struct Mineral
    {
        public Vector3 pos;
        public Color col;
    }
    
    List<Mineral> cloud = new List<Mineral>();

    public bool Mine(Inventory inventory, float Efficiency)
    {
        return false;
    }

    private void Start()
    {
        sizeVal = (int)size * 30.0f;
        Color c;
        c = Random.ColorHSV(0, 0.1f, 0.1f, 0.25f);
        for (int i = 0; i < Random.Range(45, 100); i++)
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
            cloud.Add(new Mineral() { pos = vec * 0.4f, col = c + Random.ColorHSV(0, 0.1f, 0.0f, 0.2f) });
        }
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
            MeshCollider collider = transform.gameObject.AddComponent<MeshCollider>();
            collider.sharedMesh = m;
            collider.convex = true;
            DynamicGI.UpdateEnvironment();
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
        int i = 0;
        m.colors = result.Points.Select(x => colors[i++]).ToArray();
        var xxx = result.Points.ToList();

        Vector3 CoM = Vector3.zero;

        xxx.ForEach(p => CoM += p.ToVec());

        CoM /= xxx.Count;

        List<Vector3> normals = new List<Vector3>();
        xxx.ForEach(p => normals.Add(Vector3.zero));


        foreach (var face in result.Faces)
        {
            triangles.Add(xxx.IndexOf(face.Vertices[0]));
            normals[xxx.IndexOf(face.Vertices[0])] = (face.Vertices[0].ToVec() - CoM).normalized;
            triangles.Add(xxx.IndexOf(face.Vertices[1]));
            normals[xxx.IndexOf(face.Vertices[1])] = (face.Vertices[1].ToVec() - CoM).normalized;
            triangles.Add(xxx.IndexOf(face.Vertices[2]));
            normals[xxx.IndexOf(face.Vertices[2])] = (face.Vertices[2].ToVec() - CoM).normalized;
        }
        m.MarkDynamic();
        m.triangles = triangles.ToArray();

        m.SetNormals(normals);
        return m;
    }
}

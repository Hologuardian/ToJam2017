using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    Color c = Random.ColorHSV();

    private void OnDrawGizmos()
    {
        Gizmos.color = c;
        Gizmos.DrawSphere(transform.position, 1.0f);
    }
}

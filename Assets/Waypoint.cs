using UnityEngine;

public class Waypoint : MonoBehaviour
{

    void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, 0.2f);
    }
}

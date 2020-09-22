using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollitionCheck : MonoBehaviour
{
    public Transform left;
    public Transform right;
    public LayerMask wall;
    public float radious;
    public bool Rwall;
    public bool Lwall;

    
    // Update is called once per frame
    void FixedUpdate()
    {
        Rwall = Physics.CheckSphere(right.position, radious, wall);
        Lwall = Physics.CheckSphere(left.position, radious, wall);
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(right.position, radious);
        Gizmos.DrawSphere(left.position, radious);
    }
}

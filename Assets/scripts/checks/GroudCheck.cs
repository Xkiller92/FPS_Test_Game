using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroudCheck : MonoBehaviour
{
    public bool isGrounded;
    public float radius;
    public Transform GroundTrans;
    
    public string layermask1;
    public string layermask2;



    // Update is called once per frame
    void FixedUpdate()
    {
        GroundCheck();
    }

    public void GroundCheck()
    {
        int mask1 = 1 << LayerMask.NameToLayer(layermask1);
        int mask2 = 1 << LayerMask.NameToLayer(layermask2);
        int combinedMasks = mask1 | mask2;
        isGrounded = Physics.CheckSphere(GroundTrans.position ,radius, combinedMasks);  
    }

    public  void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(GroundTrans.position, radius); 
    }
}

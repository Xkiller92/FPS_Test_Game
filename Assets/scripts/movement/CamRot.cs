using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRot : MonoBehaviour
{
    public float sensetivity;
    public Transform player;
    float Xrotation = 0f;
    public float elevation;
    public Transform indicator;
    public Transform particles;
    public float particleDistance;
    public float distance;

   

    // Update is called once per frame
    void FixedUpdate()
    {
        float MouseX = Input.GetAxis("Mouse X") * sensetivity * Time.deltaTime;
        float MouseY = Input.GetAxis("Mouse Y") * sensetivity * Time.deltaTime;

        Xrotation -= MouseY;
        Xrotation = Mathf.Clamp(Xrotation, -90f, 90f);
        
        
        transform.localRotation = Quaternion.Euler(Xrotation, 0f, 0f);
        player.Rotate(Vector3.up * MouseX);

        Vector3 resultingPosition = transform.position + transform.forward *distance;
       indicator.position = resultingPosition;

        Vector3 resultingParticles = transform.position + transform.forward * particleDistance;
        particles.position = resultingParticles;
    }
}

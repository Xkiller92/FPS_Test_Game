using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAI : MonoBehaviour
{
    public Transform trans;
    public float speed;
    public GameObject detection;
    public float pos = 1;

    void FixedUpdate()
    {
        

        if (detection.GetComponent<CollitionCheck>().Rwall == false && detection.GetComponent<CollitionCheck>().Lwall == false)
        {
            pos = +pos;
        }
        else
        {
            pos = -pos;
        }

       

        trans.position += new Vector3(0, 0, pos * speed * Time.deltaTime);
    }
}

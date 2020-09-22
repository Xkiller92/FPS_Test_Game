using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthMananger : MonoBehaviour
{
    public float health;
    public float maxHealth;

    void Update()
    {
        Death();
    }

    public void Death() 
    {
        if (health <= 0)
        {
           this.gameObject.SetActive(false);
        }
    }

   
}

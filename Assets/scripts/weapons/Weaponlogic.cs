using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weaponlogic : MonoBehaviour
{
    public float range = 10;
    /*public string target1; 
    public string target2;*/
    public Transform indicator;
    public string[] targetList;
    public int[] _targets;
    private int targets;
    public bool isShot;
    public GameObject enemy;
    public float damage;
    public Image _HealthBar;
    public float dmg;
    public ParticleSystem gunBurst;
    public Text reloadCounter;
    public int ammo;
    public int maxAmmo; 
    public float reloadTime;
    private bool isReloading = false;
    
   

    public void Start()
    {
        for (int i = 0; i <= targetList.Length; i++)
        {
            _targets[i] = 1; 
        }
    }

    void Update()
    {
        if (isReloading == true)
        {
            return;
        }

        if (ammo == 0)
        {
            StartCoroutine(reload());
            return;
        }

        if (Input.GetMouseButtonDown(1) && ammo > 0)
        {
            gunBurst.Play();
            ammo -= 1;
        }


        if (Input.GetMouseButtonDown(1) && isShot == true )
        {
            Debug.Log("nice");
            enemy.GetComponent<HealthMananger>().health -= damage;
            HealthBar();
        }
        reloadCounter.text =$"{ammo}";
    }
    void FixedUpdate()
    {
        HitCheck();   
    }

    public void HitCheck()
    {
       
        
        for (int i = 0; i < targetList.Length; i++)
        {
            _targets[i] = 1 << LayerMask.NameToLayer(targetList[i]);
            targets = targets | _targets[i];
        }
  
        //this is a dump detection implementation is you want to detect more than 1 enemy use colliders next time    
        isShot = Physics.Linecast(transform.position, indicator.position, targets);

        Debug.DrawLine(transform.position, indicator.position, Color.yellow);
    }

    public void HealthBar()
    {
        dmg = _HealthBar.rectTransform.localScale.x;
        dmg -= damage / enemy.GetComponent<HealthMananger>().maxHealth;
        _HealthBar.rectTransform.localScale = new Vector3(dmg, 1, 1);
    }

    IEnumerator reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        ammo = maxAmmo;
        isReloading = false;
    }
}

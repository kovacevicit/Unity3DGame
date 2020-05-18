using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float damage=30f;
    public float range=100f;
    public GameObject muzzle;
    public GameObject impactEffect;
    public AudioSource audio;
   
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            audio.Play();
        }
    }
    
    void Shoot()
    {
        
        RaycastHit hit;
        if(Physics.Raycast(muzzle.transform.position, muzzle.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            GameObject impackGO=Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impackGO, 1);
        }
    }
}

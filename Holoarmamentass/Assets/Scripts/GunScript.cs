using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public float recoil = 1f;
    public float damage = 10f;
    public float range = 100f;
    public float shotforce = 30f;
    public float fireRate = 15f;

    public Camera cam;
    public ParticleSystem muzleflash;
    public AudioSource shoot;

    public float nextTimetoFire = 0f;
    public ParticleSystem shotEffect;

    void Update()
    {
        if(Input.GetButton("Fire1") && Time.time >= nextTimetoFire)
        {
            nextTimetoFire = Time.time + 1f / fireRate ;
            
            RaycastHit hit;
            if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
            {
                muzleflash.Play();
                shoot.Play();
                Debug.Log(hit.transform.name);

                Ienemy target = hit.transform.GetComponent<Ienemy>();
                if(target != null)
                {
                    target.Damage(damage);
                }

                if(hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * shotforce);
                }

                Instantiate(shotEffect, hit.point, Quaternion.LookRotation(hit.normal));
                shotEffect.Play();
            }
        }
    }
}

using System;
using System.Diagnostics;
using UnityEngine;
public class Gun : MonoBehaviour
{


    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public float impactForce = 30f;

    public Camera fpscamera;
    public GameObject impactEffect;

    private float nextTimeToFire = 0f;

    // Update is called once per frame
    void OnTriggerStay(Collider col)
    {

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && col.tag == "Finish")
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }

    }
    void Awake()
    {
        Cursor.visible = false;

    }
    /*void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Finish")
        {
            UnityEngine.Debug.Log("ay");
        }
    }*/



    void Shoot()
    {

        RaycastHit hit;
        if (Physics.Raycast(fpscamera.transform.position, fpscamera.transform.forward, out hit, range))
        {
            UnityEngine.Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }

    }
}

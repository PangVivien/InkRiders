using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileGun : MonoBehaviour
{
    public Camera cam;
    public GameObject projectile;
    public Transform LHFirePoint, RHFirePoint;
    public float projectileSpeed = 30;
    public float fireRate = 4;

    private Vector3 destination;
    private bool leftShoot;
    private float timeToFire;

    void Start()
    {
            
    }

    void Update()
    {
        if(Input.GetButton("Fire1") && Time.time >= timeToFire)
        {
            Fire();
        }
    }

    public void Fire()
    {
        if (Time.time >= timeToFire)
        {
            timeToFire = Time.time + 1 / fireRate;
            ShootProjectile();
        }
    }

    void ShootProjectile()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
            destination = hit.point;
        else
            destination = ray.GetPoint(1000);

        if(leftShoot)
        {
            leftShoot = false;
            InstantiateProjectile(LHFirePoint);
        }
        else
        {
            leftShoot = true;
            InstantiateProjectile(RHFirePoint);
        }
    }

    void InstantiateProjectile(Transform firePoint)
    {
        var projectileObj = Instantiate(projectile, firePoint.position, Quaternion.identity) as GameObject;
        projectileObj.GetComponent<Rigidbody>().velocity = (destination - firePoint.position).normalized * projectileSpeed;
    }
}

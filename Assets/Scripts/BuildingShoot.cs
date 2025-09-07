using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingShoot : MonoBehaviour
{
    public Material hitMaterial; // assign in Inspector
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void OnCollisionEnter(Collision co)
    {
        
        if (co.gameObject.CompareTag("Bullet"))
        {
            if (hitMaterial != null && rend != null)
            {
                rend.material = hitMaterial;
            }
            Debug.Log("shoot building");
        }
    }
}

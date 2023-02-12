using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] private float delay = 3f;
    [SerializeField] private GameObject explosionEffect;
    [SerializeField] private float radius = 2f;
    [SerializeField] private float force = 500f;

    private bool hasExploded = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        delay -= Time.deltaTime;
        if (delay <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
    }

    private void Explode()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);
        
        Collider[] collidersToDestroy = Physics.OverlapSphere(transform.position, radius);
        
        foreach (Collider nearbyObject in collidersToDestroy)
        {
            DestroyBox des= nearbyObject.GetComponent<DestroyBox>();
            if (des != null)
            {
                des.Destroy();
            }
        }
        
        Collider[] collidersToMove = Physics.OverlapSphere(transform.position, radius);
        
        foreach (Collider nearbyObject in collidersToMove)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force,transform.position,radius);
            }
        }
        
        Destroy(gameObject);
    }
}

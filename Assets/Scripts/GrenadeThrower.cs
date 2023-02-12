using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeThrower : MonoBehaviour
{
    [SerializeField] private float throwForce = 7f;
    [SerializeField] private GameObject grenadePrefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            ThrowGrenade();
        }
    }

    private void ThrowGrenade()
    {
       GameObject grenade = Instantiate(grenadePrefab, transform.position, transform.rotation);
       Rigidbody rb = grenade.GetComponent<Rigidbody>();
       rb.AddForce(transform.forward * throwForce,ForceMode.VelocityChange);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float force = 2;
    [SerializeField] private float damage = 1;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private GameObject impactPrefab;

    private GameObject weapon1;
    private GameObject weapon2;
    
    private void Start()
    {
        weapon1 = GameObject.Find("Handgun");
        weapon2 = GameObject.Find("Avtomat");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Alpha1))
        {
            weapon1.SetActive(true);
            weapon2.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Alpha2))
        {
            weapon1.SetActive(false);
            weapon2.SetActive(true); 
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(shootPoint.position, shootPoint.forward, out var hit))
            {
                Instantiate(impactPrefab, hit.point, Quaternion.LookRotation(hit.normal, Vector3.up));

                var destructible = hit.transform.GetComponent<DestructbleObject>();
                if (destructible != null)
                {
                    destructible.ReceiveDamage(damage);
                }
                
                var rigidbody = hit.transform.GetComponent<Rigidbody>();
                if (rigidbody != null)
                {
                    rigidbody.AddForce(shootPoint.forward * force,ForceMode.Impulse);
                }
                
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color=Color.red;
        
        Gizmos.DrawRay(shootPoint.position,shootPoint.forward * 999);
    }
}

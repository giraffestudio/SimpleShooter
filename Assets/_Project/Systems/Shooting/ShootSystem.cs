using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShootSystem : MonoBehaviour
{
    public Transform firePoint;
    public GameObject muzzlePrefab;
    public GameObject hitPrefab;
    private void Update()
    {
        Debug.DrawRay(firePoint.position, firePoint.TransformDirection(Vector3.forward) * 100.0f, Color.magenta);
        if (Input.GetMouseButtonDown(0)) Shoot();
    }

    private void Shoot()
    {
        RaycastHit hit;

        var muzzleFlash = Instantiate(muzzlePrefab, firePoint.position, Quaternion.identity, firePoint);
        Destroy(muzzleFlash, 0.25f);

        if (Physics.Raycast(firePoint.position, firePoint.TransformDirection(Vector3.forward), out hit, 100))
        {
            var hitEffect = Instantiate(hitPrefab, hit.point, Quaternion.identity);
            Destroy(hitEffect, 1.5f);
            if (hit.collider.gameObject.tag == "Destroyable")
                hit.collider.gameObject.SetActive(false);
        }
    }
}

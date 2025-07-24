using System;
using System.Collections;
using UnityEngine;

public class CrossBow : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform shootPos;
    public bool isShoot;
    
    void Update()
    {
        Ray ray = new Ray(shootPos.position, shootPos.forward);
        RaycastHit hit; // 레이저 닿은 대상

        bool isTargeting = Physics.Raycast(ray, out hit);

        Debug.DrawRay(shootPos.position, shootPos.forward * 100f, Color.green);

        if (isTargeting && !isShoot)
            StartCoroutine(ShootRoutine());
    }

    IEnumerator ShootRoutine()
    {
        isShoot = true;
        
        GameObject arrow = Instantiate(arrowPrefab, transform);
        Quaternion rot = Quaternion.Euler(new Vector3(90, 0, 0));
        arrow.transform.SetPositionAndRotation(shootPos.position, rot);
        
        yield return new WaitForSeconds(3f);
        isShoot = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(shootPos.position, shootPos.forward * 100f);
    }
}
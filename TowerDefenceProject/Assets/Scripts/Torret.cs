using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torret : MonoBehaviour
{
    private Transform target;
    public float range = 15f;

    public string enemyTag = "Enemy";
    public Transform barrel;
    public float turnSpeed = 10f;
    
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null; 

        foreach(GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    
    void Update()
    {
        if (target == null)
        {
            return;
        }

        Vector3 dir = target.position - transform.position;
        Quaternion lookRoataion = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(barrel.rotation, lookRoataion, Time.deltaTime * turnSpeed).eulerAngles;
        barrel.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, range);
    }
}

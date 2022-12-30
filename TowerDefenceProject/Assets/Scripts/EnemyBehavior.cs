using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public Transform[] wayPoints;
    private int _currentWaypointIndex = 0;
    public float _speed = 5f;
    public GameObject _enemyPrefab;
    private Vector3 startingPosition;

    
    void Start()
    {
        startingPosition = new Vector3(-4.5f, 0.1f, 4.5f);
        StartCoroutine(EnemySpawn());
    }

    
    void Update()
    {
        Transform wp = wayPoints[_currentWaypointIndex];

        if (Vector3.Distance(transform.position, wp.position) < 1f)
        {
            _currentWaypointIndex = (_currentWaypointIndex + 1) % wayPoints.Length;
        }
        else 
        {
            transform.position = Vector3.MoveTowards(transform.position, wp.position, _speed * Time.deltaTime);
        }
        
        DestroyEnemy();
    }

    IEnumerator EnemySpawn()
    {
        Instantiate(_enemyPrefab, startingPosition, Quaternion.identity);
        yield return new WaitForSeconds(5f);
    }
    
    private void DestroyEnemy()
    {
        if (transform.position.x >= 2.3f)
        {
            Destroy(this.gameObject);
        }
    }
}

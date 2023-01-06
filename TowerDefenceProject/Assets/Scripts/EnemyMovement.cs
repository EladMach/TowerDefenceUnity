using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    public float _speed = 10f;

    private Transform target;
    private int wavePointIndex = 0;
    public int enemyHP;
    private GameManager gameManager;
    
    private void Start()
    {
        enemyHP = 2;
        target = Waypoints.wayPoints[0];
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();      
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * _speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (wavePointIndex >= Waypoints.wayPoints.Length - 1)
        {
            Destroy(gameObject);
            Debug.Log("Game Over");
            return;
        }
        wavePointIndex = wavePointIndex + 1;
        target = Waypoints.wayPoints[wavePointIndex];
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            gameManager.ScoreSystem();
            enemyHP = enemyHP - 1;

            if (enemyHP == 0)
            {
                Destroy(this.gameObject);
            }
            
        }

        if (other.CompareTag("EndTower"))
        {
            Debug.Log("GAME OVER");
            //SceneManager.LoadScene(1);
        }
  
    }

   
}

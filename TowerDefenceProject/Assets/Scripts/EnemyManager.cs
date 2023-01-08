using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
    public float _speed = 10f;

    public GameObject _enemyPrefab;
    

    private Transform target;
    private int wavePointIndex = 0;
    public int enemyHP;
    
    private GameManager gameManager;
    
    private void Start()
    {
        
        
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
            enemyHP = enemyHP - 1;

            if (enemyHP == 0)
            {
                gameManager.ScoreSystem();
                Destroy(this.gameObject);
            }
            
        }
        if (other.CompareTag("Bulletlvl2"))
        {
            enemyHP = enemyHP - 2;

            if (enemyHP == 0)
            {
                gameManager.ScoreSystem();
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

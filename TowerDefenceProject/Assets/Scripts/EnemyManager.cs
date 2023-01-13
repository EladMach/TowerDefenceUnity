using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
    [Header("Variables")]
    public float _speed = 10f;
    public int enemyHP;
    private int wavePointIndex = 0;

    [Header("Unity Attributes")]
    public GameObject _enemyPrefab;    
    private Transform target;
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

        enemyHP = Mathf.Clamp(enemyHP, 0, 6);
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

            OnEnemyDeath();
            
        }
        if (other.CompareTag("Bulletlvl2"))
        {
            enemyHP = enemyHP - 2;

            OnEnemyDeath();

        }

        if (other.CompareTag("Bulletlvl3"))
        {
            enemyHP = enemyHP - 5;

            OnEnemyDeath();

        }

        if (other.CompareTag("EndTower"))
        {
            Debug.Log("GAME OVER");
            gameManager._score = gameManager._score - 1;
            //SceneManager.LoadScene(1);
        }
  
    }

    void OnEnemyDeath()
    {
        if (enemyHP == 0)
        {
            gameManager.ScoreSystem();
            Destroy(this.gameObject);
        }
    }
   
}

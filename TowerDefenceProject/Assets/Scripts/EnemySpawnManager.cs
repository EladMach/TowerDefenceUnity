using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public GameObject _enemyPrefab;
    private Vector3 enemyPosition;
    private bool _isSpawning = true;
    void Start()
    {
        enemyPosition = new Vector3(-4.5f, 0.1f, 4.5f);
        StartCoroutine(EnemySpawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator EnemySpawn()
    {
        yield return new WaitForSeconds(2f);
        while (_isSpawning == true)
        {
            
            Instantiate(_enemyPrefab, enemyPosition, Quaternion.identity);
            yield return new WaitForSeconds(2.5f);

        }
        
    }
}

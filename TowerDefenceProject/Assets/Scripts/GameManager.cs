using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Transform _enemyPrefab;

    public Transform _spawnPoint;

    public float _timeBetweenWaves = 5f;
    private float _countDown = 2f;

    public TextMeshProUGUI waveCountdownText;

    private int _waveIndex = 0;

    private void Update()
    {
        if (_countDown <= 0f)
        {
            StartCoroutine(SpawnWave());
            _countDown = _timeBetweenWaves;
        }

        _countDown -= Time.deltaTime;

        waveCountdownText.text = Mathf.Round(_countDown).ToString();
    }

    IEnumerator SpawnWave()
    {
        _waveIndex++;

        for (int i = 0; i < _waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        
    }

    void SpawnEnemy()
    {
        Instantiate(_enemyPrefab, _spawnPoint.position, _spawnPoint.rotation);
    }

    
}

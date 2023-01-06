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
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI waveNumText;

    private int _waveIndex = 0;
    public int _score;

    private void Start()
    {
        _score = 10;
        
   
    }
    private void Update()
    {
        if (_countDown <= 0f)
        {
            StartCoroutine(SpawnWave());
            _countDown = _timeBetweenWaves;
        }

        _countDown -= Time.deltaTime;

        waveCountdownText.text = Mathf.Round(_countDown).ToString();
        scoreText.text = "Score: " + _score.ToString();
        waveNumText.text = "Wave: " + _waveIndex.ToString();

        _score = (Mathf.Clamp(_score, 0, 100));
        
       
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

    

    public void ScoreSystem()
    {
        _score = _score + 1;
    }

    
}

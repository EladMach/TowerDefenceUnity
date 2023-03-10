using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    [Header("Transforms")]
    public Transform _enemyEasyPrefab;
    public Transform _enemyMediumPrefab;
    public Transform _enemyHardPrefab;
    public Transform _spawnPoint;


    [Header("Variables")]
    public float _timeBetweenWaves = 5f;
    private float _countDown = 5f;
    public int _score;
    private int _waveIndex = 0;
    
 
    [Header("Text UI")]
    public TextMeshProUGUI waveCountdownText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI waveNumText;


    private void Start()
    {
        _score = 5;  
    }


    private void Update()
    {
        Countdown();
        TextUI();

        _score = (Mathf.Clamp(_score, 0, 100));
    }

    

    void Countdown()
    {
        if (_countDown <= 0f)
        {
            _waveIndex++;

            if (_waveIndex <= 5)
            {
                StartCoroutine(SpawnEnemyEasyWave());   
            }
            if (_waveIndex >= 6 && _waveIndex <= 10)
            {
                StartCoroutine(SpawnEnemyMediumWave());
            }
            if (_waveIndex >= 11)
            {
                StartCoroutine(SpawnEnemyHardWave());
            }       
            _countDown = _timeBetweenWaves;    
        }
    
        _countDown -= Time.deltaTime;

        waveCountdownText.text = "Next Wave In: " +  Mathf.Round(_countDown).ToString();
    }

    public void ScoreSystem()
    {
        _score = _score + 1;
    }

    void TextUI()
    {
        scoreText.text = "Score: " + _score.ToString();
        waveNumText.text = "Wave: " + _waveIndex.ToString();
    }


    IEnumerator SpawnEnemyEasyWave()
    {
        for (int i = 0; i < _waveIndex; i++)
        {
            SpawnEnemyEasy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator SpawnEnemyMediumWave()
    {
        StopCoroutine(SpawnEnemyEasyWave());

        for (int i = 0; i < _waveIndex; i++)
        {
            SpawnEnemyMedium();
            yield return new WaitForSeconds(0.5f);
            
        }      
    }

    IEnumerator SpawnEnemyHardWave()
    {
         StopCoroutine(SpawnEnemyMediumWave());
         for (int i = 0; i < _waveIndex; i++)
         {
             SpawnEnemyHard();
             yield return new WaitForSeconds(0.5f);
         }
    }

   void SpawnEnemyEasy()
   {
       Instantiate(_enemyEasyPrefab, _spawnPoint.position, _spawnPoint.rotation);
   }
   void SpawnEnemyMedium()
   {
       Instantiate(_enemyMediumPrefab, _spawnPoint.position, _spawnPoint.rotation);
   }
   void SpawnEnemyHard()
   {
       Instantiate(_enemyHardPrefab, _spawnPoint.position, _spawnPoint.rotation);
   }
}

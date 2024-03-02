using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemy;
    [SerializeField]
    private GameObject _enemyContainer;

    [SerializeField]
    private GameObject _tripleshotPowerUp;

    private bool _stopSpawning = false;

    private float _randomXSpawn;


    void Start()
    {
        StartCoroutine(EnemySpawnHandler());
        StartCoroutine(PowerUpSpawnHandler());
    }


    void Update()
    {
        _randomXSpawn = Random.Range(-9.38f, 9.38f);
    }

    IEnumerator EnemySpawnHandler()
    {
        while (_stopSpawning == false)
        {
            GameObject newEnemy = Instantiate(_enemy, new Vector3(_randomXSpawn, 7f, 0), Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(5f);

        }

    }

    IEnumerator PowerUpSpawnHandler()
    {
        while (_stopSpawning == false)
        {
            yield return new WaitForSeconds(Random.Range(5, 10));
            Instantiate(_tripleshotPowerUp, new Vector3(_randomXSpawn, 7f, 0), Quaternion.identity);


        }
    }
    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
}

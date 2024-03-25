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
    private GameObject[] _powerUps;

    private bool _stopSpawning = false;

    private float _randomXSpawn;

<<<<<<< HEAD
    private int _randomPowerUp;

=======
>>>>>>> e451376 (commit reset issue)
    public void StartSpawning()
    {
        StartCoroutine(EnemySpawnHandler());
        StartCoroutine(PowerUpSpawnHandler());
    }


    void Update()
    {
<<<<<<< HEAD
        _randomXSpawn = Random.Range(-9.38f, 9.38f);
        _randomPowerUp = Random.Range(0, 2);
=======
        

>>>>>>> e451376 (commit reset issue)
    }

    IEnumerator EnemySpawnHandler()
    {
        yield return new WaitForSeconds(2);
        while (_stopSpawning == false)
        {
            _randomXSpawn = Random.Range(-9.38f, 9.38f);
            GameObject newEnemy = Instantiate(_enemy, new Vector3(_randomXSpawn, 7f, 0), Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(5f);

        }

    }

    IEnumerator PowerUpSpawnHandler()
    {
        yield return new WaitForSeconds(2);
        while (_stopSpawning == false)
        {
            yield return new WaitForSeconds(Random.Range(5, 10));
<<<<<<< HEAD
            int randomPowerUp = Random.Range(0, 3);
            Instantiate(_powerUps[randomPowerUp], new Vector3(_randomXSpawn, 7f, 0), Quaternion.identity);
           
=======
            _randomXSpawn = Random.Range(-9.38f, 9.38f);
            int randomPowerUp = Random.Range(0, 3);
            Instantiate(_powerUps[randomPowerUp], new Vector3(_randomXSpawn, 7f, 0), Quaternion.identity);

>>>>>>> e451376 (commit reset issue)
        }
    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
}

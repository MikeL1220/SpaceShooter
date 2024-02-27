using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemy; 
    [SerializeField]
    private GameObject _enemyContainer; 

    private bool _stopSpawning = false; 

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnHandler());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnHandler()
    {
        while(_stopSpawning == false)
        {
            GameObject newEnemy = Instantiate(_enemy,new Vector3(Random.Range(-9.38f,9.38f),7f, 0), Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(5f); 
            
        }
       
    }
    public void OnPlayerDeath()
    {
        _stopSpawning = true; 
    }
}

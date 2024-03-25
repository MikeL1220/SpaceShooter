using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private float _asteroidSpeed;

    [SerializeField]
    private GameObject _explosion;

    private float _asteroidXPosition;
    private float _asteroidYPosition;

    private SpawnManager _spawnManager;


    private AudioSource _asteroidExplosionSound;




    void Start()
    {
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();



        _asteroidExplosionSound = GameObject.Find("Explosion_Sound").GetComponent<AudioSource>();
        if (_asteroidExplosionSound == null)
        {
            Debug.LogError("Explosion Sound is Null");
        }
        _asteroidXPosition = transform.position.x;
        _asteroidYPosition = transform.position.y;

    }


    void Update()
    {

        _asteroidXPosition = transform.position.x;
        _asteroidYPosition = transform.position.y;



        AsteroidMovement();
    }

    void AsteroidMovement()
    {




        transform.Rotate(0, 0, 1 * _asteroidSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {


        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            GameObject explosion = Instantiate(_explosion, new Vector3(_asteroidXPosition, _asteroidYPosition, 0), Quaternion.identity);
            _spawnManager.StartSpawning();
            _asteroidExplosionSound.Play();
            Destroy(this.gameObject);
            Destroy(explosion, 1.5f);



        }
    }
}

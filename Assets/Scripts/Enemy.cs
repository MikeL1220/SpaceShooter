using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _enemySpeed = 4;

    private float _randomX;

    private Player _player;
<<<<<<< HEAD
=======

    private Animator _enemyDestruction;


    private AudioSource _enemyExplosionSound;

    private int _enemyLaserCooldown;
    [SerializeField]
    private GameObject _enemyLaser;
    private float _enemyLaserOffset = -4.2f;
    private bool _canfire = true;

    void Start()
    {
        _enemyExplosionSound = GameObject.Find("Explosion_Sound").GetComponent<AudioSource>();
        if (_enemyExplosionSound == null)
        {
            Debug.LogError("Explosion Audio is Null.");
        }

        _player = GameObject.Find("Player").GetComponent<Player>();
        if (_player == null)
        {
            Debug.LogError("Player is Null");
        }

        _enemyDestruction = GetComponent<Animator>();
        if (_enemyDestruction == null)
        {
            Debug.LogError("Animation is Null.");
        }
    }
>>>>>>> e451376 (commit reset issue)

    private Animator _enemyDestruction;

    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        //null check for player 
        if(_player == null)
        {
            Debug.LogError("Player is Null");
        }
        //assign refrence to anim 
        _enemyDestruction = GetComponent<Animator>();
        if(_enemyDestruction == null)
        {
            Debug.LogError("Animation is null.");
        }
    }
   
    void Update()
    {
        EnemyMovement();
        EnemyFire();
    }
    private void EnemyMovement()
    {
        transform.Translate(Vector3.down * _enemySpeed * Time.deltaTime);

        if (transform.position.y < -6.5f)
        {
            _randomX = Random.Range(-9.38f, 9.38f);
            transform.position = new Vector3(_randomX, 7f, 0);
            transform.Translate(Vector3.down * _enemySpeed * Time.deltaTime);
        }

    }

    private void EnemyFire()
    {

        if (_canfire == true)
        {
            StartCoroutine(EnemyLaserSpawns());
        }
        _canfire = false;

    }

    IEnumerator EnemyLaserSpawns()
    {
        _enemyLaserCooldown = Random.Range(3, 8);
        Instantiate(_enemyLaser, new Vector3(transform.position.x, transform.position.y + _enemyLaserOffset, 0), Quaternion.identity);
        _canfire = false;
        yield return new WaitForSeconds(_enemyLaserCooldown);

    }
    private void OnTriggerEnter2D(Collider2D other)
<<<<<<< HEAD
    { 
        
=======
    {

>>>>>>> e451376 (commit reset issue)
        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
            if (player != null)
            {
                other.transform.GetComponent<Player>();
                player.Damage();
            }
            _enemyDestruction.SetTrigger("On_Enemy_Death");
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
<<<<<<< HEAD
            Destroy(this.gameObject,1.0f);
        }
        else if (other.tag == "Laser")
        {
           
            Destroy(other.gameObject);
            if (_player != null)
            {
                _player.Score(10); 
            }
            _enemyDestruction.SetTrigger("On_Enemy_Death");
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Destroy(this.gameObject,1.0f);
            
=======
            Destroy(this.gameObject, 1.0f);
            _enemyExplosionSound.Play();

        }
        else if (other.tag == "Laser")
        {
>>>>>>> e451376 (commit reset issue)

            Destroy(other.gameObject);
            if (_player != null)
            {
                _player.Score(10);
            }
            _enemyDestruction.SetTrigger("On_Enemy_Death");
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Destroy(this.gameObject, 1.0f);
            _enemyExplosionSound.Play();



        }
        else if (other.tag == "EnemyLaser")
        {
            //do nothing 
        }

    }
}

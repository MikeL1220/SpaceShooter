using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _enemySpeed = 4;

    private float _randomX;

    private Player _player;

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

        transform.Translate(Vector3.down * _enemySpeed * Time.deltaTime);

        if (transform.position.y < -6.5f)
        {
            _randomX = Random.Range(-9.38f, 9.38f);
            transform.position = new Vector3(_randomX, 7f, 0);
            transform.Translate(Vector3.down * _enemySpeed * Time.deltaTime);
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    { 
        
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
            

        }

    }
}

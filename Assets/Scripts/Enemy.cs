using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _enemySpeed = 4;

    private float _randomX;

    private Player _player;  

    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
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
        Debug.Log("Hit" + other.transform.name);

        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
            if (player != null)
            {
                other.transform.GetComponent<Player>();
                player.Damage();
            }

            Destroy(this.gameObject);
        }
        else if (other.tag == "Laser")
        {
           
            Destroy(other.gameObject);
            if (_player != null)
            {
                _player.Score(10); 
            }
            Destroy(this.gameObject);
            

        }

    }
}

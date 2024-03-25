using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyLaser : MonoBehaviour
{

    private int _speed = 8;


    private AudioSource _hitSound;

    private void Start()
    {
        
        _hitSound = GameObject.Find("Explosion_Sound").GetComponent<AudioSource>();
        if (_hitSound == null)
        {
            Debug.LogError("Audio Source is Null");
        }
    }

    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < -8.9f)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
            if (player != null)
            {

                player.Damage();
            }
            _hitSound.Play();

        }

    }

}

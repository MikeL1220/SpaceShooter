using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private int _speed = 3;


    void Update()
    {

        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < -6.9f)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.PowerUpCollected();
            }

            Destroy(this.gameObject);
        }




    }


}

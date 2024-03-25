using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private int _speed = 3;

    [SerializeField] // 0 triple shot 1 = speed 2 = shield
    private int _powerUpID;

    private AudioSource _powerUpSound;

    private void Start()
    {
        _powerUpSound = GameObject.Find("PowerUp_Sound").GetComponent<AudioSource>();
        if (_powerUpSound == null)
        {
            Debug.LogError("PowerUp Audio is Null");
        }
    }

    void Update()
    {

        PowerUpMovement();

    }

    private void PowerUpMovement()
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

                switch (_powerUpID)

                {
                    case 0:
                        player.TripleShotActive();
                        break;
                    case 1:
                        player.SpeedPowerUpActive();
                        break;
                    case 2:
                        player.ShieldPowerUpActive();

                        //reset the shield health visualization 
                        player.shieldStrength = 3;
                        GameObject.Find("Shields").GetComponent<SpriteRenderer>().material.color = Color.white;

                        break;
                    default:
                        Debug.Log("no power up");
                        break;
                }


            }



        }
        _powerUpSound.Play();
        Destroy(this.gameObject);
    }
}

        



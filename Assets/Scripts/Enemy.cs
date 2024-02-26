using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _enemySpeed = 4; 
    private float randomX;

    // Start is called before the first frame update
    void Start()
    {
        randomX = Random.Range(-9.38f,9.38f);
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.down* _enemySpeed * Time.deltaTime); 

        if(transform.position.y < -6.5f)
        {
            transform.position = new Vector3(randomX, 7f, 0); 
            transform.Translate(Vector3.down * _enemySpeed * Time.deltaTime);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit" + other.transform.name);
        
        if(other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
            if(player != null)
            {
                other.transform.GetComponent<Player>();
                player.Damage();
            }

            Destroy(this.gameObject);
        }
        else if(other.tag == "Laser")
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }

    }
}
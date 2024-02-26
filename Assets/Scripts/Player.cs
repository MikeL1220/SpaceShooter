using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 3.5f; 

    private Vector3 _laserOffset = new Vector3(0f, 0.8f, 0); 

  [SerializeField]
    private GameObject _laserPrefab; 

    private float _fireRate = 0.15f; 

    private float _canFire; 
    [SerializeField]
    private int _lives =3;

    private SpawnManager _spawnManager; 


    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0,0,0); 
    }

    // Update is called once per frame
    void Update()
    {
       CalculateMovement(); 
       FireLaser();
       _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>(); 
       if(_spawnManager == null)
       {
            Debug.LogError("The Spawn Manager is Null"); 
       } 
       

    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); 
        float verticalInput = Input.GetAxis("Vertical"); 
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime); 
        transform.Translate(Vector3.up * verticalInput * speed * Time.deltaTime); 


        if(transform.position.y >= 0)
        {
            transform.position= new Vector3(transform.position.x, 0f, 0f);
        }
        else if(transform.position.y <= -4.9 )
        {
            transform.position = new Vector3(transform.position.x, -4.9f, 0f);
        }

       /* 
       optimized way to limit values using the MathF.Clamp
       transform.position = new Vector3(transform.posiiton.x, Mathf.Clamp(transform.position.y, -4.9f, 0f), 0);*/

        if(transform.position.x <= -11.2f)
        {
            transform.position = new Vector3(11.2f, transform.position.y, 0f); 
        }
        else if(transform.position.x >= 11.2f)
        {
            transform.position = new Vector3(-11.2f, transform.position.y, 0f); 
        }
    }
    void FireLaser()
    {
           if(Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            _canFire = Time.time + _fireRate; 
            Instantiate(_laserPrefab,(transform.position + _laserOffset), Quaternion.identity);
        }
    }

    public void Damage()
    {
        //_lives =_lives -1
        //_lives --
        _lives -= 1;  

        if(_lives < 1)
        {
            //communicate with SpawnManager
            //let them know to stop spawning 
            _spawnManager.OnPlayerDeath(); 
            Destroy(this.gameObject);
        }
    }
}

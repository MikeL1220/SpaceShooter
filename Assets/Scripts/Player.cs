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




    // Start is called before the first frame update
    void Start()
    {
        // get the current player position and set it to a new position 
        transform.position = new Vector3(0,0,0); 
    }

    // Update is called once per frame
    void Update()
    {
       CalculateMovement(); 
       FireLaser();

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
}

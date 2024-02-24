using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 3.5f; 

    // Start is called before the first frame update
    void Start()
    {
        // get the current player position and set it to a new position 
        transform.position = new Vector3(0,0,0); 
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); 
        float verticalInput = Input.GetAxis("Vertical"); 
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime); 
        transform.Translate(Vector3.up * verticalInput * speed * Time.deltaTime); 
    }
}

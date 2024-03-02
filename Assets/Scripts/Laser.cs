using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private int _laserSpeed = 8;


    void Update()
    {

        transform.Translate(Vector3.up * _laserSpeed * Time.deltaTime);

        if (transform.position.y >= 8)
        {

            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy(this.gameObject, 5);

        }
    }
}

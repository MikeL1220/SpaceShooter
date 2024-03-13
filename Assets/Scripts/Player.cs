using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    [SerializeField]
    private int _lives = 3;
    [SerializeField]
    private float _speed = 3.5f;

    private Vector3 _laserOffset = new Vector3(-.009f, 1f, 0);
    [SerializeField]
    private GameObject _laserPrefab;
    private float _fireRate = 0.15f;
    private float _canFire;

    [SerializeField]
    private GameObject _rightEngineDamage;
    [SerializeField]
    private GameObject _leftEngineDamage;

    private SpawnManager _spawnManager;

    private UIManager _uiManager;


    private bool _tripleShotActive = false;
    [SerializeField]
    private GameObject _tripleShotPrefab;

    private bool _speedPowerUpActive = false;

    private bool _shieldPowerUpActive = false;
    [SerializeField]
    private GameObject _playerShield;

    [SerializeField]
    private int _score;

    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

        _uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();

        if (_spawnManager == null)
        {
            Debug.LogError("The Spawn Manager is Null");
        }

        if (_uiManager == null)
        {
            Debug.LogError("The UI Manager is Null"); 
        }
    }

    void Update()
    {
        CalculateMovement();

        FireLaser();

    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if(_speedPowerUpActive == true)
        {
            _speed = 8.5f;
            transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * _speed * Time.deltaTime);
        }
        else
        {
            _speed = 3.5f;
            transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * _speed * Time.deltaTime);
        }
        

        if (transform.position.y >= 0)
        {
            transform.position = new Vector3(transform.position.x, 0f, 0f);
        }
        else if (transform.position.y <= -4.9)
        {
            transform.position = new Vector3(transform.position.x, -4.9f, 0f);
        }

        /* 
        optimized way to limit values using the MathF.Clamp
        transform.position = new Vector3(transform.posiiton.x, Mathf.Clamp(transform.position.y, -4.9f, 0f), 0);*/

        if (transform.position.x <= -11.2f)
        {
            transform.position = new Vector3(11.2f, transform.position.y, 0f);
        }
        else if (transform.position.x >= 11.2f)
        {
            transform.position = new Vector3(-11.2f, transform.position.y, 0f);
        }
    }

    void FireLaser()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            _canFire = Time.time + _fireRate;

            if (_tripleShotActive == true)
            {
                Instantiate(_tripleShotPrefab, transform.position, Quaternion.identity);
            }
            else
            {

                Instantiate(_laserPrefab, (transform.position + _laserOffset), Quaternion.identity);
            }


        }
    }

    public void TripleShotActive()
    {
        _tripleShotActive = true;
        StartCoroutine(PowerUpHandler());

    }
    public void SpeedPowerUpActive()
    {
        _speedPowerUpActive = true;
        StartCoroutine(PowerUpHandler());
    }
    public void ShieldPowerUpActive()
    {
        _shieldPowerUpActive = true;
        _playerShield.SetActive(true);
        StartCoroutine(PowerUpHandler());
    }

    IEnumerator PowerUpHandler()
    {
        yield return new WaitForSeconds(5f);
        _tripleShotActive = false;
        _speedPowerUpActive = false;
        _shieldPowerUpActive = false; 
    }

    public void Damage()
    {
        if(_shieldPowerUpActive == true)
        {
            _shieldPowerUpActive = false;
            _playerShield.SetActive(false);
            return;
        }
        else
        {
            //_lives =_lives -1
            //_lives --
            _lives -= 1;
            _uiManager.UpdateLives(_lives);
            _playerShield.SetActive(false);
        }
        
        if(_lives <= 2)
        {
            _rightEngineDamage.SetActive(true);
        }
        if(_lives == 1)
        {
            _leftEngineDamage.SetActive(true);
        }
        if (_lives < 1)
        {

            _spawnManager.OnPlayerDeath();
            _uiManager.StartCoroutine("GameOver");
            Destroy(this.gameObject);
            
        }
    }

    
    public void Score(int points)
    {
        _score += points;
        _uiManager.UpdateScore(_score);
    }
    
}



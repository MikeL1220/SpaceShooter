using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    [SerializeField]
    private int _lives = 3;
    [SerializeField]
    private float _currentSpeed;
    [SerializeField]
    private float _baseSpeed;
    [SerializeField]
    private float _sprintSpeed;
    [SerializeField]
    private float _powerupSpeed;


    private Vector3 _laserOffset = new Vector3(-.009f, 1.3f, 0);
    [SerializeField]
    private GameObject _laserPrefab;
    private float _fireRate = 0.15f;
    private float _canFire;
    [SerializeField]
    private int _maxAmmo;
    [SerializeField]
    private int _currentAmmo;

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

    public int shieldStrength;
    [SerializeField]

    private GameObject _playerShield;

    [SerializeField]
    private int _score;


    [SerializeField]
    private AudioSource _laserSound;
    [SerializeField]
    private AudioSource _explosionSound;


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

        Debug.LogError("The UI Manager is Null");

        _currentSpeed = _baseSpeed;

        _currentAmmo = _maxAmmo + 1;

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


        if (_speedPowerUpActive == true)
        {
    
            transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * _powerupSpeed * Time.deltaTime);
        }
        else
        {
            
            transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * _baseSpeed * Time.deltaTime);
        }


        if (Input.GetKey(KeyCode.LeftShift))
        {
            _currentSpeed = _sprintSpeed;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _currentSpeed = _baseSpeed;
        }


        if (_speedPowerUpActive == true)
        {
            transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * _powerupSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * _currentSpeed * Time.deltaTime);
        }



        if (transform.position.y >= 0)
        {
            transform.position = new Vector3(transform.position.x, 0f, 0f);
        }
        else if (transform.position.y <= -4.9)
        {
            transform.position = new Vector3(transform.position.x, -4.9f, 0f);
        }


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

            //we had to add 1 to max ammo so the player doesnt burn ammo destroying the asteroid and this program can still run 
            if (_currentAmmo > 0 & _currentAmmo <= _maxAmmo + 1)
            {
                if (_tripleShotActive == true)
                {
                    Instantiate(_tripleShotPrefab, transform.position, Quaternion.identity);
                    Ammocount();
                }
                else
                {

                    Instantiate(_laserPrefab, (transform.position + _laserOffset), Quaternion.identity);
                    Ammocount();
                }

                _laserSound.Play();
            }


        }
    }

    public void TripleShotActive()
    {
        _tripleShotActive = true;

        StartCoroutine(PowerUpHandler());

        StartCoroutine(TripleShotPowerUpHandler());


    }
    public void SpeedPowerUpActive()
    {
        _speedPowerUpActive = true;

        StartCoroutine(PowerUpHandler());

        StartCoroutine(SpeedPowerUpHandler());

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

    IEnumerator TripleShotPowerUpHandler()
    {
        yield return new WaitForSeconds(5f);
        _tripleShotActive = false;

    }
    IEnumerator SpeedPowerUpHandler()
    {
        yield return new WaitForSeconds(5f);
        _speedPowerUpActive = false;


    }

    public void Damage()
    {

        if (_shieldPowerUpActive == true)
        {
            _shieldPowerUpActive = false;
            _playerShield.SetActive(false);
            return;
        }
        else
        {


            if (_shieldPowerUpActive == true)
            {
                ShieldHealth();

            }
            else
            {


                _lives -= 1;
                _uiManager.UpdateLives(_lives);
                _playerShield.SetActive(false);
            }


            if (_lives <= 2)
            {
                _rightEngineDamage.SetActive(true);
            }
            if (_lives == 1)


                if (_lives <= 2)
                {
                    _rightEngineDamage.SetActive(true);
                }
            if (_lives == 1)

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



        _explosionSound.Play();

    }


    public void ShieldHealth()
    {


        if (shieldStrength == 3)
        {

            GameObject.Find("Shields").GetComponent<SpriteRenderer>().material.color = Color.yellow;
            shieldStrength--;

        }
        else if (shieldStrength == 2)
        {

            GameObject.Find("Shields").GetComponent<SpriteRenderer>().material.color = Color.red;
            shieldStrength--;

        }
        else if (shieldStrength == 1)

        {
            //reset shield color
            GameObject.Find("Shields").GetComponent<SpriteRenderer>().material.color = Color.white;
            shieldStrength--;
            _shieldPowerUpActive = false;
            _playerShield.SetActive(false);
            shieldStrength = 3;

        }


    }
    private void Ammocount()
    {
        _currentAmmo--;
        _uiManager.UpdateAmmoCount(_currentAmmo);
        StartCoroutine(_uiManager.NoAmmoIndicator(_currentAmmo));
    }



    public void Score(int points)
    {
        _score += points;
        _uiManager.UpdateScore(_score);
    }

}



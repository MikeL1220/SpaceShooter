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
<<<<<<< HEAD
=======
    public int shieldStrength; 
    [SerializeField]
>>>>>>> e451376 (commit reset issue)
    private GameObject _playerShield;

    [SerializeField]
    private int _score;

<<<<<<< HEAD
=======
    [SerializeField]
    private AudioSource _laserSound;
    [SerializeField]
    private AudioSource _explosionSound;

>>>>>>> e451376 (commit reset issue)
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
<<<<<<< HEAD
            Debug.LogError("The UI Manager is Null"); 
        }
=======
            Debug.LogError("The UI Manager is Null");
        }

        //set the speed value at the start of the game 
        _currentSpeed = _baseSpeed;

        _currentAmmo = _maxAmmo + 1;
>>>>>>> e451376 (commit reset issue)
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
<<<<<<< HEAD

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
        
=======
       //increase speed when the user holds shift
       if(Input.GetKey(KeyCode.LeftShift))
        {
           _currentSpeed = _sprintSpeed;
        }
       else if(Input.GetKeyUp(KeyCode.LeftShift)) 
        {
            _currentSpeed = _baseSpeed; 
        }
       //return to normal speed when shift is released 
        
        if (_speedPowerUpActive == true)
        {
            transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * _powerupSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * _currentSpeed * Time.deltaTime);
        }

>>>>>>> e451376 (commit reset issue)

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
            if(_currentAmmo > 0 & _currentAmmo <= _maxAmmo + 1)
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
<<<<<<< HEAD
        StartCoroutine(PowerUpHandler());
=======
        StartCoroutine(TripleShotPowerUpHandler());
>>>>>>> e451376 (commit reset issue)

    }
    public void SpeedPowerUpActive()
    {
        _speedPowerUpActive = true;
<<<<<<< HEAD
        StartCoroutine(PowerUpHandler());
=======
        StartCoroutine(SpeedPowerUpHandler());
>>>>>>> e451376 (commit reset issue)
    }
    public void ShieldPowerUpActive()
    {
        _shieldPowerUpActive = true;
        _playerShield.SetActive(true);
<<<<<<< HEAD
        StartCoroutine(PowerUpHandler());
    }

    IEnumerator PowerUpHandler()
    {
        yield return new WaitForSeconds(5f);
        _tripleShotActive = false;
        _speedPowerUpActive = false;
        _shieldPowerUpActive = false; 
=======
        
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
       
>>>>>>> e451376 (commit reset issue)
    }

    public void Damage()
    {
<<<<<<< HEAD
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
=======
        if (_shieldPowerUpActive == true)
        {
            ShieldHealth();

        }
        else
        {

>>>>>>> e451376 (commit reset issue)
            _lives -= 1;
            _uiManager.UpdateLives(_lives);
            _playerShield.SetActive(false);
        }
<<<<<<< HEAD
        
        if(_lives <= 2)
        {
            _rightEngineDamage.SetActive(true);
        }
        if(_lives == 1)
=======

        if (_lives <= 2)
        {
            _rightEngineDamage.SetActive(true);
        }
        if (_lives == 1)
>>>>>>> e451376 (commit reset issue)
        {
            _leftEngineDamage.SetActive(true);
        }
        if (_lives < 1)
        {

            _spawnManager.OnPlayerDeath();
            _uiManager.StartCoroutine("GameOver");
            Destroy(this.gameObject);
<<<<<<< HEAD
            
        }
    }

    
=======
            _explosionSound.Play();

        }
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


>>>>>>> e451376 (commit reset issue)
    public void Score(int points)
    {
        _score += points;
        _uiManager.UpdateScore(_score);
    }
<<<<<<< HEAD
    
=======

>>>>>>> e451376 (commit reset issue)
}



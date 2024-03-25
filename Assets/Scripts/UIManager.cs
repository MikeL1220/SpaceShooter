using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
<<<<<<< HEAD
    //handle to text 
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField]
    private GameObject _gameOverText;
    [SerializeField]
    private GameObject _restartText;
=======

    [SerializeField] private TMP_Text _scoreText;

    [SerializeField]
    private GameObject _gameOverText;
    private bool _isGameOver;
    [SerializeField]
    private GameObject _restartText;

>>>>>>> e451376 (commit reset issue)
    [SerializeField]
    private Sprite[] _livesSprites;
    [SerializeField]
    private Image _livesImage;

<<<<<<< HEAD
    private bool _isGameOver;
=======
    [SerializeField] private TMP_Text _ammoText; 
>>>>>>> e451376 (commit reset issue)

    private void Start()
    {
        _scoreText.text = "Score: " + 0;
<<<<<<< HEAD
      
=======
        _ammoText.text = 15 + "/15";

>>>>>>> e451376 (commit reset issue)
    }

    private void Update()
    {
<<<<<<< HEAD
        //Restarts Game
=======
        RestartGame();
        EndGame();

       


    }

    private void RestartGame()
    {

>>>>>>> e451376 (commit reset issue)
        if (Input.GetKeyDown(KeyCode.R) && _isGameOver == true)
        {
            AsyncOperation restart = SceneManager.LoadSceneAsync(1); // Current Game Scene
        }
    }
<<<<<<< HEAD

=======
    private void EndGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Input Registered");
            Application.Quit();

        }
    }
>>>>>>> e451376 (commit reset issue)
    public void UpdateScore(int playerScore)
    {
        _scoreText.text = "Score: " + playerScore;
    }
    public void UpdateLives(int currentLives)
    {
        _livesImage.sprite = _livesSprites[currentLives];

    }
<<<<<<< HEAD
   public IEnumerator GameOver()
=======
    public IEnumerator NoAmmoIndicator(int ammo)
    {
        while (ammo == 0) 
        {
            
            
           
                _ammoText.color = Color.red;
                GameObject ammoText = GameObject.Find("Ammo_Text");
                ammoText.SetActive(false);
                yield return new WaitForSeconds(0.5f);
                ammoText.SetActive(true);
                yield return new WaitForSeconds(0.5f);

            
        
                
        }
      
    }
    public void UpdateAmmoCount(int ammo)
    {
        _ammoText.text = ammo + "/15";
    }
   
    public IEnumerator GameOver()
>>>>>>> e451376 (commit reset issue)
    {

        while (true)
        {
            _isGameOver = true;
            _restartText.SetActive(true);
            _gameOverText.SetActive(true);
            yield return new WaitForSeconds(.5f);
            _gameOverText.SetActive(false);
            yield return new WaitForSeconds(.5f);
<<<<<<< HEAD
            
        }

       
=======

        }


>>>>>>> e451376 (commit reset issue)

    }
}

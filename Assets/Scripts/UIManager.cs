using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField] private TMP_Text _scoreText;
    [SerializeField]
    private GameObject _gameOverText;
    [SerializeField]
    private GameObject _restartText;



    [SerializeField]
    private Sprite[] _livesSprites;
    [SerializeField]
    private Image _livesImage;


    private bool _isGameOver;

    [SerializeField] private TMP_Text _ammoText;


    private void Start()
    {
        _scoreText.text = "Score: " + 0;



        _ammoText.text = 15 + "/15";


    }

    private void Update()
    {

        RestartGame();
        EndGame();




    }

    private void RestartGame()
    {


        if (Input.GetKeyDown(KeyCode.R) && _isGameOver == true)
        {
            AsyncOperation restart = SceneManager.LoadSceneAsync(1); // Current Game Scene
        }
    }



    private void EndGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Input Registered");
            Application.Quit();

        }
    }

    public void UpdateScore(int playerScore)
    {
        _scoreText.text = "Score: " + playerScore;
    }
    public void UpdateLives(int currentLives)
    {
        _livesImage.sprite = _livesSprites[currentLives];

    }

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

    {

        while (true)
        {
            _isGameOver = true;
            _restartText.SetActive(true);
            _gameOverText.SetActive(true);
            yield return new WaitForSeconds(.5f);
            _gameOverText.SetActive(false);
            yield return new WaitForSeconds(.5f);


        }




    }




}



using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //handle to text 
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

    private void Start()
    {
        _scoreText.text = "Score: " + 0;
      
    }

    private void Update()
    {
        //Restarts Game
        if (Input.GetKeyDown(KeyCode.R) && _isGameOver == true)
        {
            AsyncOperation restart = SceneManager.LoadSceneAsync(0); // Current Game Scene
            Debug.Log("Input reading for restart");
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

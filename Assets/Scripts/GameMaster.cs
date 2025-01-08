using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class GameMaster : MonoBehaviour
{
    [SerializeField] public int score;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text highScorePointText;
    [SerializeField] PlayerScript playerScript;
    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject win;
    [SerializeField] GameObject optionsMenu;
    [SerializeField] EnemyMovement enemyMovement;
    [SerializeField] bool IsEndGameFieldCollided = false;
    

    private void Update()
    {
        scoreText.text = score.ToString();
        GameOver();
        OptionsMenu();
    }

    public void OptionsMenu()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            
            Time.timeScale = 0;
            optionsMenu.SetActive(true);
            
            
        }
    }
    public void GameOver()
    {
        if (playerScript.playerLife == 0 || IsEndGameFieldCollided == true)
        {
            
            Time.timeScale = 0;
            gameOver.gameObject.SetActive(true);
            
        }
        if (enemyMovement.enemies.Length <= 0)
        {
            Time.timeScale = 0;
            highScorePointText.text = score.ToString();
            win.gameObject.SetActive(true);
        }
    }

    public void ReturnToGame()
    {
        
        Time.timeScale = 1;
        optionsMenu.SetActive(false);
        
    }

    public void NewGame()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1; 
    }

    public void Quit()
    {
        Application.Quit();
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            IsEndGameFieldCollided = true;
        }
    }

}

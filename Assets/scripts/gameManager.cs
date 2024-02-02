using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public Transform playerPaddle;
    public Transform enemyPaddle;
    public ballController ballController;
    public TextMeshProUGUI textEndGame;
    public GameObject screenEndGame;

    public int PlayerScore = 0;
    public int EnemyScore = 0;

    public int winScore = 5;

    public TextMeshProUGUI textPointsPlayer;
    public TextMeshProUGUI textPointsEnemy;


    // Start is called before the first frame update
    void Start()
    {
        ResetGame();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ResetGame()
    {
        screenEndGame.SetActive(false);
        playerPaddle.position = new Vector3(-7f, 0f, 0f);
        enemyPaddle.position = new Vector3(7f, 0f, 0f);


        ballController.resetBall();

        PlayerScore = 0;
        EnemyScore = 0;

        textPointsEnemy.text = EnemyScore.ToString();
        textPointsPlayer.text = PlayerScore.ToString();
    }

    public void scorePlayer()
    {
        PlayerScore++;
        textPointsPlayer.text = PlayerScore.ToString();
        winCheck();
    }

    public void scoreEnemy()
    {
        EnemyScore++;
        textPointsEnemy.text = EnemyScore.ToString();
        winCheck();
    }

    public void winCheck()
    {
        if (EnemyScore >= winScore || PlayerScore >= winScore)
        {
            endGame();
        }
    }

    public void endGame()
    {
        screenEndGame.SetActive(true);
        string winner = saveController.Instance.getName(PlayerScore > EnemyScore);
        textEndGame.text = "Vitória " + saveController.Instance.getName(PlayerScore > EnemyScore);
        saveController.Instance.saveWinner(winner);
        Invoke("LoadMenu", 2f);
    }

    private void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }


}

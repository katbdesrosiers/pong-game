using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Ball")]
    public GameObject ball;

    [Header("Player 1")]
    public GameObject player1Paddle;
    public GameObject player1Goal;

    [Header("Player 2")]
    public GameObject player2Paddle;
    public GameObject player2Goal;

    [Header("Score UI")]
    public GameObject Player1Text;
    public GameObject Player2Text;

    [Header("Start Message")]
    public GameObject StartMessage;

    [Header("Game Complete")]
    public GameObject Player1Win;
    public GameObject Player2Win;

    private int Player1Score;
    private int Player2Score;

	private void Start()
	{
        Player1Win.GetComponent<TextMeshProUGUI>().enabled = false;
        Player2Win.GetComponent<TextMeshProUGUI>().enabled = false;
    }

	private void Update()
	{
        if (Input.GetKey(KeyCode.KeypadEnter) || Input.GetKey("return"))
        {
            ball.GetComponent<Ball>().Reset();
            Destroy(StartMessage);
            Player1Win.GetComponent<TextMeshProUGUI>().enabled = false;
            Player2Win.GetComponent<TextMeshProUGUI>().enabled = false;
            Player1Score = 0;
            Player1Text.GetComponent<TextMeshProUGUI>().text = Player1Score.ToString();
            Player2Score = 0;
            Player2Text.GetComponent<TextMeshProUGUI>().text = Player2Score.ToString();

            Player1Text.GetComponent<TextMeshProUGUI>().color = new Color32(255, 255, 255, 255);
            Player2Text.GetComponent<TextMeshProUGUI>().color = new Color32(255, 255, 255, 255);
        }
	}

    public void Player1Scored()
	{
        Player1Score++;
        Player1Text.GetComponent<TextMeshProUGUI>().text = Player1Score.ToString();
        CheckScore();
        if (!CheckForWin())
		{
            ResetPosition();
		}
	}

    public void Player2Scored()
    {
        Player2Score++;
        Player2Text.GetComponent<TextMeshProUGUI>().text = Player2Score.ToString();
        CheckScore();
        if (!CheckForWin())
        {
            ResetPosition();
        }
    }

    private void ResetPosition()
	{
        ball.GetComponent<Ball>().Reset();
        player1Paddle.GetComponent<Paddle>().Reset();
        player2Paddle.GetComponent<Paddle>().Reset();
    }

    private void CheckScore()
	{
        if (int.Parse(Player1Text.GetComponent<TextMeshProUGUI>().text) > int.Parse(Player2Text.GetComponent<TextMeshProUGUI>().text))
		{
            Player1Text.GetComponent<TextMeshProUGUI>().color = new Color32(20, 148, 20, 255);
            Player2Text.GetComponent<TextMeshProUGUI>().color = new Color32(212, 17, 17, 255);
        }
        else
		{
            Player2Text.GetComponent<TextMeshProUGUI>().color = new Color32(20, 148, 20, 255);
            Player1Text.GetComponent<TextMeshProUGUI>().color = new Color32(212, 17, 17, 255);
        }

        if (int.Parse(Player1Text.GetComponent<TextMeshProUGUI>().text) == int.Parse(Player2Text.GetComponent<TextMeshProUGUI>().text))
        {
            Player1Text.GetComponent<TextMeshProUGUI>().color = new Color32(255, 255, 255, 255);
            Player2Text.GetComponent<TextMeshProUGUI>().color = new Color32(255, 255, 255, 255);
        }
    }

    private bool CheckForWin()
	{
        if (int.Parse(Player1Text.GetComponent<TextMeshProUGUI>().text) == 7)
        {
            Player1Win.GetComponent<TextMeshProUGUI>().enabled = true;
            return true;
        }
        else if (int.Parse(Player2Text.GetComponent<TextMeshProUGUI>().text) == 7)
        {
            Player2Win.GetComponent<TextMeshProUGUI>().enabled = true;
            return true;
        }

        return false;
    }
}
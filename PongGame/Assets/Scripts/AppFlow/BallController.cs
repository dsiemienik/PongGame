using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BallController : MonoBehaviour {

    public float ballSpeed;

    [Range(1f, 5f)]
    public float acceleration = 1.1f;

    System.Action<string> OnBallReachBound;
    private GameController gameController;

    private float ballStartSpeed = 1f;
    private Vector2 direction;
    private List<Vector2> Directions = new List<Vector2>();
    private Vector3 startPosition;

    void Start ()
    {
        InitDirectionsList();
        gameController = FindObjectOfType<GameController>();

        startPosition = Vector3.zero;
        ResetBall();

        OnBallReachBound += onBallReachBound;
	}
	
	void FixedUpdate ()
    {
        if(gameController.gameStarted)
        {
            transform.Translate(direction * ballSpeed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.transform.tag)
        {
            case "BoundY":
                direction.y = -direction.y;
                break;
            case "PlayerLeft":
                direction.x = -direction.x;
                ballSpeed *= acceleration;
                break;
            case "PlayerRight":
                direction.x = -direction.x;
                ballSpeed *= acceleration;
                break;
            case "BoundXLeft":
                if(OnBallReachBound != null)
                {
                    OnBallReachBound(collision.transform.tag);
                }
                break;
            case "BoundXRight":
                if (OnBallReachBound != null)
                {
                    OnBallReachBound(collision.transform.tag);
                }
                break;
            default:
                break;
        }
    }
    void onBallReachBound(string tag)
    {
        if (tag == "BoundXLeft")
        {
            gameController.playerRight.score++;
            gameController.playerRightScores.text = "Player right score: " + gameController.playerRight.score;

            if (gameController.playerRight.score < gameController.maxPoints)
            {
                ResetBall();
            }
            else
            {
                gameController.endText.text = "Player right win the game!\n" + "Press any button to restart!";
                gameController.OnGameFinished();
                ballSpeed = 0f;
            }
        }
        else
        {
            gameController.playerLeft.score++;
            gameController.playerLeftScores.text = "Player left score: " + gameController.playerLeft.score;

            if (gameController.playerLeft.score < gameController.maxPoints)
            {
                ResetBall();
            }
            else
            {
                gameController.endText.text = "Player left win the game!\n" + "Press any button to restart!";
                gameController.OnGameFinished();
                ballSpeed = 0f;
            }
        }
    }
    void ResetBall()
    {
        transform.position = startPosition;
        direction = RandomizeBallStartDirection();
        ballSpeed = ballStartSpeed;
    }
    void InitDirectionsList()
    {
        Directions.Add(new Vector2(1f, 1f).normalized);
        Directions.Add(new Vector2(-1f, -1f).normalized);
        Directions.Add(new Vector2(-1f, 1f).normalized);
        Directions.Add(new Vector2(1f, -1f).normalized);
    }
    Vector2 RandomizeBallStartDirection()
    {
        return Directions[Random.Range(0, Directions.Count - 1)];
    }
}

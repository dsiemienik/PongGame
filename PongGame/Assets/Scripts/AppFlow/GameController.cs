using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour {

    public TextMeshProUGUI endText;
    public TextMeshProUGUI playerLeftScores;
    public TextMeshProUGUI playerRightScores;

    public Fader endPanelFader;
    public Fader startPanelFader;

    public PlayerController playerLeft;
    public PlayerController playerRight;
    public EnemyController enemy;

    public float maxPoints;

    [HideInInspector]
    public Vector3 bottomLeft;
    [HideInInspector]
    public Vector3 topRight;
    [HideInInspector]
    public bool gameStarted;

    private bool gameFinished;


    private void Awake()
    {
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 10));
        topRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 10));

        switch (PlayerPrefs.GetInt("difficulty"))
        {
            case 0:
                enemy.difficultyLevel = DifficultyLevel.Easy;
                enemy.gameObject.SetActive(true);
                enemy.Init();
                break;
            case 1:
                enemy.difficultyLevel = DifficultyLevel.Medium;
                enemy.gameObject.SetActive(true);
                enemy.Init();
                break;
            case 2:
                enemy.difficultyLevel = DifficultyLevel.High;
                enemy.gameObject.SetActive(true);
                enemy.Init();
                break;
            default:
                playerRight.gameObject.SetActive(true);
                break;
        }
    }
    private void Start()
    {
        gameStarted = false;
        startPanelFader.ShowUI();
    }
    void Update ()
    {
        if(!gameStarted)
        {
            if(Input.anyKey)
            {
                gameStarted = true;
                startPanelFader.HideUI();
            }
            return;
        }

		if(gameFinished)
        {
            if(Input.anyKeyDown)
            {
                ResetGame();
            }
        }
	}
    public void OnGameFinished()
    {
        gameFinished = true;
        endPanelFader.ShowUI();
    }
    void ResetGame()
    {
        SceneLoadingController.Instance.LoadScene(GameScenes.Main, true);
    }
}

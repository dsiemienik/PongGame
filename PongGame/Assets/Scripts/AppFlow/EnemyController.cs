using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : PlayerController {

    public DifficultyLevel difficultyLevel;

    public Transform target;

    public void Init()
    {
        base.Start();

        switch (difficultyLevel)
        {
            case DifficultyLevel.Easy:
                speed = speed / 2f;
                break;
            case DifficultyLevel.Medium:
                speed = speed * 1.5f;
                break;
            case DifficultyLevel.High:
                speed = speed * 3f;
                break;
            default:
                break;
        }
    }
    private void FixedUpdate()
    {
        if (gameController.gameStarted)
        {
            var vector = Vector2.MoveTowards(new Vector2(transform.position.x, Mathf.Clamp(transform.position.y, yMin, yMax)),
                    new Vector2(target.position.x, Mathf.Clamp(target.position.y, yMin, yMax)), Time.deltaTime * speed);
            vector.x = transform.position.x;
            transform.position = vector;
        }
    }
}

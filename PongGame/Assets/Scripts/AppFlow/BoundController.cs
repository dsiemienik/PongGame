using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundController : MonoBehaviour {

    public BoundPositions boundPosition;

    private GameController gameController;

    void Start()
    {
        gameController = FindObjectOfType<GameController>();

        Vector3 pos = Vector3.zero;

        switch (boundPosition)
        {
            case BoundPositions.Left:
                pos = new Vector3(gameController.bottomLeft.x, gameController.topRight.y / 2);
                pos -= transform.localScale.x / 2f * Vector3.right;
                break;
            case BoundPositions.Right:
                pos = new Vector3(gameController.topRight.x, gameController.topRight.y / 2);
                pos += transform.localScale.x / 2f * Vector3.right;
                break;
            case BoundPositions.Top:
                pos = new Vector3(gameController.topRight.x / 2f, gameController.topRight.y);
                pos += transform.localScale.y / 2f * Vector3.up;
                break;
            case BoundPositions.Bottom:
                pos = new Vector3(gameController.topRight.x / 2f, gameController.bottomLeft.y);
                pos -= transform.localScale.y / 2f * Vector3.up;
                break;
            default:
                break;
        }
        transform.position = pos;
    }
}

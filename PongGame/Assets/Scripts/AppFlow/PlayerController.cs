using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public Players player;
    public float speed;
    public float score;

    protected float yMin, yMax;
    protected float clampedVerticalValue = 0;
    protected GameController gameController;
    private string input;
    protected Rigidbody2D rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Start()
    {
        gameController = FindObjectOfType<GameController>();

        yMin = gameController.bottomLeft.y + transform.localScale.y + transform.localScale.y / 2f;
        yMax = gameController.topRight.y - transform.localScale.y - transform.localScale.y / 2f;

        if (player == Players.PlayerLeft)
        {
            input = "PlayerLeft";
            Vector3 pos = new Vector2(gameController.bottomLeft.x, 0);
            pos += transform.localScale.x * Vector3.right;
            transform.position = pos;
        }
        else
        {
            input = "PlayerRight"; 
            Vector3 pos = new Vector2(gameController.topRight.x, 0);
            pos -= transform.localScale.x * Vector3.right;
            transform.position = pos;
        }

        
    }
    
    void FixedUpdate()
    {
        if(gameController.gameStarted)
        {
            float moveVertical = Input.GetAxis(input);

            var movement = new Vector2(0, moveVertical);
            rigidbody.velocity = movement * speed;

            clampedVerticalValue = Mathf.Clamp(rigidbody.position.y, yMin, yMax);

            rigidbody.position = new Vector2
            (
                transform.position.x,
                clampedVerticalValue
            );
        }
    }
}

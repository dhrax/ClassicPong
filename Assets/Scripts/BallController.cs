using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    Vector2 direction;
    Rigidbody2D rb;

    [SerializeField]
    Ball ballData;

    [SerializeField]
    ScoreController scoreController;

    SpriteRenderer sprite;

    private Vector2 screenSize;

    private Vector2 maxBallPositionOnScreen;

    private Vector3 ballSize;

    bool gameIsPlaying;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sprite = gameObject.GetComponent<SpriteRenderer>();

        screenSize = GetScreenSize();
        maxBallPositionOnScreen = GetMaxBallPositionOnScreen();
        ballSize = GetBallSize();

        Vector2 startingDir = Vector2.zero;
        startingDir.x = Random.value >= 0.5 ? 1f : -1f;
        startingDir.y = Random.value >= 0.5 ? 1f : -1f;

        gameIsPlaying = true;

        direction = startingDir.normalized;

        Debug.Log(maxBallPositionOnScreen);
    }

    private void FixedUpdate()
    {
        if (gameIsPlaying)
        {
            if (rb.position.x >= maxBallPositionOnScreen.x || rb.position.x <= -maxBallPositionOnScreen.x)
            {
                gameIsPlaying = false;
                short playerID = -1;
                ChangeSpriteOpacity(sprite, 0f);
                if (rb.position.x >= maxBallPositionOnScreen.x)
                {
                    playerID = 0;
                }
                else
                {
                    playerID = 1;
                }
                scoreController.PointScored(playerID);

                StartCoroutine(RestartBallPosition());
            }

            if (rb.position.y >= maxBallPositionOnScreen.y || rb.position.y <= -maxBallPositionOnScreen.y)
            {
                changeDirection(false);
            }

            rb.MovePosition(rb.position + direction * ballData.speed * Time.fixedDeltaTime);
        }

    }

    private void changeDirection(bool changeXDirection)
    {

        float newXDir = 0f;
        float newYDir = 0f;
        if (changeXDirection)
        {
            newXDir = !(direction.x < 0) ? -1f : 1f;
            newYDir = !(direction.y < 0) ? 1f : -1f;
        }
        else
        {
            newXDir = direction.x < 0 ? -1f : 1f;
            newYDir = direction.y < 0 ? 1f : -1f;
        }

        direction = new Vector2(newXDir, newYDir); ;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            changeDirection(true);
        }
    }

    IEnumerator RestartBallPosition()
    {
        yield return new WaitForSeconds(2);
        rb.position = Vector2.zero;
        gameIsPlaying = true;
        ChangeSpriteOpacity(sprite, 1f);
    }

    void ChangeSpriteOpacity(SpriteRenderer sprite, float opactity)
    {
        Color tmp = sprite.color;
        tmp.a = opactity;
        sprite.color = tmp;
    }

    //get screen size in world scale
    Vector2 GetScreenSize()
    {

        float height = Camera.main.orthographicSize * 2.0f;
        float width = height * Screen.width / Screen.height;

        return new Vector2(width, height);
    }

    Vector2 GetMaxBallPositionOnScreen()
    {
        float halfBallSizeX = GetBallSize().x / 2.0f;
        float halfBallSizeY = GetBallSize().y / 2.0f;

        float halfScreenSizeX = screenSize.x / 2.0f;
        float halfScreenSizeY = screenSize.y / 2.0f;

        float x = (screenSize.x - GetBallSize().x) / 2.0f;
        float y = (screenSize.y - GetBallSize().y) / 2.0f;

        return new Vector2(x, y);
    }

    //get object size in world scale
    Vector3 GetBallSize()
    {
        return GetComponent<Renderer>().bounds.size;
    }

}

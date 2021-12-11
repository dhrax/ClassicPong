using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector2 movement;
    Rigidbody2D rb;

    string axisName;

    public Player playerData;

    [SerializeField]
    UIManager uIManager;

    private Vector3 playerSize
    {
        //get object size in world scale
        get { return GetComponent<Renderer>().bounds.size; }
    }

    private Vector2 maxPlayerPositionOnScreen{
        get{
            float x = (screenSize.x - playerSize.x) / 2.0f;
            float y = (screenSize.y - playerSize.y) / 2.0f;

            return new Vector2(x, y);
        }
    }

    private Vector2 screenSize
    {
        get
        {
            //get screen size in world scale
            float height = Camera.main.orthographicSize * 2.0f;
            float width = height * Screen.width / Screen.height;

            return new Vector2(width, height);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        axisName =  "Vertical" + playerData.ID;
        movement = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        movement.y = Input.GetAxis(axisName);
        CheckPlayerInScreen();
    }

    public void addScore(){
        playerData.score++;
        uIManager.ChangeScore(playerData.ID, playerData.score);
    }

    void CheckPlayerInScreen(){
        Vector2 newPosition = rb.position + movement * playerData.speed * Time.fixedDeltaTime;
        if(newPosition.y >= maxPlayerPositionOnScreen.y){
            newPosition.y = maxPlayerPositionOnScreen.y;
        }else if(newPosition.y <= -maxPlayerPositionOnScreen.y){
            newPosition.y = -maxPlayerPositionOnScreen.y;
        }

        rb.MovePosition(newPosition);
    }

}

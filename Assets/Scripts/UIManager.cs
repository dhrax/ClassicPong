using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField]
    Text player0Score;

    [SerializeField]
    Text player1Score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScore(short playerID, int score){
        switch(playerID){
            case 0:
            player0Score.text = score.ToString();
            break;
            case 1:
            player1Score.text = score.ToString();
            break;
            default:
            Debug.LogError("Wrong playerID for score!!");
            break;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{

    [SerializeField]
    List<PlayerController> players;

    public void PointScored(short playerID)
    {
        switch (playerID)
        {
            case 0:
                players[0].addScore();
                break;
            case 1:
                players[1].addScore();
                break;
            default:
                Debug.LogError("Wrong playerID when scoring!!");
                break;
        }
    }
}

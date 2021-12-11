using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player", menuName = "Create Player/New Player")]
public class Player : ScriptableObject
{
    new public string name;

    public short ID;

    public int score;

    public float speed;
    
}

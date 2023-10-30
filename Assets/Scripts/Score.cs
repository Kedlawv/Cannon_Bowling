using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Score 
{
    [SerializeField]
    public string PlayerName;
    [SerializeField]
    public int Count;
}

// todo create a wrapper class for the list of scores and test if it serializes correctly

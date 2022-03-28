using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    //Name of the NPC that you're interacting with
    public string name;

    [TextArea(2, 10)]                   //Range of the amount of phrases per NPC.
    public string[] sentences;          //Array that holds the dialogue sentences for each NPC.
}

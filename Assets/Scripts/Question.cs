using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Question {

    public Sprite signBoard;
    public string[] answers = new string[3];
    public int correct;
}

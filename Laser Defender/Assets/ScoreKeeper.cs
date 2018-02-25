using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class ScoreKeeper : MonoBehaviour {
    public int score;
    private Text myText;
    void Start(){
        myText = GetComponent<Text>();
    }
    public void Score(int points)
    {
        Debug.Log("Scored points");
        score += points;
        myText.text = score.ToString();
    }
    public void Reset()
    {
        score = 0;
        myText.text = score.ToString();
    }
}

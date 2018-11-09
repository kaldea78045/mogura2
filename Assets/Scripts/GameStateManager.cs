using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour {

    [SerializeField]GameObject CountText;
    [SerializeField]GameObject ScoreText;
    [SerializeField]GameObject TimeText;
    string count;
    string score;
    string time;
    int countNum;
    int scoreNum;
    int timeNum;

    // Use this for initialization
    void Start () {
        InitGame();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void InitGame()
    {
        countNum = 3;
        scoreNum = 0;
        timeNum = 60;

        CountText.GetComponent<TextMesh>().text = countNum.ToString();
        ScoreText.GetComponent<TextMesh>().text = scoreNum.ToString();
        TimeText.GetComponent<TextMesh>().text  = timeNum.ToString();

        
    }

    public void SetScore()
    {
        scoreNum ++;
        ScoreText.GetComponent<TextMesh>().text = scoreNum.ToString();
    }
}

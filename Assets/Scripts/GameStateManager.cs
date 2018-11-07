using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour {

    [SerializeField]GameObject CountText;
    [SerializeField]GameObject ScoreText;
    [SerializeField]GameObject TimeText;
    int countNum;
    int scoreNum;
    int timeNum;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void InitGame()
    {
        countNum = 3;
        scoreNum = 0;
        timeNum  = 60;
    }
}

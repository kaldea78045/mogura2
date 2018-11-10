using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour {

    [SerializeField]GameObject CountText;
    [SerializeField]GameObject ScoreText;
    [SerializeField]GameObject TimeText;
    TextMesh count;
    TextMesh score;
    TextMesh time;
    int countNum;
    int scoreNum;
    float timeNum;
    int currentState;
    bool ready = false;
    enum STATE
    {
        NONE   = 0,
        READY  = 1,
        PLAY   = 2,
        RESULT = 3
    }

    // Use this for initialization
    void Start () {
        count = CountText.GetComponent<TextMesh>();
        score = ScoreText.GetComponent<TextMesh>();
        time = TimeText.GetComponent<TextMesh>();
        currentState = (int)STATE.NONE;
        count.text = "ボタンを押して\n" +
                     "スタート";

        InitGame();
	}
	
	// Update is called once per frame
	void Update () {

        if (currentState == (int)STATE.NONE)
        {
            if (Input.anyKey)
                StartCoroutine(CountDown());
        }else if (currentState == (int)STATE.READY)
        {
            
        }
        else if(currentState == (int)STATE.PLAY)
        {
            ReduceTime();
            if (timeNum <= 0)
                currentState = (int)STATE.RESULT;
        }
        else if(currentState == (int)STATE.RESULT)
        {
            count.text = "ゲーム終了\n" +
                         "Rキーで\n" +
                         "もう一度プレイ";

            if (Input.GetKey(KeyCode.R))
            {
                InitGame();
                StartCoroutine(CountDown());
            }

        }
        
	}


    public void InitGame()
    {
        countNum = 3;
        scoreNum = 0;
        timeNum = 60f;
        score.text = null;
        time.text  = null;

        
    }
    public void ReduceTime()
    {
        timeNum -= Time.deltaTime;
        time.text = timeNum.ToString("f0") + "秒";
    }
    public void SetScore()
    {
        scoreNum ++;
        score.text = scoreNum.ToString() + "点";

    }

    public int GetState()
    {
        return currentState;
    }

    private IEnumerator CountDown()
    {
        currentState = (int)STATE.READY;
        score.text = scoreNum.ToString() + "点";
        time.text = timeNum.ToString("f0") + "秒";
        count.text = "準備はいい？";
        yield return new WaitForSeconds(3f);
        count.text = "はじめ！！" ;
        currentState = (int)STATE.PLAY;
        yield return new WaitForSeconds(1f);
        count.text = null;

    }
}

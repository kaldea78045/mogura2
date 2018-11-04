using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoguraController : MonoBehaviour {

    private Vector3 vPos;                   //もぐらの位置情報
    private bool    bHit        = false;    //もぐらが叩かれた
    private bool    bAppear     = false;    //もぐらが現れてる
    private bool    bAct        = false;    //もぐら行動中
    private float   fMoveWait   = 0.5f;     //移動時間
    private float currentWait   = 0.0f;     //移動待ち時間
    private float moveSpeed     = 0.2f;     //移動速度
    private float fRandomTime;              //もぐら入出判定時間
    private float currentTime;              //判定用の時間
    private Vector3 oldPos;
    private Vector3 nextPos;
	// Use this for initialization
	void Start () {

        fRandomTime = Random.Range(1.5f, 3.5f);
        oldPos  = new Vector3(3f,-0.8f,0.3f);
        nextPos = new Vector3(3f, 0.3f, 0.3f);

    }
	
	// Update is called once per frame
	void Update () {
        currentTime += Time.deltaTime;

        //もぐら出現済みの場合
        if(!bAct && !bHit && bAppear && currentTime >= fRandomTime)
        {
            StartCoroutine(MoguraDown());

        }
        //もぐら隠れてる状態の場合
        else if (!bAct && !bHit && !bAppear && currentTime >= fRandomTime)
        {
            StartCoroutine(MoguraUp());
        }


	}

    //もぐら出現処理
    /*
     * ①bActとtrueにして動作の重複制御
     * ②移動時間が指定時間に達するまでY軸移動
     * ③次の移動判定時間を乱数で指定
     * ④移動時間と移動待ち時間を初期化
     * ⑤bActを初期化、出現フラグをtrueにする
     */
    private IEnumerator MoguraUp()
    {
        bAct = true;
        Debug.Log("出現");
        // ループ
        while (currentWait <= fMoveWait)
        {
            transform.Translate(0, 0.05f, 0);
            yield return new WaitForSeconds(0.025f);
            currentWait += 0.025f;
        }
        
        fRandomTime = Random.Range(1.5f, 3.5f);
        currentWait = 0f;
        currentTime = 0f;
        bAct = false;
        bAppear = true;

    }

    //もぐら隠れる処理
    /*
    * ①bActとtrueにして動作の重複制御
    * ②移動時間が指定時間に達するまでY軸移動
    * ③次の移動判定時間を乱数で指定
    * ④移動時間と移動待ち時間を初期化
    * ⑤bActを初期化、出現フラグをfalseにする
    */
    private IEnumerator MoguraDown()
    {
        bAct = true;
        Debug.Log("隠れる");
        while (currentWait <= fMoveWait)
        {
            transform.Translate(0, -0.05f, 0);
            yield return new WaitForSeconds(0.025f);
            currentWait += 0.025f;
        }
        //Vector3.Lerp(oldVelocity, velocity, moveSpeed * Time.deltaTime);
        fRandomTime = Random.Range(0.5f, 1.5f);
        currentWait = 0f;
        currentTime = 0f;
        bAct = false;
        bAppear = false;

    }

    private void OnTriggerEnter(Collider other)
    {

        Destroy(gameObject);
        
    }


}

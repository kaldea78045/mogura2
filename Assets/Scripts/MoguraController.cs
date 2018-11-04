using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoguraController : MonoBehaviour {

    private Vector3 vPos;                   //もぐらの位置情報
    private bool    bHit        = false;    //もぐらが叩かれた
    private bool    bAppear     = false;    //もぐらが現れてる
    private bool    bAct        = false;    //もぐら行動中
    private float   fMoveTime   = 0.5f;     //移動時間
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
    private IEnumerator MoguraUp()
    {
        bAct = true;
        Debug.Log("出現");
        transform.Translate(0,+1.1f,0);
        yield return new WaitForSeconds(fMoveTime);
        fRandomTime = Random.Range(1.5f, 3.5f);
        currentTime = 0f;
        bAct = false;
        bAppear = true;
    }

    //もぐら隠れる処理
    private IEnumerator MoguraDown()
    {
        bAct = true;
        Debug.Log("隠れる");
        transform.Translate(0, -1.1f, 0);
        //Vector3.Lerp(oldVelocity, velocity, moveSpeed * Time.deltaTime);
        yield return new WaitForSeconds(fMoveTime);
        fRandomTime = Random.Range(0.5f, 1.5f);
        currentTime = 0f;
        bAct = false;
        bAppear = false;

    }

    private void OnTriggerEnter(Collider other)
    {

        Destroy(gameObject);
        
    }


}

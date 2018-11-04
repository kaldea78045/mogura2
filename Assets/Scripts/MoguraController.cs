﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoguraController : MonoBehaviour {

    private Vector3 vPos;       //もぐらの位置情報
    private bool    bHit;          //もぐらが叩かれた
    private bool    bAppear;       //もぐらが現れてる
    private float   fMoveTime;     //
    private float fRandomTime;     //
    private float currentTime;     //
	// Use this for initialization
	void Start () {

        fRandomTime = Random.Range(0f, 2.5f);

    }
	
	// Update is called once per frame
	void Update () {
		
        //もぐら出現済みの場合
        if(!bHit && bAppear)
        {
            MoguraDown();

        }
        //もぐら隠れてる状態の場合
        else if (!bHit && !bAppear)
        {
            MoguraUp();
        }


	}

    //もぐら出現処理
    private IEnumerator MoguraUp()
    {
        yield return new WaitForSeconds(fMoveTime);
        fRandomTime = Random.Range(0f, 2.5f);
        bAppear = true;
    }

    //もぐら隠れる処理
    private IEnumerator MoguraDown()
    {
        yield return new WaitForSeconds(fMoveTime);
        fRandomTime = Random.Range(0f, 2.5f);
        bAppear = false;

    }

    private void OnTriggerEnter(Collider other)
    {
        
            Debug.Log("ヒット");
        
    }


}

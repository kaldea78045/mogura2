using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoguraController : MonoBehaviour {

    private Vector3 vPos;       //もぐらの位置情報
    private bool    bHit;          //もぐらが叩かれた
    private bool    bAppear;       //もぐらが現れてる
    private float   fMoveTime;
	// Use this for initialization
	void Start () {
		
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
        bAppear = true;

    }

    //もぐら隠れる処理
    private IEnumerator MoguraDown()
    {
        yield return new WaitForSeconds(fMoveTime);
        bAppear = false;
    }



}

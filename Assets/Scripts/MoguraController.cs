using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoguraController : MonoBehaviour {

    private Vector3 moguraPos;
    private bool bHit;          //もぐらが叩かれた
    private bool bAppear;       //もぐらが現れてる
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        //もぐら出現済みの場合
        if(!bHit && !bAppear)
        {

        }
        //もぐら隠れてる状態の場合
        else if (!bHit && bAppear)
        {

        }


	}


    private void MoguraUp()
    {


    }

    private void MoguraDown()
    {

    }



}

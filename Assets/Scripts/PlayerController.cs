using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] GameObject hanmer;
    private Animator ha;
    // Use this for initialization
    void Start () {
        ha = hanmer.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        //マウスをクリックしたところにハンマー移動
        if (Input.GetMouseButton(0))
        {
            ha.SetTrigger("click");



        }

        if (Input.GetKey("left"))
        {
            //hanmer new Vector3( , 0, 0);
        }

        if (Input.GetKey("right"))
        {
           
        }

    }



}

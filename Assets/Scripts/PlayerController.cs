using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class PlayerController : MonoBehaviour {

    [SerializeField] GameObject hanmer;
    private Animator ha;

    private float waitTime = 0.95f;
    private bool ableAct = true;
    // Use this for initialization
    void Start() {
        ha = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {

      
        //マウスをクリックしたところにハンマー移動
        if (Input.GetMouseButton(0) && ableAct )
        {

            ha.SetTrigger("click");
            StartCoroutine(HammerCT());

        }

        if (Input.GetKey("left"))
        {
            //hanmer new Vector3( , 0, 0);
        }

        if (Input.GetKey("right"))
        {

        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(-0.01f,0,0);
        }

    }

    private IEnumerator HammerCT(){
        ableAct = false;
        yield return new WaitForSeconds(waitTime);
        ableAct = true;
    }
    

}

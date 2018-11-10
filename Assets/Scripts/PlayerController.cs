using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class PlayerController : MonoBehaviour {

   
    private Animator ha;

    private float waitTime = 1f;
    private bool ableAct = true;
    Vector3 hammerPosition;
    // Use this for initialization
    void Start() {
        ha = gameObject.GetComponent<Animator>();
        hammerPosition = gameObject.transform.position;
    }
    // Update is called once per frame

    void Update() {

      
        //マウスをクリックしたところにハンマー移動
        if (Input.GetMouseButton(0) && ableAct )
        {
            ha.SetTrigger("click");
            StartCoroutine(HammerCT());

        }

        if (ableAct && Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.transform.Translate( 0, 0, -0.05f);
        }

        if (ableAct && Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.transform.Translate(0, 0, 0.05f);
        }

       

    }

    private IEnumerator HammerCT(){
        ableAct = false;
        yield return new WaitForSeconds(waitTime);
        ableAct = true;
    }
    

}

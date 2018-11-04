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

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.transform.Translate( 0, 0, -0.02f);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.transform.Translate(0, 0, 0.02f);
        }

       

    }

    private IEnumerator HammerCT(){
        ableAct = false;
        yield return new WaitForSeconds(waitTime);
        ableAct = true;
    }
    

}

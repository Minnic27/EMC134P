using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkTextUI : MonoBehaviour
{
    Text textUI;
    public GameObject spaceship;
    public bool isTrue;
    private bool blink;


    // Start is called before the first frame update
    void Start()
    {
        textUI = GetComponent<Text>();
        spaceship = GameObject.Find("StarSparrow1");
        
    }

    // Update is called once per frame
    void Update() {
        if (isTrue == false) {
            BlinkUI();
            isTrue = true;
        }
    }

    void BlinkUI()
    {
        blink = spaceship.GetComponent<PhysicsMovement>().netForceCheck;
        if (blink) {
            StartCoroutine(BlinkSuccess());
        } else {
            StartCoroutine(BlinkFail());
        }
    }


    IEnumerator BlinkSuccess() {

        while (true) {

            textUI.text = " ";
            yield return new WaitForSeconds(1f);
            textUI.color = Color.green;
            textUI.text = "Success!";
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator BlinkFail() {

        while (true) {

            textUI.text = " ";
            yield return new WaitForSeconds(1f);
            textUI.color = Color.red;
            textUI.text = "Unbalanced Force Detected";
            yield return new WaitForSeconds(1f);
        }
    }
}

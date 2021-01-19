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
    void Update()
    {
        blink = spaceship.GetComponent<PhysicsMovement>().netForceCheck;
        if (blink) {
            StartCoroutine(BlinkSuccess());
            blink = false;
        } else {
            StartCoroutine(BlinkFail());
        }
    }


    IEnumerator BlinkSuccess() {

        while (true) {

            textUI.text = " ";
            yield return new WaitForSeconds(1f);
            textUI = GetComponent<Text>();
            textUI.color = Color.green;
            textUI.text = "Success!";
            yield return new WaitForSeconds(2f);
        }
    }

    IEnumerator BlinkFail() {

        while (true) {

            textUI.text = " ";
            yield return new WaitForSeconds(1f);
            textUI = GetComponent<Text>();
            textUI.color = Color.red;
            textUI.text = "Unbalanced Force Detected";
            yield return new WaitForSeconds(2f);
        }
    }
}

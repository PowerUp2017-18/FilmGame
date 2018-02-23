using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour {
	
	public TextMesh countdownText;

	public float countdownInt = 5f;
	public string countdownStr;

	public GameObject boom;

	void Start() {
		countdownText = GetComponent<TextMesh>();
	}

	void Update() {
		TimerText();
	}

    public void TimerText() {
    	countdownStr = countdownInt.ToString("f1");

    	if(boom.GetComponent<KaboomMic>().detected == true) {
    		countdownInt -= Time.deltaTime;
    	}
    	if(countdownInt == 0 && boom.GetComponent<KaboomMic>().detected == false) {
    		countdownInt = 5f;
    	}
    	countdownText.text = countdownStr;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour {
	
	public TextMesh countdownText;

	public float countdownInt = 5;
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
    		countdownInt -= 1 * Time.deltaTime;
    		Debug.Log("fsfs");
    	}
    	countdownText.text = countdownStr;
    }
}

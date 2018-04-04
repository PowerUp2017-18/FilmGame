using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TimerAndCounter : MonoBehaviour {

	public Text countText;
	public Text timerText;
	private int count;

	float timer = 60.0f;

	void Start () {
		
		count = 0;
		SetCountText ();
		timer = 60.0f;
	}
	
	void Update () {
		
		timer -= Time.deltaTime;
		if (timer <= 0) {
     	Application.LoadLevel ("EndScreen");
     	timerText.text = " " + Mathf.Round (timer);
     	}
	}
	
	void OnTriggerEnter (Collider other) {
        
        if (other.gameObject.CompareTag ("Prop")) {
            count = count + 1;
            SetCountText ();
        }
    	
    	Debug.Log (count);
    }
    
    void SetCountText () {
        
        countText.text = " " + count.ToString ();

        if (count >= 12) {
			Application.LoadLevel ("EndScreen");
		}
    }
}
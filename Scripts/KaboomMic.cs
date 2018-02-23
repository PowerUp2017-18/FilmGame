using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KaboomMic : MonoBehaviour {

	public float detectionRange;
	public float explodeRange;
	public float explodeTime;

	public bool detected = false;
	private bool inRange = false;
	private bool explode = false;
	private bool coroutineRun = false;

	public Transform player;
	
	void Update () {
		Detection();
	}

	public void Detection() {
		if(Vector3.Distance(player.position, transform.position) >= detectionRange) {
			detected = false;
			if(coroutineRun = true) {
				coroutineRun = false;
				StopCoroutine(Countdown());
			}
		} else if(Vector3.Distance(player.position, transform.position) <= detectionRange) {
			detected = true;
			StartCoroutine(Countdown());
		}
	}

	public void Explode() {
 		if(detected && Vector3.Distance(player.position, transform.position) <= explodeRange && explode == true) {
			Destroy(player.gameObject);
			Destroy(this.gameObject);
		}
	}

	IEnumerator Countdown() {
		coroutineRun = true;
        while (true) {
            yield return new WaitForSeconds (explodeTime);
            explode = true;
            Explode();
        }
    }
}

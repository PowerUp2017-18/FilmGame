using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueHolder : MonoBehaviour {

	public string dialogue;
	private DialogueManager dMan;

	public string[] dLines;

	void Start() {
		dMan = FindObjectOfType<DialogueManager>();
	}

	void Update() {

	}

	void OnTriggerStay2D(Collider2D other) {
		if(other.gameObject.name == "Player") {
			if(input.GetKeyUp(KeyCode.Space)) {
				//dMan.ShowBox(dialogue);
				if(!dMan.dActive) {
					dMan.dLines = dLines;
					dMan.currentLine = 0;
					dMan.ShowDialogue();
				}
			}
		}
	}
}

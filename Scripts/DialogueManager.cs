using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {
	
	public GameObject dBox;
	public Text dText;

	public bool dActive;

	public string[] dLines;
	public int currentLine;

	void Start() {

	}

	void Update() {
		if(dActive && Input.GetKeyDown(KeyCode.Space)) {

			currentLine++;
		}

		if(currentLine >= dLines.Length) {
			dBox.SetActive(false);
			dActive = false;

			currentLine = 0;
		}

		dText.text = dLines[currentLine];
	}

	public void ShowBox(string dialogue) {
		dActive = true;
		dBox.setActive(true);
		dText.text = dialouge;
	}

	public void ShowDialogue() {
		dActive = true;
		dBox.setActive(true);
	}
}

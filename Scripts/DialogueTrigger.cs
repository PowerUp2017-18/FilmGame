
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

	public Dialogue dialogue;

	public GameObject dBox;

	void Start() {
		dBox.SetActive(false);
	}

	public void TriggerDialogue ()
	{
		FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
	}

	void OnCollisionEnter2D(Collision2D col) {
		if(col.gameObject.name == "Player") {
			dBox.SetActive(true);
			TriggerDialogue();
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTextController : MonoBehaviour {
	TextMeshProUGUI text;

	void Awake() {
		text = GetComponent<TextMeshProUGUI>();
	}

	void Update() {
		text.text = "Score: " + ScoreManager.score;
	}
}
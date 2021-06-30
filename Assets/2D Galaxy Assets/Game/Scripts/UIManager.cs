using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	[SerializeField]
	private Sprite[] liveSprites;

	[SerializeField]
	private Image 
		titleScreen,
		livesDisplay;

	[SerializeField]
	private Text scoreText;
	
	private int playerScore = 0;

	void Start() {
		scoreText.text = "Score: " + playerScore;
	}

	public bool isTitleScreenDisplayed() {
		return titleScreen.IsActive();
	}

	public void showTitleScreen() {
		titleScreen.gameObject.active = true;
	}

	public void hideTitleScreen() {
		titleScreen.gameObject.active = false;
		playerScore = 0;
		scoreText.text = "Score: " + playerScore;
	}

	public void updateLives(int lifeCount) {
		livesDisplay.sprite = liveSprites[lifeCount];
	}

	public void updateScore() {
		playerScore += 2;
		scoreText.text = "Score: " + playerScore;
	}

}

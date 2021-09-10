using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
	public PlayerMovement player;
	public MinimapController minimap;
	
	public GameObject[] gameplayElements;
	public GameObject[] pages;
	
	public MusicController musicController;
	
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	// page 0 : gameplay, audio, video, resume, quit
	// page 1 : minimap pos, back
	// page 2 : music volume, sound effect volume, back
	// page 3 : FOV slider, brightness, back
	
	int mmMemory = 0;
	public void setGameplayElementsActive(bool setting){
		if (setting == false){
			mmMemory = minimap.modeIndex;
			minimap.SetMode(2);
		}
		else if (setting == true){
			minimap.SetMode(mmMemory);
		}
		for (int i=0; i<gameplayElements.Length; i++) gameplayElements[i].SetActive(setting);
	}
	
	public void showPage(int pageNumber){
		for (int i=0; i<pages.Length; i++){
			if (i==pageNumber) pages[i].SetActive(true);
			else pages[i].SetActive(false);
		}
	}
	
	int gameStateMemory;
	
	public void pause(){
		Cursor.lockState = CursorLockMode.Confined;
		Time.timeScale = 0;
		gameStateMemory = player.gameState;
		player.gameState = 1;
		setGameplayElementsActive(false);
		showPage(0);
		musicController.playTrack(0);
	}
	
	public void unpause(){
		Cursor.lockState = CursorLockMode.Locked;
		Time.timeScale = 1;
		player.gameState = gameStateMemory;
		setGameplayElementsActive(true);
		showPage(-1);
		musicController.fadeOut();
	}
	
	bool minimapPos = false;
	public RawImage minimapPosLabel;
	public Texture mmLeftLabel;
	public Texture mmRightLabel;
	
	public void ToggleMinimapPosition(){
		minimapPos = !minimapPos;
		if (!minimapPos){ minimapPosLabel.texture = mmLeftLabel; }
		else { minimapPosLabel.texture = mmRightLabel; }
		
		minimap.TogglePosition();
	}
}

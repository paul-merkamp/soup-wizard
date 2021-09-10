using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	
	public CharacterController controller;
	public MinimapController minimap;
	public PauseMenu pauseMenu;
	public DialogController dialogController;
	public CameraLerper lerper;
	public ReticuleManager reticule;
	
	public NPC currentNPC;
	
	public float speed = 100f;
	public float gravity = -9.81f;
	public float jumpPower = 10f;
	
	public float sprintMultiplier = 1.5f;
	
	float sprint = 1.0f;
	
	Vector3 velocity;
	
	// gameState tracker
	// 0 = playing
	// 1 = in menu
	public int gameState = 0;

    // Update is called once per frame
    void Update()
    {
		switch (gameState){
			case 0:
				if (Input.GetKeyDown("escape")){ pauseMenu.pause(); }
				
				// interact options
				if (Input.GetKeyDown("e")){
					if (currentNPC != null && currentNPC.canStartDialog){
						pauseMenu.setGameplayElementsActive(false);
						reticule.toggleReticuleVisible();
						dialogController.startDialog(currentNPC.inkJSON);
						lerper.focusNPC(currentNPC);
						gameState = 2;
					}
				}
				
				if (Input.GetKeyDown("m")){ minimap.AdvanceMode(); }
				
				if (Input.GetAxis("Sprint") == 1){ sprint = sprintMultiplier; }
				else { sprint = 1.0f; }
								
				float x = Input.GetAxis("Horizontal");
				float z = Input.GetAxis("Vertical");
				
				Vector3 movement = (transform.right * x) + (transform.forward * z);
				
				controller.Move(movement * speed * Time.deltaTime * sprint);
				
				if (Input.GetKeyDown("space")) velocity.y = jumpPower * Time.deltaTime;
				
				break;
			
			case 1:
				if (Input.GetKeyDown("escape")){ pauseMenu.unpause(); }
				
				break;
			
			case 2: // dialog
				if (Input.GetKeyDown("escape")){ pauseMenu.pause(); }
				
				if (Input.GetKeyDown("e")){
					if (dialogController.canProceed){
						if (!dialogController.story.canContinue) {
							pauseMenu.setGameplayElementsActive(true);
							reticule.toggleReticuleVisible();
							lerper.playerFocused = true;
							gameState = 0;
						}
						dialogController.advanceDialog();
					}
				}
				
				break;
			default:
				break;
		}
		
		// allow movement to resolve
		// code here instead of case 1 so player doesn't shoot into outer space
		velocity.y += gravity * Time.deltaTime;
				
		controller.Move(velocity * Time.deltaTime);
    }
	
	public void closeGame(){
		Application.Quit();
	}
}

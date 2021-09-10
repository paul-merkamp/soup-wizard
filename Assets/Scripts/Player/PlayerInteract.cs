using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
	public PlayerMovement movement;
	public Camera camera;
	
	public ReticuleManager reticule;
	
	public int distance;
	
	public LayerMask interactableMask;
	Sign sign;
	NPC npc;
	
    void FixedUpdate(){
		
		RaycastHit hit = new RaycastHit();
		Debug.DrawRay(camera.transform.position, camera.transform.forward, Color.green);
		
		if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, distance, interactableMask)){
			if (hit.transform.tag == "Sign"){	
				sign = hit.transform.gameObject.GetComponent<Sign>();
				sign.DisplayText();
			}
			else if (hit.transform.tag == "NPC"){
				npc = hit.transform.gameObject.GetComponent<NPC>();
				movement.currentNPC = npc;
				movement.currentNPC.canStartDialog = true;
				reticule.setReticule(1);
			}
		}
		else {
			if (sign != null) sign.HideText();
			if (npc != null) npc.canStartDialog = false;
			reticule.setReticule(0);
		}
	}
}

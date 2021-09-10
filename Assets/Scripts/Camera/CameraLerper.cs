using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLerper : MonoBehaviour
{
    
	public PlayerMovement player;
	public MouseLook mouseLook;
	Transform cameraTransform;
	public Vector3 targetPos;
	public Quaternion targetRot;
	public float cameraMoveSpeed = 4f;
	public float rotationFactor = 2f;
	
	public bool playerFocused = true;
	public bool handleRotation = false;
	
	void Start(){
		cameraTransform = gameObject.transform;
	}
	
	void Update(){
		if (playerFocused) { focusPlayer(); }
		if (targetPos != null){
			cameraTransform.position = Vector3.Lerp(cameraTransform.position, targetPos, cameraMoveSpeed * Time.deltaTime);
		}
		if (handleRotation){
			cameraTransform.rotation = Quaternion.Lerp(cameraTransform.rotation, targetRot, cameraMoveSpeed * Time.deltaTime/rotationFactor);
		}
	}
	
	public void focusNPC(NPC npc){
		playerFocused = false;
		targetPos = npc.dialogCameraPosition.transform.position;
		targetRot = npc.dialogCameraPosition.transform.rotation;
		handleRotation = true;
		mouseLook.disabled = true;
	}
	
	public void focusPlayer(){
		Vector3 pos = player.transform.position;
		targetPos = new Vector3(pos.x, pos.y+0.8f, pos.z);
		handleRotation = false;
		mouseLook.disabled = false;
	}
	
}

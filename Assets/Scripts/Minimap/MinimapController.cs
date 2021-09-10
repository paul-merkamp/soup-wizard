using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapController : MonoBehaviour
{
	public int modeIndex = 0;
	
	public GameObject globalMap;
	public GameObject localMap;
	
	public void AdvanceMode(){
		modeIndex++;
		if (modeIndex > 2){ modeIndex = 0; }
		else if (modeIndex < 0){ modeIndex = 2; }
		
		SetMode(modeIndex);
	}
	
	public void SetMode(int index){
		switch (index){
			case 0: // global map
				globalMap.SetActive(true);
				localMap.SetActive(false);
				break;
			case 1: // local map
				globalMap.SetActive(false);
				localMap.SetActive(true);
				break;
			case 2: // map disabled
				globalMap.SetActive(false);
				localMap.SetActive(false);
				break;
			default:
				break;
		}
	}
	
	public void TogglePosition(){
		Vector3 pos = globalMap.transform.localPosition;
		Vector3 newpos = new Vector3(pos.x*-1, pos.y, pos.z);
		globalMap.transform.localPosition = newpos;
		localMap.transform.localPosition = newpos;
	}
}

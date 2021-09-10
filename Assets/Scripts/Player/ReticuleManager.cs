using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReticuleManager : MonoBehaviour
{
	
	public RawImage image;
	public Texture[] reticules;
		
	/*
	
	0 : regular aim reticule
	1 : ? reticule for dialog
	
	*/
	
	public void setReticule(int index){
		image.texture = reticules[index];
	}
	
	public void toggleReticuleVisible(){
		image.enabled = !image.enabled;
	}
}

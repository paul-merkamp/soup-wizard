using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    
	public GameObject hud;
	public RawImage img_spoon;
	public RawImage img_att1, img_att2, img_att3;
	
	
	
	public void showEquipped(){
		hud.SetActive(true);
	}
	
	public void hideEquipped(){
		hud.SetActive(false);
	}
	
	
	
}

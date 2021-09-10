using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
	
	public string message;
	public Text textholder;
	
    public void DisplayText(){
		textholder.text = message;
		textholder.gameObject.SetActive(true);
	}
	
	public void HideText(){
		textholder.gameObject.SetActive(false);
	}
	
}

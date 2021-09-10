using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

public class DialogController : MonoBehaviour
{
	
	public Animator blackBarAnimator;
	
	public Story story;
	public TextAsset inkJSON;
	public InputField dialogueBox;
	public string currentText = "";
	public float textSpeed = 0.05f;
	
	public bool canProceed = false;
	
    // Start is called before the first frame update
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void startDialog(TextAsset ink){
		inkJSON = ink;
		story = new Story(inkJSON.text);
		if (!story.canContinue) story.ResetState();
		blackBarAnimator.SetBool("bars_on", true);
	}
	
	public void advanceDialog(){
		if (!story.canContinue) { endDialog(); }
		else {
			dialogueBox.text = "";
			currentText = story.Continue();
			StartCoroutine(BuildText());
		}
	}
	
	public void endDialog(){
		blackBarAnimator.SetBool("bars_on", false);
		canProceed = false;
	}
	
	private IEnumerator BuildText(){
		canProceed = false;
		for (int i = 0; i < currentText.Length; i++){
			dialogueBox.text = string.Concat(dialogueBox.text, currentText[i]);
			if (i==(currentText.Length-1)){
				canProceed = true;
			}
			yield return new WaitForSeconds(textSpeed);
		}
	}
}

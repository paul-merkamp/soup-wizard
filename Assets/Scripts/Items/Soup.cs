using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soup : MonoBehaviour
{
	
	public static int ingredientsSize = 5;
	public Ingredient[] ingredients = new Ingredient[ingredientsSize];
	public Color color;
	
	public int remainingSoup = 3;
	
    // Start is called before the first frame update
    void Start(){
        updateColor();
    }
	
	void Update(){
		updateRemaining();
	}
	
	// iterate through ingredients and generate the new color
	void updateColor(){
		foreach (Ingredient i in ingredients){ color += i.color; }
		color /= ingredients.Length;
		
		Material m = new Material(Shader.Find("Transparent/Diffuse"));
		m.color = color;
		gameObject.GetComponent<MeshRenderer>().material = m;
	}
	
	void updateRemaining(){
		Vector3 center = gameObject.transform.parent.gameObject.transform.position;
		Vector3 oldScale = gameObject.transform.localScale;
		switch (remainingSoup){
			case 3:
				gameObject.transform.position = new Vector3(center.x, center.y+0.349f, center.z);
				gameObject.transform.localScale = new Vector3(1.1f, oldScale.y, 1);
				break;
			case 2:
				gameObject.transform.position = new Vector3(center.x, center.y+0.255f, center.z);
				gameObject.transform.localScale = new Vector3(1, oldScale.y, 1);
				break;
			case 1:
				gameObject.transform.position = new Vector3(center.x, center.y+0.146f, center.z);
				gameObject.transform.localScale = new Vector3(0.8f, oldScale.y, 0.85f);
				break;
			case 0:
				gameObject.transform.position = new Vector3(center.x, center.y-100, center.z);
				gameObject.transform.localScale = new Vector3(0.8f, oldScale.y, 0.7f);
				break;
		}
	}
}

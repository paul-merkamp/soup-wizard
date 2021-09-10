using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FOV_Manager : MonoBehaviour
{
	Camera camera;
	public Slider fovSlider;
	
	public int minFOV = 50;
	public int maxFOV = 120;
	
    // Start is called before the first frame update
    void Start()
    {
        camera = this.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        camera.fieldOfView = ((maxFOV - minFOV) * fovSlider.value) + minFOV;
    }
}

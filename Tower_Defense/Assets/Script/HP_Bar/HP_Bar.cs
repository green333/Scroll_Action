using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class HP_Bar : MonoBehaviour {

    [SerializeField]
    private Slider hp_slider;

    [SerializeField]
    private float hp;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        hp_slider.value = hp;
    }


}

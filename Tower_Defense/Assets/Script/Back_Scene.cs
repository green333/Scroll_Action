using UnityEngine;
using System.Collections;

public class Back_Scene : Scene {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	


	}

    public void OnClick()
    {
        Char_Button.char_num = 0;
        Char_Button.char_select = 0;

        ChangeScene(filename);
    }
}

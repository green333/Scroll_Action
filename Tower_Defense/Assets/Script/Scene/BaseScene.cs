using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BaseScene : MonoBehaviour {

    [SerializeField]
    protected string filename;

    //------------------------------------

    //  初期化

    //------------------------------------
    void Start () {
	
	}

    //------------------------------------

    //  更新

    //------------------------------------
    void Update () {
	
	}


    protected void ChangeScene(string name)
    {
        if (string.IsNullOrEmpty(name)) return;

        SceneManager.LoadScene(name);

    }

}

using UnityEngine;
using System.Collections;

public class Home : MonoBehaviour {

    [SerializeField]
    private GameObject[] players;

    //---------------------------------------

    //  初期化

    //---------------------------------------
    void Start () {
	
	}

    //---------------------------------------

    //  更新

    //---------------------------------------
    void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Create_Character();
        }
	}



    void Create_Character()
    {
        Instantiate(players[0], transform.position, Quaternion.identity);
    }
}

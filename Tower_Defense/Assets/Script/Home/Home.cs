using UnityEngine;
using System.Collections;

public class Home : MonoBehaviour {

    //[SerializeField]
    //private GameObject[] players;

    enum Character      //キャラクター
    {
        NORMAL = 0,     //普通キャラ
        SPEED,          //スピード系
        JUMP,    
    }

    


    //---------------------------------------

    //  初期化

    //---------------------------------------
    void Start () {
	
	}

    //---------------------------------------

    //  更新

    //---------------------------------------
    void Update () {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    Create_Character();
        //}
	}



    //---------------------------------------

    //  キャラクター生成

    //---------------------------------------
    void Create_Character()
    {
        //Instantiate(players[0], new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z), Quaternion.identity);
    }
}

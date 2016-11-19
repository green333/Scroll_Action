using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

    [SerializeField]
    private GameObject[] players;    //仲間

    //ビット演算用
    protected enum PLAYER
    {
        NONE = 0x00,
        NORMAL = 0x01,       //普通             1
        SPEEDER = 0x02,       //スピード重視     2
        WEIGHTER = 0x04,       //重さ重視         3
        JUMPER = 0x08,       //ジャンプ力       4
        SHORTER = 0x10,       //近距離           5
        LONGER = 0x40,       //遠距離           6
    }

    //配列
    protected enum ABILITY
    {
        NORMAL = 0,            //普通           
        SPEEDER,               //スピード重視   
        WEIGHTER,              //重さ重視       
        JUMPER,                //ジャンプ力     
        SHORTER,               //近距離         
        LONGER,                //遠距離         
    }


    //------------------------------------------

    //  初期化

    //------------------------------------------
    void Start() {
        Debug.Log("現在のキャラ数:" + Char_Button.char_num);

        Player_Create();


        //switch (Char_Button.char_select)
        //{
        //    case (int)PLAYER.NORMAL:
        //        Instantiate(players[(int)PLAYER.NORMAL], new Vector3(0, 1.5f, 0), Quaternion.identity);
        //        break;

        //    case (int)PLAYER.SPEEDER:
        //        Instantiate(players[(int)PLAYER.SPEEDER], new Vector3(0, 1.5f, 0), Quaternion.identity);
        //        break;

        //    case (int)PLAYER.WEIGHTER:
        //        Instantiate(players[(int)PLAYER.WEIGHTER], new Vector3(0, 1.5f, 0), Quaternion.identity);
        //        break;

        //    case (int)PLAYER.JUMPER:
        //        Instantiate(players[(int)PLAYER.LONGER], new Vector3(0, 1.5f, 0), Quaternion.identity);
        //        break;

        //    case (int)PLAYER.SHORTER:
        //        Instantiate(players[(int)PLAYER.SHORTER], new Vector3(0, 1.5f, 0), Quaternion.identity);
        //        break;

        //    case (int)PLAYER.LONGER:
        //        Instantiate(players[(int)PLAYER.LONGER], new Vector3(0, 1.5f, 0), Quaternion.identity);
        //        break;
        //}


    }

    void Player_Create()
    {
        if ((Char_Button.char_select & (int)PLAYER.NORMAL) != 0) {
            Set_Character(ABILITY.NORMAL);
            Debug.Log("normal");
        }

        if ((Char_Button.char_select & (int)PLAYER.SPEEDER) != 0) {
            Set_Character(ABILITY.SPEEDER);
            Debug.Log("speed");
        }

        if ((Char_Button.char_select & (int)PLAYER.WEIGHTER) != 0)
        {
            Set_Character(ABILITY.WEIGHTER);
            Debug.Log("weight");
        }

        if ((Char_Button.char_select & (int)PLAYER.JUMPER) != 0)
        {
            Set_Character(ABILITY.JUMPER);
            Debug.Log("jump");
        }

        if ((Char_Button.char_select & (int)PLAYER.SHORTER) != 0)
        {
            Set_Character(ABILITY.SHORTER);
            Debug.Log("short");
        }

    }


    void Set_Character(ABILITY ability)
    {
        Instantiate(players[(int)ability], new Vector3(0, 1.5f, 0), Quaternion.identity);
    }


    //------------------------------------------

    //  更新

    //------------------------------------------
    void Update () {
	


	}
}

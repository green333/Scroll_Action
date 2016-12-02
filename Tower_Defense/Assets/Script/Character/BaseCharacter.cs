using UnityEngine;
using System.Collections;



[System.Serializable]
class Status
{
    public int hp = 0;        //体力
    public int attack = 0;    //攻撃
    public int defense = 0;   //防御
    public float spd = 0.0f;     //速度
}


public class BaseCharacter : MonoBehaviour {


    //-----------------------
    //  プレイヤーの状態
    //-----------------------
    protected enum P_State
    {
        MOVE = 0,                 //操作する
        ATTACK,                   //攻撃する
        DAMAGE,                   //ダメージ
        DEAD,                     //死亡
    }


    //-----------------------------

    //  初期化

    //-----------------------------
    void Start () {
	
	}


    //-----------------------------

    //  更新

    //-----------------------------
    void Update () {
	
	}
}

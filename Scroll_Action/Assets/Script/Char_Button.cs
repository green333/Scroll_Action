using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class Char_Button : MonoBehaviour {

    [SerializeField]
    private bool clickflg;             //選択されたどうか

    [SerializeField]
    private int own_number;            //キャラ自身の番号

    public static int char_select;     //何体選択されてるか（ビット）

    public static int char_num = 0;    //現在の選択しているキャラ数

    [SerializeField]
    private Image image;       //画像コンポーネント

    [SerializeField]
    private Sprite normal;     //通常時の画像

    [SerializeField]
    private Sprite choice;     //選択中の画像

//    [SerializeField]
//    private GameObject character;

//    private GameObject instance;     //生成

    //-------------------------
    
    //  初期化

    //-------------------------
    void Start () {

    }





    //-------------------------

    //  更新

    //-------------------------
    void Update () {

        if (clickflg)
        {
            image.sprite = choice;    //選択中状態
        }
        else
        {
            image.sprite = normal;    //選択されてない状態
        }
    }


    //-----------------------------------------------

    //  クリックされた時の処理

    //-----------------------------------------------
    public void OnClick()
    {
        clickflg = !clickflg;


        if (clickflg)
        {
            char_select |= own_number;    //フラグ立てる
            char_num++;

            //instance = (GameObject)Instantiate(character, new Vector3(0, 1.5f, 0), Quaternion.identity);

        }
        else
        {
            char_select ^= own_number;    //フラグ降ろす
            char_num--;

            //Destroy(instance);

        }
        Debug.Log("現在のビット:" + char_select);

        Debug.Log("キャラ数:" + char_num);

    }
}

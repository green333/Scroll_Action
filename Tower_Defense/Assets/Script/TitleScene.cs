using UnityEngine;
using System.Collections;

using UnityEngine.UI;


[System.Serializable]
class RGB_Color
{
    public float red;      //赤色

    public float green;    //緑色

    public float blue;     //青色

    public float alpha;    //不透明度
}


public class TitleScene : Scene {

    [SerializeField]
    private Image title_logo;

    [SerializeField]
    private RGB_Color color;

    enum Title     //タイトルの状態遷移
    {
        WAIT = 0,           //キー入力待ち
        TITLE_PRODUCTION,   //タイトルの演出
        NEXT_SCENE,         //次シーンへ
    }


    [SerializeField]
    private Title transition;   //状態遷移

    //--------------------------

    //  初期化

    //--------------------------
    void Start () {
	    
	}


    //--------------------------

    //  更新

    //--------------------------
    void Update () {

        switch (transition)
        {
            case Title.WAIT:
                Wait_Input();                 //入力待ち
                break;

            case Title.TITLE_PRODUCTION:      //タイトル演出
                Title_Production();
                break;

            case Title.NEXT_SCENE:
                ChangeScene(filename);        //次のシーンへ
                break;
        }
	}



    //--------------------------

    //  キー入力待ち

    //--------------------------
    void Wait_Input()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transition = Title.TITLE_PRODUCTION;
        }
    }



    //--------------------------

    //  タイトル演出

    //--------------------------
    void Title_Production()
    {

        title_logo.color = new Color(color.red, color.green, color.blue, color.alpha);

        color.alpha -= 0.01f;
        


        if(color.alpha < 0)
        {
            transition = Title.NEXT_SCENE;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using UnityEngine.UI;
using WeChatWASM;
using System.Reflection;
using System;

public class Init : MonoBehaviour
{
    // Start is called before the first frame update
    public Text text;
    int count = 0;
    Font saveFont;

    //public TMP_Text tmpText;
    void Start()
    {
        WeChatWASM.WX.InitSDK((ret) =>
        {
            // fallbackFont作为旧版本微信或者无法获得系统字体文件时的备选CDN URL
            // 「注意」需要替换成游戏真实的字体URL！！
            //var fallbackFont = Application.streamingAssetsPath + "fallback.ttf";
#if !UNITY_EDITOR
            
#endif
        });

    }


    public void ChangeFont()
    {
        Debug.Log("change font");
        if(count == 0)
        {
            WeChatWASM.WX.GetWXFont("", (font) =>
            {
                Debug.Log("get wx font success");
                text.font = font;
                text.text = "load wx font";
                saveFont = font;
                count++;

            });
        }

        if(count >= 1)
        {
            TMP_FontAsset.CreateFontAsset(saveFont);
            text.text = "load wx tmp font";

        }

    }
}

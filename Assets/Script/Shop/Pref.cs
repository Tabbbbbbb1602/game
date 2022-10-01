using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pref
{
    // Start is called before the first frame update
    void Start()
    {
        //set and get data  save on device user
        /* PlayerPrefs.SetInt("score", 10);
         PlayerPrefs.GetInt("score");*/
    }

    //Lay play hien tai tren may nguoi dung
    public static int CurPlayerId
    {
        set => PlayerPrefs.SetInt(PrefConst.CUR_PLAYER_ID, value);
        get => PlayerPrefs.GetInt(PrefConst.CUR_PLAYER_ID);
    }

    //Lay coins tren may nguoi dung
    public static int Coins
    {
        set => PlayerPrefs.SetInt(PrefConst.COIN_KEY, value);
        get => PlayerPrefs.GetInt(PrefConst.COIN_KEY);
    }

    //thực hiện get và set bool giá trị của pref
    public static void SetBool(string key, bool isOn)
    {
        if (isOn)
        {
            PlayerPrefs.SetInt(key, 1);
        }
        else
        {
            PlayerPrefs.SetInt(key, 0);
        }
    }

    public static bool GetBool(string key)
    {
        return PlayerPrefs.GetInt(key) == 1 ? true : false;
        /* if(PlayerPrefs.GetInt(key) == 1)
         {
             return true;
         }
         else
         {
             return false;
         }*/
    }

}

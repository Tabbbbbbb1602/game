using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : Singleton<ShopManager>
{
    public ShopITem[] items;

    private void Start()
    {
        if (items == null || items.Length <= 0) return;

        for (int i = 0; i < items.Length; i++)
        {
            var item = items[i];
            if (item != null)
            {
                if (i == 0)
                {
                    Pref.SetBool(PrefConst.PLAYER_PEFIX + i, true);//player_0
                }
                else
                {
                    //player_1, player_2 .....
                    if (!PlayerPrefs.HasKey(PrefConst.PLAYER_PEFIX + i))
                    {
                        Pref.SetBool(PrefConst.PLAYER_PEFIX + i, false);
                    }
                }
            }
        }
    }
}

[System.Serializable]
public class ShopITem
{
    public int price;
    public Sprite hub;
    public Player playerPb;
}

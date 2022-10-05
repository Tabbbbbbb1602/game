using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    Player m_player;

    public override void Awake()
    {
        MakeSingleton(false);
    }

    public override void Start()
    {
        base.Start();

        if (!PlayerPrefs.HasKey(PrefConst.COIN_KEY))
            Pref.Coins = 10000;

        ActivePlayer();
        GUIManager.Ins.UpdateCoins();
    }

    public void ActivePlayer()
    {
        if (m_player)
            Destroy(m_player.gameObject);

        var newPlayerPrefab = ShopManager.Ins.items[Pref.CurPlayerId].playerPb;

        if (newPlayerPrefab)
        {
            m_player = Instantiate(newPlayerPrefab, new Vector3(-0.4f, 3.5f, 60.0f), Quaternion.Euler(new Vector3(0.0f, 210.0f, 0.0f)));
        }

    }
}

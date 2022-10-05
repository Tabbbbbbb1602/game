using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : Singleton<GUIManager>
{
    public Text coinCountingText;

    public override void Awake()
    {
        MakeSingleton(false);
    }

    private void Start()
    {
        coinCountingText.text = "" + Pref.Coins;
    }

    public void UpdateCoins()
    {
        if (coinCountingText)
            coinCountingText.text = "" + Pref.Coins;
    }
}

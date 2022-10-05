using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabControl : MonoBehaviour
{
    public GameObject CharacterButton;
    public GameObject BallButton;

    public GameObject BallContent;
    public GameObject CharacterContent;

    // Start is called before the first frame update
    void Start()
    {
        ShowCharacter();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HideAllTabs()
    {
        BallContent.SetActive(false);
        CharacterContent.SetActive(false);

        CharacterButton.GetComponent<Button>().image.color = new Color32(212, 212, 212, 255);
        BallButton.GetComponent<Button>().image.color = new Color32(212, 212, 212, 255);
    }

    public void ShowCharacter()
    {
        HideAllTabs();
        CharacterContent.SetActive(true);
        CharacterButton.GetComponent<Button>().image.color = new Color32(255, 255, 255, 255);
    }

    public void ShowBall()
    {
        HideAllTabs();
        BallContent.SetActive(true);
        BallButton.GetComponent<Button>().image.color = new Color32(255, 255, 255, 255);
    }
}

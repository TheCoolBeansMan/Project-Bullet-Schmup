using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public GameObject textbox;
    public GameObject player;

    public Text speakerText;
    public Text dialogueText;
    public Image portraitImage;

    public string[] speaker;
    [TextArea]
    public string[] words;
    public Sprite[] portrait;

    public bool activated = false;

    private int step = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && activated == true)
        {
            player.GetComponent<PlayerControl>().shootingEnabled = false;
            textbox.SetActive(true);
            speakerText.text = speaker[step];
            dialogueText.text = words[step];
            portraitImage.sprite = portrait[step];
            step++;
            if (step >= speaker.Length)
            {
                textbox.SetActive(false);
                player.GetComponent<PlayerControl>().shootingEnabled = true;
                activated = false;
            }
        }
    }
}

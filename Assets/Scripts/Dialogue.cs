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

    public bool isOver;

    private int step = 1;

    private void Start()
    {
        speakerText.text = speaker[0];
        dialogueText.text = words[0];
        portraitImage.sprite = portrait[0];
    }

    public void BeginDialogue()
    {
        isOver = false;
        player.GetComponent<PlayerControl>().shootingEnabled = false;
        textbox.SetActive(true);
        if (Input.GetKeyDown(KeyCode.Z))
        {
            speakerText.text = speaker[step];
            dialogueText.text = words[step];
            portraitImage.sprite = portrait[step];
            step++;
            if (step >= speaker.Length)
                isOver = true;
        }
        player.GetComponent<PlayerControl>().shootingEnabled = true;
        textbox.SetActive(false);
    }
}

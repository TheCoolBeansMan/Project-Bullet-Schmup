using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public GameObject textbox;
    public GameObject stageManager;

    public Text speakerText;
    public Text dialogueText;
    public Image portraitImage;

    public string[] speaker;
    [TextArea]
    public string[] words;
    public Sprite[] portrait;

    public int totalDialogue;

    public bool activated = false;

    private int step = 1;

    private void Start()
    {
        speakerText.text = speaker[0];
        dialogueText.text = words[0];
        portraitImage.sprite = portrait[0];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && activated == true)
        {
            if (step >= totalDialogue)
            {
                textbox.SetActive(false);
                activated = false;
                stageManager.GetComponent<Stage1Manager>().dialogueOver = true;
            }
            speakerText.text = speaker[step];
            dialogueText.text = words[step];
            portraitImage.sprite = portrait[step];
            step++;
        }
    }
}

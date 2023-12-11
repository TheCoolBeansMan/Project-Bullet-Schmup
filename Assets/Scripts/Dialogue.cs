using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public GameObject dialogueCanvas;
    public GameObject nextStage;

    public Text speakerText;
    public Text dialogueText;
    public Image portraitImage;

    public string[] speaker;
    [TextArea]
    public string[] diaolgue;
    public Sprite[] portrait;

    public bool dialogueActivated;
    private int step;

    private void Start()
    {
        if (dialogueActivated ==  true)
        {
            dialogueCanvas.SetActive(true);
        }
    }

    private void Update()
    {
        if (dialogueActivated == true)
        {
            dialogueCanvas.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Z) && dialogueActivated == true)
        {
            if (step >= speaker.Length)
            {
                Destroy(dialogueCanvas);
                nextStage.SetActive(true);
                Destroy(this.gameObject);
            }
            dialogueCanvas.SetActive(true);
            speakerText.text = speaker[step];
            dialogueText.text = diaolgue[step];
            portraitImage.sprite = portrait[step];
            step++;
        }
    }
}

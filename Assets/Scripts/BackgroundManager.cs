using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] private RawImage background;
    [SerializeField] private float x;
    [SerializeField] private float y;

    private void Update()
    {
        background.uvRect = new Rect(background.uvRect.position + new Vector2(x, y) * Time.deltaTime, background.uvRect.size);
    }
}

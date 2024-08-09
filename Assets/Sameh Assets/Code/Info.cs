using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Info : MonoBehaviour
{
    public GameObject InfoScreen;
    public Button InfoButton;
    public Text MessUI;
    public static bool paused;
    public Text InfUI;

    void Start()
    {
        paused = false;
        InfoScreen.SetActive(false);
    }

    void Update()
    {

    }

    public void Pause()
    {
        if (IsMouseOverButton())
        {
            InfoScreen.SetActive(true);
            paused = true;
            Time.timeScale = 0;
            InfUI.color = Color.white;
        }
    }

    public void Resume()
    {
        InfoScreen.SetActive(false);
        paused = false;
        Time.timeScale = 1;
        MessUI.color = Color.white;
    }

    bool IsMouseOverButton()
    {
        RectTransform rectTransform = InfoButton.GetComponent<RectTransform>();
        Vector2 mousePosition = Input.mousePosition;

        Vector2 localMousePosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, mousePosition, null, out localMousePosition);

        return rectTransform.rect.Contains(localMousePosition);
    }
}

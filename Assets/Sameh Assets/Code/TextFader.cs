using UnityEngine;
using UnityEngine.UI;

public class TextFader : MonoBehaviour
{
    public float fadeDuration = 2.0f;
    public Text Title;
    private float currentAlpha;
    private float targetAlpha = 0.8431373f;
    private float timeElapsed = 0f;

    void Start()
    {
        currentAlpha = Title.color.a;

        Title.color = new Color(Title.color.r, Title.color.g, Title.color.b, 0.0f);
    }

    void Update()
    {
        timeElapsed += Time.deltaTime;

        float t = timeElapsed / fadeDuration;
        float alpha = Mathf.Lerp(currentAlpha, targetAlpha, t);

        Title.color = new Color(Title.color.r, Title.color.g, Title.color.b, alpha);

        if (t >= 1.0f)
        {
            timeElapsed = 0f;
            currentAlpha = targetAlpha;
        }
    }
}
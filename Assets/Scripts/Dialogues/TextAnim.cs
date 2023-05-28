using UnityEngine;
using TMPro;

public class TextAnim : MonoBehaviour
{
    public float typingSpeed = 0.1f;
    public string fullText = "Hello, World!";
    private string currentText = "";

    private TextMeshProUGUI textMeshPro;

    private float timer;
    private int currentIndex;

    private void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        currentText = "";

        timer = 0f;
        currentIndex = 0;
    }

    private void Update()
    {
        if (currentIndex < fullText.Length)
        {
            timer += Time.deltaTime;

            if (timer >= typingSpeed)
            {
                timer = 0f;
                currentText += fullText[currentIndex];
                currentIndex++;

                textMeshPro.text = currentText;
            }
        }
    }
}

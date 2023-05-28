using TMPro;
using UnityEngine;

public class TextInstantiate : MonoBehaviour
{
    public GameObject textMeshBoxPrefab;
    public string textToDisplay = "Hello, World!";

    void Start()
    {
        // Instantiate the Text Mesh Box prefab
        GameObject newTextMeshBox = Instantiate(textMeshBoxPrefab, transform.position, Quaternion.identity);

        // Set the parent of the instantiated object
        newTextMeshBox.transform.SetParent(transform);

        // Get the TextMeshProUGUI component from the instantiated prefab
        TextMeshProUGUI textMeshPro = newTextMeshBox.GetComponentInChildren<TextMeshProUGUI>();

        // Set the text to display in the TextMeshProUGUI component
        textMeshPro.text = textToDisplay;
    }
}

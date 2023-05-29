using UnityEngine;

public class ShowText : MonoBehaviour
{

    [SerializeField] private GameObject text;
    [SerializeField] private string[] lines;

    void OnTriggerEnter2D(Collider2D other)
    {
        text.SetActive(true);
        var dialog = text.GetComponent<Dialog>();
        dialog.lines = lines;
        dialog.Start();

    }

    void OnTriggerExit2D(Collider2D other)
    {
        text.SetActive(false);
    }
}

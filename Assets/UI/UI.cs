using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Ui : MonoBehaviour
{
    private void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        var buttonStart = root.Q<Button>("Start");
        buttonStart.clicked += () =>
        {
            Debug.Log("Start button clicked");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        };
    }
}

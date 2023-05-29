using UnityEngine;
using TMPro;
using System.Collections;

public class Dialog : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textComponent;
    [SerializeField] public string[] lines;
    [SerializeField] private float textSpeed;
    private int _currentLine = 0;

    // Start is called before the first frame update
    public void Start()
    {
        Debug.Log("Dialog Start");
        textComponent.text = string.Empty;
        StartDialog();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[_currentLine])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[_currentLine];
            }
        }
    }

    private void StartDialog()
    {
        _currentLine = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (var letter in lines[_currentLine].ToCharArray())
        {
            textComponent.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (_currentLine < lines.Length - 1)
        {
            _currentLine++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            textComponent.text = string.Empty;
            gameObject.SetActive(false);
        }
    }
}

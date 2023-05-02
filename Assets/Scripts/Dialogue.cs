using System.Collections;
using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;

    [TextArea(3, 10)]
    public string[] lines;
    public float textSpeed;

    private int index;

    public TextMeshProUGUI Yes;
    public TextMeshProUGUI No;
    public TextMeshProUGUI goBackBtn;

    void Start()
    {
        textComponent.text = string.Empty;
        textComponent.fontSize = 20;
        StartDialogue();

        No.gameObject.SetActive(false);
        Yes.gameObject.SetActive(false);
        goBackBtn.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                if (textComponent != null)
                {
                    textComponent.text = lines[index];
                }
            }

        }
    }

    private void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    private IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            if (textComponent != null)
            {
                textComponent.text += c;
            }
            yield return new WaitForSeconds(textSpeed);
        }
    }

    private void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            if (textComponent != null)
            {
                textComponent.text = string.Empty;
            }
            StartCoroutine(TypeLine());
        }
        else
        {
            No.gameObject.SetActive(true);
            Yes.gameObject.SetActive(true);
            goBackBtn.gameObject.SetActive(true);
            gameObject.SetActive(false);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
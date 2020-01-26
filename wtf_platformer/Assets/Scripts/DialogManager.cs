using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    private Queue<string> sentences;
    public GameObject DialogH;
    Text dialodText;
    void Start()
    {
        sentences = new Queue<string>();
        dialodText = DialogH.GetComponentInChildren<Text>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1")) DisplayNextSentence();
    }

    public void StartDialog(Dialog dialog)
    {
        sentences.Clear();
        if (!DialogH.activeInHierarchy) { DialogH.SetActive(true); }
        foreach (string sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialog();
            return;
        }
        string sentence = sentences.Dequeue();
        Debug.Log(sentence);
        dialodText.text = sentence;
    }

    public void EndDialog()
    {
        DialogH.SetActive(false);
    }
}

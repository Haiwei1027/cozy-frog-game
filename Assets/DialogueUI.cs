using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    public TMP_Text speakerLabel;
    public TMP_Text messageLabel;

    private static DialogueUI instance;

    private void Awake()
    {
        if (instance != null) { Debug.LogError("Multiple Dialogue UI", gameObject); Destroy(this); }
        instance = this;
    }

    void DisplayMessage()
    {

    }

    int DisplayChoice()
    {
        return 0;
    }

    public static void End()
    {
        instance.gameObject.SetActive(false);
    }

    public static void Start(Dialogue dialogue)
    {
        instance.gameObject.SetActive(true);
        dialogue.Proceed();
    }
}

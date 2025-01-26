using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeMessage : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    [SerializeField] string[] messages;

    // Start is called before the first frame update
    void Start()
    {
        // Get random indexes in messages
        int messagesIndex = Random.Range(0, messages.Length); 
        text.text = messages[messagesIndex];
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chat_Event : MonoBehaviour
{
    [SerializeField] private string[] Chatname;
    [SerializeField] [TextArea] private string[] Messages;
    [SerializeField] private GameObject[] chatimages;
    [SerializeField] private Text ChatnameText;
    [SerializeField] private Text ChatText;

    public void Image_In(int index)
    {
        chatimages[index].SetActive(true);
    }

    public void Image_Out(int index)
    {
        chatimages[index].SetActive(false);
    }

    public void Chatname_Out(int index)
    {
        ChatnameText.text = Chatname[index];
    }

    public void Messages_Out(int index)
    {
        ChatText.text = Messages[index];
    }
}

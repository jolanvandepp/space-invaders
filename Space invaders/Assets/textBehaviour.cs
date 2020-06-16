using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class textBehaviour : MonoBehaviour
{
    private Text thisText;

    public String inputText = "";
    public String previousText = "";

    public ClientSocket ClientSocket;

    // Start is called before the first frame updateS
    void Start()
    {
        thisText.text = "This text must change once connection is established";

        ClientSocket = GameObject.Find("Network").GetComponent(typeof(ClientSocket)) as ClientSocket;
    }

    // Update is called once per frame
    void Update()
    {
        if(NewInput){
            updateText();
        }
    }

    private bool NewInput
    {
        get
        {
            inputText = ClientSocket.getMessage();

            if (inputText != previousText)
            {
                previousText = inputText;
                return true;
            }

            return false;
        }
    }

    private void updateText(){  
        thisText.text = inputText;;
    }
}

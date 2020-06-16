﻿using System.Collections;
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

    public bool textUpdate = false;

    public ClientSocket ClientSocket;

    // Start is called before the first frame updateS
    void Start()
    {
        thisText = GetComponent <Text> ();
        thisText.text = "This text must change once connection is established";

        ClientSocket = GetComponent <ClientSocket> ();
    }

    // Update is called once per frame
    void Update()
    {
        if(textUpdate)
        {
            updateText();
            GetNewInput();
        }
    }

    private void GetNewInput()
    {
        inputText = ClientSocket.getMessage();

        if (inputText != previousText)
        {
            previousText = inputText;
            textUpdate = true;
        }

        textUpdate = false;
    }

    private void updateText(){  
        thisText.text = inputText;;
    }
}

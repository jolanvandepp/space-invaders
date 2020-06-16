using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class testText : MonoBehaviour
{
    private Text thisText;

    // Start is called before the first frame update
    void Start()
    {
        thisText = GetComponent <Text> ();
        thisText.text = "wadup";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

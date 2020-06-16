using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Net.Sockets; 

public class ClientSocket : MonoBehaviour
{
    bool socketReady = false;
    TcpClient mySocket;
    public NetworkStream theStream;
    StreamWriter theWriter;
    StreamReader theReader;
    public String Host = "INSERT the public IP of router or Local IP of Arduino";
    public Int32 Port = 5001; 
    public bool lightStatus;

    // Start is called before the first frame update
    void Start()
    {
        setupSocket ();
    }

    // Update is called once per frame
    void Update()
    {
        while (theStream.DataAvailable){
            string recievedData = readSocket();
        }
    }

    public void setupSocket(){
        try {                
            mySocket = new TcpClient(Host, Port);
            theStream = mySocket.GetStream();
            theWriter = new StreamWriter(theStream);
            theReader = new StreamReader(theStream);
            socketReady = true;
        }
        catch (Exception e) {
            Debug.Log("Socket error:" + e);
        }
    }

    public void writeSocket(string theLine) {
        if (!socketReady)
            return;
        String tmpString = theLine;
        theWriter.Write(tmpString);
        theWriter.Flush();
    }

    public String readSocket() {
        if (!socketReady)
            return "";
        if (theStream.DataAvailable)
            return theReader.ReadLine();
        return "NoData";
    }

    public void closeSocket() {
        if (!socketReady)
            return;
        theWriter.Close();
        theReader.Close();
        mySocket.Close();
        socketReady = false;
    }
}

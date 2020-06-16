using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class ClientSocket : MonoBehaviour
{
    private TcpClient socketConnection;
    private Thread recievingThread;
    private String Host = "192.168.4.50";
    private Int32 Port = 64000;

    public String message = "";

    // Start is called before the first frame update
    void Start()
    {
        establishConnection();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void establishConnection(){
        try{
            recievingThread = new Thread (new ThreadStart(ListenForData));
            recievingThread.IsBackground = true;
            recievingThread.Start();
        }
        catch(Exception e){
            Debug.Log("On client connect exception " + e);
        }
    }

    public String getMessage(){
        return message;
    }

    public void ListenForData(){
        try{
            socketConnection = new TcpClient(Host, Port);
            System.Net.IPAddress ipAddress = System.Net.IPAddress.Parse("192.168.4.50");
            socketConnection.Connect(Host, Port);
            Byte[] bytes = new Byte[1024];
            while(true){
                using (NetworkStream stream = socketConnection.GetStream()){
                    int length; 
                    while ((length = stream.Read(bytes, 0, bytes.Length)) != 0){
                        var incommingData = new byte[length];
                        Array.Copy(bytes, 0, incommingData, 0, length);
                        string serverMessage = Encoding.ASCII.GetString(incommingData);
                        message = serverMessage;
                        Debug.Log(message);
                    }
                }
            }
        }
        catch(SocketException socketException){
            message = socketException.ToString();
            Debug.Log("Socket exception: " + socketException);
        }
    }

    
}

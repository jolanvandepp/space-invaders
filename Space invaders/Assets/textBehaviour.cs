using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textBehaviour : MonoBehaviour
{
    public Text thisText;
    private int counter = 0;
    private bool newInputRecieved = false;

    // Start is called before the first frame update
    void Start()
    {
        thisText.text = "This text must change once connection is established";
    }

    // Update is called once per frame
    void Update()
    {
        if(getNewInput()){
            updateText();
        }
    }

    private bool getNewInput(){

        return false;
    }

    private void updateText(){  
        counter++;
        thisText.text = "this text has recieved new input :" + counter;
    }
}

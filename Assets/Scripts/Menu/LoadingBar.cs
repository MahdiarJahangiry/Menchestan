using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LoadingBar : MonoBehaviour
{

    public Text loadingText;
    public int counter = 4;
    private void Start()
    {
        loadingText = GetComponent<Text>();
        InvokeRepeating("StartCounting",0.5f,0.5f);
    }

    private void Update()
    {
        
    }
    // Update is called once per frame
   void StartCounting()
    {
        counter ++;
        counter = counter % 4;
        string points = "";
        for (int i = 0; i < counter; i++)
            points += ".";
        loadingText.text = "Loading" + points;
  
    }
}

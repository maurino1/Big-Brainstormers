using UnityEngine;
using System.Collections;

public class PhotoScript : MonoBehaviour
{
    public GameObject startPanel;  
    public GameObject flashPanel; 
    public GameObject finalPanel; 

    public void OnButtonClick()
    {
        StartCoroutine(SwitchPanels());
    }

    IEnumerator SwitchPanels()
    {
       
        startPanel.SetActive(false);
        flashPanel.SetActive(true);

   
        yield return new WaitForSeconds(0.3f);

  
        flashPanel.SetActive(false);
        finalPanel.SetActive(true);
    }
}
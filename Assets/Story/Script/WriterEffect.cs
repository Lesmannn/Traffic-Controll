using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WriterEffect : MonoBehaviour
{
    public bool skip = false;
    public IEnumerator writerEffect(float delay, string f)
    {
        string currentText = "";
        for (int i = 0; i < f.Length + 1; i++)
        { 
            currentText = f.Substring(0, i);
            this.GetComponent<TMPro.TextMeshProUGUI>().text = currentText;
            if(!skip){
                yield return new WaitForSeconds(delay);
            }
            this.GetComponent<TextChange>().waiting = true;
        }
        skip = false;
        this.GetComponent<TextChange>().waiting = false;
    }

    public IEnumerator delay(float x){
        yield return new WaitForSeconds(x);
    }
}

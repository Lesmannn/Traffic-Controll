using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextChange : MonoBehaviour
{
    public TextMeshProUGUI textmesh;
    public GameObject panel;
    public string[] dialog;
    private bool wait = false;
    private int dialogIndex=0;
    private string currentText = "";
    public bool skip;
    public float delay;
    public bool waiting;
    void Start()
    {
        changeText(dialog[dialogIndex]);
		SoundManager.instance.Suara1();
        dialogIndex++;
        skip = true;
        waiting = false;
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && waiting == false){
            waiting = true;
            if(dialogIndex>=dialog.Length){
                panel.SetActive(false);
				SoundManager.instance.GetComponent<AudioSource>().Stop();
            }
            else{
				SoundManager.instance.VoiceText(dialogIndex-1);
                changeText(dialog[dialogIndex]);
                dialogIndex++;

            };
        }
        if(Input.GetKeyDown(KeyCode.Space) && waiting == true){
            this.GetComponent<WriterEffect>().skip = true;
        }
    }
    public void changeText(string text)
    {
        textmesh.text = text;
        StartCoroutine(this.GetComponent<WriterEffect>().writerEffect(delay, text));
    }    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using UnityEngine.UI;

public class ChangeExpresion : MonoBehaviour
{
    public GameObject chara;
    [HideInInspector]public List<Sprite> newSprite;
    public string path;
    private string[] files;
    [HideInInspector]public List<string> filesname;

    void ChangeSprite(int index)
    {
        chara.GetComponent<Image>().sprite = newSprite[index];
        chara.GetComponent<Image>().preserveAspect = true;
    }
    
    // Start is called before the first frame update
    void Start() {  
        GetFiles();
        loadExpresion();
        ChangeSprite(0);
        StartCoroutine("test");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ChangeSprite(1);
        }
    }

    private void GetFiles()
    {
        files = Directory.GetFiles("Assets/Resources/"+path, "*.png*");
        files = files.Where(name => !name.EndsWith(".meta")).ToArray();
        foreach (string sourceFile in files)
        {
            string fileName = Path.GetFileName (sourceFile);
            filesname.Add(fileName);
        }
    }

    private void loadExpresion(){
        for(int i=0;i<filesname.Count();i++){
            newSprite.Add(Resources.Load<Sprite>(path+"/"+filesname[i].Remove(filesname[i].Length-4)));
        }
    }
    public IEnumerator test(){
        for(int i =0; i<newSprite.Count();i++){
            yield return new WaitForSeconds(2f);
            ChangeSprite(i);
            Debug.Log("a"+i);
        }
    } 
}

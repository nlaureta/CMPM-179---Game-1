using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreTracker : MonoBehaviour
{
    [SerializeField] static private int numCollectibles = 0;
    [SerializeField] public int totalCollectibles = 5;
    public TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        numCollectibles = 0;
        text.text = "Collectable: " + numCollectibles;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void collectibleObtained(){
        numCollectibles++;
        Debug.Log("Collected: " + numCollectibles);
        text.text = "Collectable: " + numCollectibles;
        if (numCollectibles >= totalCollectibles){
            SceneManager.LoadScene("Win");
        }
    }

    public int getNumCollectibles(){
        return numCollectibles;
    }
}

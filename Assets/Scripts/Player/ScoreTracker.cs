using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreTracker : MonoBehaviour
{
    [SerializeField] static private int numCollectibles = 0;
    [SerializeField] public int totalCollectibles = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void collectibleObtained(){
        numCollectibles++;
        //Debug.Log("Collected: " + numCollectibles);
        if(numCollectibles >= totalCollectibles){
            SceneManager.LoadScene("Win");
        }
    }

    public int getNumCollectibles(){
        return numCollectibles;
    }

    public void resetCollectibles(){
        numCollectibles = 0;
    }
}

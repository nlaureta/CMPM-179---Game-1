using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectibleText : MonoBehaviour
{
    private string startOfText = "Collecibles: ";
    private string text;
    public TextMeshProUGUI sceneText;

    // Start is called before the first frame update
    void Start()
    {
        sceneText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text = startOfText + GetComponentInParent<ScoreTracker>().getNumCollectibles();
        //Debug.Log(sceneText.text);
        //sceneText.text = startOfText + GetComponentInParent<ScoreTracker>().getNumCollectibles();
        //Debug.Log(GetComponentInParent<ScoreTracker>().getNumCollectibles());
        Debug.Log(text);
        //GetComponentInParent<Text>() = text;
    }
}

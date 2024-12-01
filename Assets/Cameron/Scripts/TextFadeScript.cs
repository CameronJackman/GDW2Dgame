using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextFadeScript : MonoBehaviour
{
    public float fadeTime;
    private TMP_Text objectiveText;
    void Start()
    {
        objectiveText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(fadeTime > 0)
        {
            fadeTime -= Time.deltaTime;
            objectiveText.color = new Color(objectiveText.color.r, objectiveText.color.g, objectiveText.color.b, fadeTime);
        }
    }
}

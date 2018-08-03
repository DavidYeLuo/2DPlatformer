using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorIntroduction : MonoBehaviour {

    public string message;
    private Text displayText;

    void Start()
    {
        displayText = GetComponent<Text>();
        displayText.text = message;
        StartCoroutine(ShortDisplay());
    }

    private IEnumerator ShortDisplay()
    {
        displayText.text = message;
        yield return new WaitForSeconds(6);
        displayText.text = "";
    }
}

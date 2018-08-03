using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelDisplay : MonoBehaviour {
    public int level;
    private Text displayText;
	// Use this for initialization
	void Start () {
        displayText = GetComponent<Text>();
        StartCoroutine(ShortDisplay());
	}

    private IEnumerator ShortDisplay()
    {

        // yield return new WaitForSeconds(5);
        displayText.text = "Level " + level;
        yield return new WaitForSeconds(4);
        displayText.text = "";
    }
	
}

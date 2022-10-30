using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIM : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Toggle tog;
   
    // Start is called before the first frame update
    public void StartTog()
    {
        StartCoroutine("Tog");
    }

    IEnumerator Tog()
    {
        yield return new WaitForSeconds(2f);
        tog.isOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Date & Time: " + System.DateTime.Now;
    }
}

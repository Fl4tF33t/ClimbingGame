using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holds : MonoBehaviour
{
    public enum HoldDifficulty
    {
        Easy = 3,
        Medium = 2,
        Hard = 1,
        Impossible = 0,
    }

    Color[] color = new Color[4];
    MeshRenderer meshRenderer;

    public int holdLevel;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        color[0] = Color.red;
        color[1] = Color.cyan;
        color[2] = Color.yellow;
        color[3] = Color.green;
    }

    public void HoldInUse()
    {
        holdLevel--;
    }
    // Update is called once per frame
    void Update()
    {
       if (holdLevel < 0)
       {
            Destroy(this.gameObject);
       }

        meshRenderer.material.color = color[holdLevel];
    }
}

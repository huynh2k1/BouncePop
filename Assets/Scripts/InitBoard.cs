using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitBoard : MonoBehaviour
{
    public GameObject cell;
    public Transform parent;
    public int width;
    public int height;

    private void Start()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                Vector2 pos = new Vector2(i, j);
                Instantiate(cell, pos, Quaternion.identity);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public int row;
    public int col;

    public GameObject blockPrefab;

    private void Start()
    {
        InitBoard();
    }

    private void InitBoard()
    {
        for (int i = 0; i < col; i++)
        {
            for (int j = 0; j < row; j++)
            {
                Vector2 pos = new Vector2(i, j);
                GameObject block = Instantiate(blockPrefab, pos, Quaternion.identity);
                block.transform.SetParent(transform, false);
            }
        }
    }
}

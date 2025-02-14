using UnityEngine;
using UnityEngine.Rendering;
using System.Collections.Generic;
using UnityEngine.UI;

public class TableDisplay : MonoBehaviour
{
    public GameObject _rowPrefab;
    public Transform _tableParent;

    public void DisplayTable(List<string[]> data)
    {
        foreach (string[] row in data)
        {
            GameObject newRow = Instantiate(_rowPrefab, _tableParent);
            Text[] texts = newRow.GetComponentsInChildren<Text>();

            for (int i = 0; i < row.Length; i++)
            {
                texts[i].text = row[i];
            }
        }
    }

}
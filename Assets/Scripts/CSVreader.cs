using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;
using TMPro;

public class CSVreader : MonoBehaviour
{
    public TextAsset _textAssetData;

    [System.Serializable]
    public class TableData
    {
        public int cardID;
        public string cardName;
        public string cardPack;
        public int cardRarity;
    }

    [System.Serializable]
    public class CSVDataList
    {
        public TableData[] data;
    }

    public CSVDataList _myData = new CSVDataList();


    public Transform tableParent; 
    public GameObject rowPrefab;
    public Button sortByNameButton;
    public Button sortByNumberButton;

    void Start()
    {
        ReadCSV();
        DisplayTable();
        AddButtonListeners();
    }

    void ReadCSV()
    {
        string[] lines = _textAssetData.text.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
        int tableSize = lines.Length - 1;
        _myData.data = new TableData[tableSize];

        for (int i = 1; i < lines.Length; i++)
        {
            string[] row = lines[i].Split(new char[] { ',' }, StringSplitOptions.None);

            if (row.Length >= 4)
            {
                _myData.data[i - 1] = new TableData
                {
                    cardID = int.Parse(row[0].Trim()),
                    cardName = row[1].Trim(),
                    cardPack = row[2].Trim(),
                    cardRarity = int.Parse(row[3].Trim())
                };
            }
        }
    }

    void DisplayTable()
    {

        if (tableParent == null)
        {
            Debug.LogError("Table parent is null");
            return;
        }

        if (rowPrefab == null)
        {
            Debug.LogError("Row prefab is null");
            return;
        }

        if (_myData.data == null)
        {
            Debug.LogError("Data is null");
            return;
        }

        foreach (Transform child in tableParent)
        {
            Destroy(child.gameObject);
        }

        //Crea una fila por cada entrada en los datos
        foreach (var card in _myData.data)
        {
            GameObject row = Instantiate(rowPrefab, tableParent);
            row.transform.Find("TextCardID").GetComponent<TextMeshProUGUI>().text = card.cardID.ToString();
            row.transform.Find("TextCardName").GetComponent<TextMeshProUGUI>().text = card.cardName;
            row.transform.Find("TextCardPack").GetComponent<TextMeshProUGUI>().text = card.cardPack;
            row.transform.Find("TextCardRarity").GetComponent<TextMeshProUGUI>().text = card.cardRarity.ToString();
        }
    }

    void AddButtonListeners()
    {

        sortByNameButton.onClick.AddListener(() =>
        {
            _myData.data = _myData.data.OrderBy(card => card.cardName).ToArray();
            DisplayTable();
        });


        sortByNumberButton.onClick.AddListener(() =>
        {
            _myData.data = _myData.data.OrderBy(card => card.cardID).ToArray();
            DisplayTable();
        });
    }
}

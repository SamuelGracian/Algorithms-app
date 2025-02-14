using UnityEngine;
using System.Collections.Generic;
using System.Data;

public class Datasorter : MonoBehaviour
{
    public List<string[]> SortData (List <string[]> data , int ColumnIndex, bool Ascending = true)
    {
        data.Sort((a, b) =>
        {
            return Ascending ? a[ColumnIndex].CompareTo(b[ColumnIndex]) : b[ColumnIndex].CompareTo(a[ColumnIndex]);

        });
        return data;
    }
}

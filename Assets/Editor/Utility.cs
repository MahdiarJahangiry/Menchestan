using UnityEditor;
using UnityEngine;
public class Utility
{
    [MenuItem("Utility/Delete All")]
    static public void DeleteAllPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}
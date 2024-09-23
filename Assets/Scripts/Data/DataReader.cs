using System.IO;
using UnityEngine;

public class DataReader
{
    private static string _folderPath = Application.streamingAssetsPath;

    public static T ReadData<T>(string name, string puthInStreamingAssets = "")
    {
        T value = default(T);
        Debug.Log("Path : " + _folderPath + '/' + puthInStreamingAssets + name + ".txt");
        string textData = File.ReadAllText(_folderPath + '/'+ puthInStreamingAssets + name + ".txt");
        if (textData != "")
            value = JsonUtility.FromJson<T>(textData);
        else
        {
            WriteData<T>(value, name);
            Debug.Log("File not found! A default file has been created at this path");
        }
        return value;
    }
    public static void WriteData<T>(T data, string name, string puthInStreamingAssets = "")
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(_folderPath + '/'+ puthInStreamingAssets + name + ".txt", json);
    }
    public static T ReadData<T>()
    {
        return ReadData<T>(typeof(T).Name);
    }
    public static void WriteData<T>(T data) => WriteData<T>(data, typeof(T).Name);
}

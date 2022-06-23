using System.IO;
using UnityEngine;

public enum FilePath
{
    settings, gameplay, player
}
public class SaveSystem : MonoBehaviour
{
    #if UNITY_EDITOR
    private static readonly string SAVE_PATH = Application.dataPath + "/_Project/Scripts/System/Save/";
    #else
    private static readonly string SAVE_PATH = Application.persistentDataPath + "/Save/";
    #endif

    public static void Load<T>(ref T data, FilePath path)
    {
        Init();

        string json = null;
        string completePath = Path.Combine(SAVE_PATH, path.ToString() + ".md");
        print(completePath);
        
        //if exist data
        if (File.Exists(completePath))
            json = File.ReadAllText(completePath);

        if (string.IsNullOrEmpty(json))
        {
            WriteJson(data, path);
            json = File.ReadAllText(completePath);
        }

        data = JsonUtility.FromJson<T>(json);
    }
    public static void WriteJson<T>(T data, FilePath path)
    {
        Init();

        string completePath = Path.Combine(SAVE_PATH, path.ToString() + ".md");
        File.WriteAllText(completePath, JsonUtility.ToJson(data, true));
    }

    private static void Init()
    {
        if (Directory.Exists(SAVE_PATH)) return;
        Directory.CreateDirectory(SAVE_PATH);
    }
}
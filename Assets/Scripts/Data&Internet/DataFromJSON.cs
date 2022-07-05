using UnityEngine;
using System.IO;

public class DataFromJSON: MonoBehaviour
{
    public static DataFromJSON Instance;
    
    public string bundlePath = "";
   // public string gamePath = "";
    public int version;
    
    private string _path;
    private JsonFile _jsonFile = new JsonFile();

    
    private void Awake()
    {
        if (Instance== null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        _path = Application.streamingAssetsPath + "/" + "DataJSON.json";
        
        Debug.Log(_path);
        _jsonFile = JsonUtility.FromJson<JsonFile>(File.ReadAllText(_path));

        bundlePath = _jsonFile.BundlePath;
        version = _jsonFile.BundleVersion;

    }
}

public class JsonFile
{
    public string BundlePath;
    public int BundleVersion;
}

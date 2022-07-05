using System.Collections;
using UnityEngine;


public class LoadScript : MonoBehaviour
{
    [SerializeField] private string bundleURL;
    [SerializeField] private int version;
    [SerializeField] private string bundleName;

 
    private void Start()
    {
        //чистим кэш бандлов
        Caching.ClearCache();
        GetData();
        StartCoroutine(DownloadAndCache());
    }

    private void GetData()
    {
        bundleURL = DataFromJSON.Instance.bundlePath;
        version = DataFromJSON.Instance.version;
    }

    IEnumerator DownloadAndCache()
    {
        while (!Caching.ready)
            yield return null;
        
            var www = WWW.LoadFromCacheOrDownload(bundleURL, version);
            yield return www;

            if (!string.IsNullOrEmpty(www.error))
            {
                Debug.Log(www.error);
                yield break;
            }
            Debug.Log("Бандл загружен!");
            
            PlayerPrefs.SetInt("BundleDownloaded",1);//ошибка сети больше не будет высвечиваться
            var assetBundle = www.assetBundle;
            
            Instantiate(assetBundle.LoadAsset(bundleName));
            assetBundle.Unload(false);
    }
}

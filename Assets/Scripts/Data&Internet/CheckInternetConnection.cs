using UnityEngine;

public class CheckInternetConnection : MonoBehaviour
{
    [SerializeField] private GameObject error;
    [SerializeField] private GameObject workingOffline;
    [SerializeField]private int bundleDownloaded;
    private void Start()
    {
        //Для перезагрузки первоначальной ошибки об отсутствии соединения
        //PlayerPrefs.DeleteAll();
        bundleDownloaded = PlayerPrefs.GetInt("BundleDownloaded");
        
        if (Application.internetReachability == NetworkReachability.NotReachable && bundleDownloaded==0) 
        {
            Debug.Log("Error. Check internet connection!");                             
        }
        else
        {
            error.SetActive(false);
        }
    }

    private void Update()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            workingOffline.SetActive(true);
        }
        else
        {
            workingOffline.SetActive(false);
        }
    }
}
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    
    [SerializeField] private Image progressBar;
    [SerializeField] private Animator transition;
    private float _target;
    
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
    private void Update()
    {
        progressBar.fillAmount = Mathf.MoveTowards(progressBar.fillAmount, _target, 3 * Time.deltaTime);
    }
    
    public void LoadScene(string sceneName)
    { 
        SoundManager.Instance.PlayMusic();
        _target = 0;
        progressBar.fillAmount = 0;
        StartCoroutine(LoadLevel(sceneName));
    }
    IEnumerator LoadLevel(string sceneName)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(0.5f);
        FillLoading(sceneName);
    }
    private async void FillLoading(string sceneName)
    {
        var scene = SceneManager.LoadSceneAsync(sceneName);
        scene.allowSceneActivation = false;
       
        do
        {
            await Task.Delay(100);
            _target = scene.progress;
        } while (scene.progress < 0.9f);
        await Task.Delay(1000);//пауза перед запуском сцены
        
        scene.allowSceneActivation = true;
        transition.SetTrigger("End");
        
        
    }

}


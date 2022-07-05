using UnityEngine;

public class ChangeScene : MonoBehaviour
{
 public void ChangeSceneButton(string sceneName)
 {
  LevelManager.Instance.LoadScene(sceneName);

 }
}

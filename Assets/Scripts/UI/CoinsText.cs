
using UnityEngine;
using UnityEngine.UI;

public class CoinsText : MonoBehaviour
{
    public static CoinsText Instance;

    [SerializeField] private Text text;
    private int _coins;
    private void Start()
    {
        if (Instance==null)
        {
            Instance = this;
        }
        text = GetComponent<Text>();
    }

    public void AddCoin(int countCoins)
    {
        _coins+=countCoins;
        text.text = "Coins: " + _coins;

    }
}

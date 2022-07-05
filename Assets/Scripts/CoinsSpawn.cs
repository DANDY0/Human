using System.Collections;
using UnityEngine;

public class CoinsSpawn : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private Transform ground;
    [SerializeField] private Vector2Int coinsRangeVector2IntX;
    [SerializeField] private Vector2Int coinsRangeVector2IntZ;
    [SerializeField] private float _spawnTime;
     private Vector3 _spawnZone;
     private int _randomX;
     private int _randomZ;
     
     
    
    private void Start()
    {
     
        StartCoroutine(SpawnCoinCoroutine());
        
    }

    private void SpawnCoin()
    {
        _randomX = Random.Range(coinsRangeVector2IntX.x, coinsRangeVector2IntX.y);
        _randomZ = Random.Range(coinsRangeVector2IntZ.x, coinsRangeVector2IntZ.y);
        _spawnZone = new Vector3(_randomX,ground.position.y+20,_randomZ);
        Instantiate(coinPrefab,_spawnZone,Quaternion.identity);
    }

    IEnumerator SpawnCoinCoroutine()
    {
        while (true)
        {
            SpawnCoin();
            yield return new WaitForSeconds(_spawnTime);
        }
    }


}

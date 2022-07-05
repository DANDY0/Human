using System.Collections;
using UnityEngine;
using DG.Tweening;

public class Coin : MonoBehaviour
{
    [SerializeField] private float dist;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private bool canRotate;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        canRotate = true;
        StartCoroutine(Death());
    }
    private void Update()
    {
        CalculateDistance();
//        Debug.Log(_dist);
        if ((int)dist==2 && canRotate )
        {
            StopCoin();
            RotateCoin();
        }
    }

    public void CalculateDistance()
    {
        Vector3 pos = gameObject.transform.position;
        dist =  Vector3.Distance(transform.position,new Vector3
           (pos.x, -0.5f,pos.z));
    }

    private void RotateCoin()
    {
        transform.DORotate(new Vector3(0,360,0),1, RotateMode.FastBeyond360)
            .SetLoops(-1,LoopType.Incremental).SetEase(Ease.Linear);
        canRotate = false;
    }
    private void StopCoin()
    {
        rb.constraints = RigidbodyConstraints.FreezePositionY;
    }
    
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CoinsText.Instance.AddCoin(1);
            Destroy(gameObject);
        }
    }
    
    IEnumerator Death()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}

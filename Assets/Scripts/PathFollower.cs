using UnityEngine;
using PathCreation;
public class PathFollower : MonoBehaviour
{
  [SerializeField] private float speed;
  [SerializeField] private PathCreator pathCreator;

  private Rigidbody _rigidbody;
  private float _distancePassed;

  private void Start()
  {
    _rigidbody = GetComponent<Rigidbody>();
    _rigidbody.MovePosition(pathCreator.path.GetPointAtDistance(_distancePassed));
  }

  private void Update()
  {
    _distancePassed += Time.deltaTime + speed*0.001f;

    Vector3 nextPoint = pathCreator.path.GetPointAtDistance(_distancePassed);
    nextPoint.y = transform.position.y;
    
    transform.LookAt(nextPoint);
    _rigidbody.MovePosition(nextPoint);
  }
}

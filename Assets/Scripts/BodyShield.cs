using UnityEngine;

public class BodyShield : MonoBehaviour
{
    [SerializeField] private MeshRenderer _view;

    [SerializeField] private float _recoveryTime = 3f;

    private bool _isActivated;
    private float _timer;

    private void Awake()
    {
        SetupShield(true);
    }

    private void Update()
    {
        if (_isActivated == true)
            return;

        _timer += Time.deltaTime;
        
        if (_timer >= _recoveryTime)
        {
            _timer = 0;
            SetupShield(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isActivated == false)
            return;

        if (other.gameObject.TryGetComponent(out Bullet bullet))
        {
            DestroyBullet(bullet);
            SetupShield(false);
        }
    }

    private void DestroyBullet(Bullet bullet)
    {
        Destroy(bullet.gameObject);
    }

    private void SetupShield(bool value)
    {
        _isActivated = value;
        _view.enabled = value;
    }
}
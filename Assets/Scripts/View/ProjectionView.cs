using UnityEngine;

public class ProjectionView : MonoBehaviour
{
    public static ProjectionView instance;
    [SerializeField] private Transform _transform;
    [SerializeField] private GameObject _pointProjection;
    [SerializeField] private GameObject _redProjection;

    private void Awake()
    {
        instance = this;
    }

    private void FixedUpdate()
    {
        if (_transform != null)
        {
            _transform.position = new Vector3(ScreenModel.instance.posTouch, -0.45f, 90f);
        }
    }

    public void PointProjection()
    {
        _pointProjection.SetActive(true);
        _redProjection.SetActive(false);
    }

    public void RedProjection()
    {
        _redProjection.SetActive(true);
        _pointProjection.SetActive(false);
    }
}
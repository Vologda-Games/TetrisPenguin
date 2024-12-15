using System.Collections;
using UnityEngine;

public class ProjectionView : MonoBehaviour
{
    public static ProjectionView instance;
    [SerializeField] private Transform _transform;
    [SerializeField] private GameObject _pointProjection;
    [SerializeField] private GameObject _redProjection;
    private bool _activationRedLine = false;
    private bool _activationPointLine = false;
    private int multiplicatiorActivationRed = 1;
    private int multiplicatiorActivationPoint = 1;

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
        multiplicatiorActivationPoint = 1;
        if (!_activationPointLine) StartCoroutine(ActivationPointline());
        multiplicatiorActivationRed = -1;
        if (!_activationRedLine) StartCoroutine(ActivationRedline());
    }

    public void RedProjection()
    {
        multiplicatiorActivationRed = 1;
        if (!_activationRedLine) StartCoroutine(ActivationRedline());
        multiplicatiorActivationPoint = -1;
        if (!_activationPointLine) StartCoroutine(ActivationPointline());
    }

    private IEnumerator ActivationRedline()
    {
        _activationRedLine = true;
        while (true)
        {
                while (_redProjection.transform.localScale.x < 1f && multiplicatiorActivationRed > 0)
                {
                    _redProjection.transform.localScale += new Vector3(0.1f, 0f, 0f);
                    yield return new WaitForFixedUpdate();
                }
                if (multiplicatiorActivationRed > 0) _redProjection.transform.localScale = Vector3.one;
                while (_redProjection.transform.localScale.x > 0f && multiplicatiorActivationRed < 0)
                {
                    _redProjection.transform.localScale -= new Vector3(0.1f, 0f, 0f);
                    yield return new WaitForFixedUpdate();
                }
                if (multiplicatiorActivationRed < 0) _redProjection.transform.localScale = new Vector3(0f, 1f, 1f);
                if (_redProjection.transform.localScale.x >= 1f || _redProjection.transform.localScale.x <= 0f) break;
                yield return new WaitForFixedUpdate();
        }
        _activationRedLine = false;
    }

    private IEnumerator ActivationPointline()
    {
        _activationPointLine = true;
        while (true)
        {
            while (_pointProjection.transform.localScale.x < 1f && multiplicatiorActivationPoint > 0)
            {
                _pointProjection.transform.localScale += new Vector3(0.1f, 0f, 0f);
                yield return new WaitForFixedUpdate();
            }
            if (multiplicatiorActivationPoint > 0) _pointProjection.transform.localScale = Vector3.one;
            while (_pointProjection.transform.localScale.x > 0f && multiplicatiorActivationPoint < 0)
            {
                _pointProjection.transform.localScale -= new Vector3(0.1f, 0f, 0f);
                yield return new WaitForFixedUpdate();
            }
            if (multiplicatiorActivationPoint < 0) _pointProjection.transform.localScale = new Vector3(0f, 1f, 1f);
            if (_pointProjection.transform.localScale.x >= 1f || _pointProjection.transform.localScale.x <= 0f) break;
            yield return new WaitForFixedUpdate();
        }
        _activationPointLine = false;
    }
}
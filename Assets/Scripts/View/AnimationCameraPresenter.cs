using System.Collections;
using UnityEngine;

public class AnimationCameraPresenter : MonoBehaviour
{
    public static AnimationCameraPresenter instance;
    private bool shaking = false;

    private void Awake()
    {
        instance = this;
    }

    public void ShakingCamera()
    {
        if (!shaking) StartCoroutine(Shaking());
    }

    private IEnumerator Shaking()
    {
        shaking = true;
        Vector3 currentPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Vector2 maxPos = new Vector2(transform.position.x + .07f, transform.position.x + .07f);
        Vector2 minPos = new Vector2(transform.position.x - .07f, transform.position.x - .07f);
        for (int i = 0; i < 4; i++)
        {
            while (transform.position.x < maxPos.x)
            {
                transform.position += new Vector3(0.1f, 0.1f, 0f);
                yield return new WaitForFixedUpdate();
            }
            while (transform.position.x > minPos.x)
            {
                transform.position -= new Vector3(0.1f, 0.1f, 0f);
                yield return new WaitForFixedUpdate();
            }
            while (transform.position.x < currentPos.x)
            {
                transform.position += new Vector3(0.1f, 0.1f, 0f);
                yield return new WaitForFixedUpdate();
            }
        }
        transform.position = currentPos;
        shaking = false;
    }
}
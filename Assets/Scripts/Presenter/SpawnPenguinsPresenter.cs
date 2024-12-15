using System.Collections;
using UnityEngine;

public class SpawnPenguinsPresenter : MonoBehaviour
{
    public static SpawnPenguinsPresenter instance;

    private void Awake()
    {
        instance = this;    
    }
    private bool isScale = false;

    public void SpawnByLevel(int level)
    {
        GameObject penguin = Instantiate(PrefabsPresenter.GetPrefabByLevel(level), ParentsView.instance.penguinsParent);
        if (!isScale) StartCoroutine(ScaleUpPenguin(penguin));
        PenguinView penguinView = penguin.GetComponent<PenguinView>();
        penguinView.objTransform.localPosition = new Vector3(ScreenModel.instance.posTouch, 550, 0);
        penguinView.objTransform.localRotation = new Quaternion(0f, 0f, Random.Range(-45f, 45f), 180f);
        penguinView.level = level;
        penguinView.triggerUp = true;
        penguinView.objRigidbody.simulated = false;
        PenguinsModel.instance.penguinInSpawn = penguinView;
        //BafsPresenter.SetActiveBlackbackgroundBtn();
    }

    public static void SpawnByLevel(int level, Vector3 pos)
    {
        GameObject penguin = Instantiate(PrefabsPresenter.GetPrefabByLevel(level), pos, Quaternion.identity, ParentsView.instance.penguinsParent);
        PenguinView penguinView = penguin.GetComponent<PenguinView>();
        penguinView.level = level;
        PenguinsModel.instance.penguinViews.Add(penguinView);
    }

    public static void SpawnStart(int level, float x, float y)
    {
        GameObject penguin = Instantiate(PrefabsPresenter.GetPrefabByLevel(level), ParentsView.instance.penguinsParent);
        PenguinView penguinView = penguin.GetComponent<PenguinView>();
        penguinView.level = level;
        penguinView.objTransform.localPosition = new Vector3(x, y, 0);
        PenguinsModel.instance.penguinViews.Add(penguinView);
    }

    private IEnumerator ScaleUpPenguin(GameObject go)
    {
        isScale = true;
        go.transform.localScale = Vector3.zero;
        while(go != null) 
        {
            if (go.transform.localScale.x < Vector3.one.x)
            {
                go.transform.localScale += new Vector3(0.12f, 0.12f, 0.12f);
                yield return new WaitForFixedUpdate();
            }else break;
        }
        if (go != null) go.transform.localScale = Vector3.one;
        isScale = false;
    }
}
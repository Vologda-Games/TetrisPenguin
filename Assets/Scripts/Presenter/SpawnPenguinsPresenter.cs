using UnityEngine;

public class SpawnPenguinsPresenter : MonoBehaviour
{
    // public static SpawnPenguinsPresenter instance;

    // private void Awake()
    // {
    //     instance = this;
    // }

    public static void SpawnByLevel(int level)
    {
        GameObject penguin = Instantiate(PrefabsPresenter.GetPrefabByLevel(level), ParentsView.instance.penguinsParent);
        PenguinView penguinView = penguin.GetComponent<PenguinView>();
        penguinView.objTransform.localPosition = new Vector3(ScreenModel.instance.posTouch, 550, 0);
        penguinView.level = level;
        penguinView.triggerUp = true;
        penguinView.objRigidbody.simulated = false;
        PenguinsModel.instance.penguinInSpawn = penguinView;
        AddTriggerZone(penguin, penguinView);
    }

    public static void SpawnByLevel(int level, Vector3 pos)
    {
        GameObject penguin = Instantiate(PrefabsPresenter.GetPrefabByLevel(level), pos, Quaternion.identity, ParentsView.instance.penguinsParent);
        PenguinView penguinView = penguin.GetComponent<PenguinView>();
        penguinView.level = level;
        PenguinsModel.instance.penguinViews.Add(penguinView);
        AddTriggerZone(penguin, penguinView);
    }

    public static void SpawnStart(int level, float x, float y)
    {
        GameObject penguin = Instantiate(PrefabsPresenter.GetPrefabByLevel(level), ParentsView.instance.penguinsParent);
        PenguinView penguinView = penguin.GetComponent<PenguinView>();
        penguinView.level = level;
        penguinView.objTransform.localPosition = new Vector3(x, y, 0);
        PenguinsModel.instance.penguinViews.Add(penguinView);
    }

    public static void AddTriggerZone(GameObject _object, PenguinView penguinView)
    {
        _object.AddComponent<CircleCollider2D>();
        _object.GetComponent<CircleCollider2D>().radius = penguinView._radiusTriggerZone;
        _object.GetComponent<CircleCollider2D>().isTrigger = true;
    }
}

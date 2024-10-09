using Unity.Mathematics;
using Unity.VisualScripting;
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
        AddTriggerZone(penguin, penguinView);
    }

    public static void AddTriggerZone(GameObject _object, PenguinView _penguinView) // Спавним триггер, который будет определять расстояние слияния объектов
    {
        GameObject _triggerZone = _penguinView._triggerZone;

        if(_object.transform.childCount > 0)
        {
            for(int i = 0; i < _object.transform.childCount; i++)
            {
                bool _haveTrigger = false;
                GameObject _childToObject = _object.transform.GetChild(i).gameObject;
                if(_childToObject == _triggerZone)
                {
                    _haveTrigger = true;
                    break;
                }
                else if(!_haveTrigger && _childToObject == _object.transform.GetChild(_object.transform.childCount - 1))
                {
                    GameObject _newTriggerZone = Instantiate(_triggerZone, _object.transform.position, Quaternion.identity, _object.transform);
                    _newTriggerZone.GetComponent<CircleCollider2D>().radius = _penguinView._radiusTriggerZone;
                }
            }
        }
        else
        {
            GameObject _newTriggerZone = Instantiate(_triggerZone, _object.transform.position, Quaternion.identity, _object.transform);
            _newTriggerZone.GetComponent<CircleCollider2D>().radius = _penguinView._radiusTriggerZone;
            if(_penguinView.level == 16) _newTriggerZone.GetComponent<CircleCollider2D>().offset = _object.GetComponent<CircleCollider2D>().offset;
            else _newTriggerZone.GetComponent<CircleCollider2D>().offset = Vector2.zero;
        }
    }
}

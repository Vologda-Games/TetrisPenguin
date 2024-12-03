using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinView : MonoBehaviour
{
    [Header("Transform")]
    [SerializeField] public RectTransform objTransform;

    [Header("GameObjects")]
    [SerializeField, HideInInspector] public GameObject go;

    [Header("Phisics/Collisions")]
    [SerializeField, HideInInspector] public Rigidbody2D objRigidbody;
    //public BoxCollider2D objBoxCollider;

    [Header("Boolian")]
    [SerializeField] public bool triggerUp;
    [SerializeField] public bool triggerMerge;
    [SerializeField] public bool _strongBlow;

    [Header("Integers")]
    [SerializeField] public int level;

    private void Start()
    {
        StartCoroutine(UpdatePosition());
        objRigidbody = GetComponent<Rigidbody2D>();
        go = gameObject;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(_strongBlow)
        {
            MusicAndSoundsManager._instance.PlaySound("StrongBlow", 1f);
            _strongBlow = false; 
        }
        for (int i = 0; i < PenguinsModel.instance.penguinViews.Count; i++)
        {
            if (collision.gameObject == PenguinsModel.instance.penguinViews[i].go)
            {
                if (level == 15)
                {
                    DailyTasksPresenter.CheckCreateForTask(collision.gameObject.GetComponent<PenguinView>().level + 1);
                    if (PenguinsModel.instance.penguinViews[i].level == 0 || PenguinsModel.instance.penguinViews[i].level == 1 || PenguinsModel.instance.penguinViews[i].level == 2)
                    {
                        if (triggerMerge == false)
                        {
                            MusicAndSoundsManager._instance.PlaySound("Multicolor", 1f);
                            triggerMerge = true;
                            Vector3 pos = PenguinsModel.instance.penguinViews[i].objTransform.position;
                            int levelI = PenguinsModel.instance.penguinViews[i].level;
                            Destroy(PenguinsModel.instance.penguinViews[i].go);
                            PenguinsModel.instance.penguinViews.RemoveAt(i);
                            for (int j = 0; j < PenguinsModel.instance.penguinViews.Count; j++)
                            {
                                if (PenguinsModel.instance.penguinViews[j].go == go)
                                {
                                    Destroy(go);
                                    PenguinsModel.instance.penguinViews.RemoveAt(j);
                                    SpawnPenguinsPresenter.SpawnByLevel(levelI + 1, pos);
                                    PenguinsPresenter.MergePenguins(levelI);
                                    return;
                                }
                            }
                        }
                        else { return; }
                    }
                }
                else if (level == 16)
                {
                    List<PenguinView> indexes = new List<PenguinView>();
                    for (int j = 0; j < PenguinsModel.instance.penguinViews.Count; j++)
                    {
                        if ((objTransform.position - PenguinsModel.instance.penguinViews[j].objTransform.position).magnitude < 1)
                        {
                            indexes.Add(PenguinsModel.instance.penguinViews[j]);
                        }
                    }
                    for (int y = 0; y < indexes.Count; y++)
                    {
                        Destroy(indexes[y].go);
                        for (int x = 0; x < PenguinsModel.instance.penguinViews.Count; x++)
                        {
                            if (PenguinsModel.instance.penguinViews[x] == indexes[y])
                            {
                                PenguinsModel.instance.penguinViews.RemoveAt(x);
                            }
                        }
                    }
                    MusicAndSoundsManager._instance.PlaySound("Bomb", 4f); 
                    // for (int l = 0; l < PenguinsModel.instance.penguinViews.Count; l++)
                    // {
                    //     if (PenguinsModel.instance.penguinViews[l].go == go)
                    //     {
                    //         Destroy(go);
                    //         PenguinsModel.instance.penguinViews.RemoveAt(l);
                    //         return;
                    //     }
                    // }
                }
                else
                {
                    if (PenguinsModel.instance.penguinViews[i].level == level)
                    {
                        if (triggerMerge == false)
                        {
                            MusicAndSoundsManager._instance.PlaySound("Merge", 1f);
                            DailyTasksPresenter.CheckCreateForTask(level + 1);
                            if(!PenguinsModel.instance.penguinsCardsInformations[level + 1].ready)
                            {
                                PenguinsModel.instance.penguinsCardsInformations[level + 1].ready = true;
                                DataPresenter.SavePenguinsModel();
                            }
                            triggerMerge = true;
                            PenguinView penguinView_1 = PenguinsModel.instance.penguinViews[i];
                            Vector3 pos = penguinView_1.objTransform.position;
                            // Destroy(penguinView_1.objBoxCollider);
                            penguinView_1.objRigidbody.simulated = false;
                            PenguinsModel.instance.penguinViews.RemoveAt(i);
                            for (int j = 0; j < PenguinsModel.instance.penguinViews.Count; j++)
                            {
                                if (PenguinsModel.instance.penguinViews[j].go == go)
                                {
                                    PenguinView penguinView_2 = PenguinsModel.instance.penguinViews[j];
                                    StartCoroutine(AnimationMerge(penguinView_1, penguinView_2, level, pos));
                                    // Destroy(penguinView_2.objBoxCollider);
                                    penguinView_2.objRigidbody.simulated = false;
                                    PenguinsModel.instance.penguinViews.RemoveAt(j);
                                    // SpawnPenguinsPresenter.SpawnByLevel(level + 1, pos);
                                    PenguinsPresenter.MergePenguins(level);
                                    return;
                                }
                            }
                        }
                        else { return; }
                    }
                    else { return; }
                }
            }
        }
    }


    private IEnumerator AnimationMerge(PenguinView penguinView_1, PenguinView penguinView_2, int level, Vector3 pos)
    {
        float stage = 0;
        while (stage < 1)
        {
            stage += 0.1f;
            penguinView_2.objTransform.Translate((penguinView_1.objTransform.position - penguinView_2.objTransform.position) * 0.1f);
            yield return new WaitForFixedUpdate();
        }
        // Где-то тут нужно будет сделать дымок
        SpawnPenguinsPresenter.SpawnByLevel(level + 1, pos);
        Debug.Log($"pos: {pos}");

        Instantiate(PenguinsModel.instance._particleFog, pos, Quaternion.identity, PenguinsModel.instance._particleParent);
        Destroy(penguinView_1.go);
        Destroy(penguinView_2.go);
    }

    private IEnumerator UpdatePosition()
    {
        while (triggerUp)
        {
            objTransform.position = new Vector3(ScreenModel.instance.posTouch, 2.6f, 90f);
            yield return new WaitForFixedUpdate();
        }
    }

    public void OnMouseDown()
    {
        if (BafsPresenter.GetSelectBaf() == 5 && level != 16 && level != 15)
        {
            DailyTasksPresenter.CheckUsedBaffForTask(BafsPresenter.GetSelectBaf());
            BafsView.instance.StartTriggerBtn();
            BafsPresenter.SetDestroyBaf(PenguinsModel.instance.penguinInSpawn.level);
            Destroy(PenguinsModel.instance.penguinInSpawn.go);
            PenguinsModel.instance.penguinInSpawn = null;
            SpawnPenguinsPresenter.SpawnByLevel(level);
            Destroy(go);
            for (int i = 0; i < PenguinsModel.instance.penguinViews.Count; i++)
            {
                if (PenguinsModel.instance.penguinViews[i] == this)
                {
                    PenguinsModel.instance.penguinViews.RemoveAt(i);
                }
            }
            BafsPresenter.SetSelectBaf(0);
            BafsPresenter.ReduceMagnetBafs(1);
            MusicAndSoundsManager._instance.PlaySound("Magnet", 2.5f);
        }
    }
}
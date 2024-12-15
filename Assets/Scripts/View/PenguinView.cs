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
        objTransform = GetComponent<RectTransform>();
        go = gameObject;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_strongBlow) _strongBlow = false;
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
                            MusicAndSoundsManager.instance.PlaySound("Multicolor", 1f);
                            triggerMerge = true;
                            Vector3 pos = PenguinsModel.instance.penguinViews[i].objTransform.position;
                            int levelI = PenguinsModel.instance.penguinViews[i].level;
                            StartCoroutine(PenguinsModel.instance.penguinViews[i].DeathPenguin(PenguinsModel.instance.penguinViews[i].go));
                            PenguinsModel.instance.penguinViews.RemoveAt(i);
                            for (int j = 0; j < PenguinsModel.instance.penguinViews.Count; j++)
                            {
                                if (PenguinsModel.instance.penguinViews[j].go == go)
                                {
                                    StartCoroutine(DeathPenguin(go));
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
                        if ((objTransform.position - PenguinsModel.instance.penguinViews[j].objTransform.position).magnitude < 1 && objTransform != PenguinsModel.instance.penguinViews[j].objTransform)
                        {
                            indexes.Add(PenguinsModel.instance.penguinViews[j]);
                        }else if(PenguinsModel.instance.penguinViews[j].go == collision.gameObject)
                        {
                            indexes.Add(PenguinsModel.instance.penguinViews[j]);
                        }
                    }
                    objRigidbody.simulated = false;
                    for (int y = 0; y < indexes.Count; y++)
                    {
                        Debug.Log(indexes[y].name);
                        for (int x = 0; x < PenguinsModel.instance.penguinViews.Count; x++)
                        {
                            if (PenguinsModel.instance.penguinViews[x] == indexes[y])
                            {
                                StartCoroutine(PenguinsModel.instance.penguinViews[x].DeathPenguin(PenguinsModel.instance.penguinViews[x].go));
                                PenguinsModel.instance.penguinViews.RemoveAt(x);
                                break;
                            }
                        }
                    }
                    MusicAndSoundsManager.instance.PlaySound("Bomb", 4f);
                    AnimationCameraPresenter.instance.ShakingCamera();
                    Instantiate(PenguinsModel.instance.particleBomb, new Vector2(transform.position.x, transform.position.y), Quaternion.identity, PenguinsModel.instance.particleParent);
                    for (int e = 0; e < PenguinsModel.instance.penguinViews.Count; e++)
                    {
                        if (PenguinsModel.instance.penguinViews[e] != null && PenguinsModel.instance.penguinViews[e] != this) PenguinsModel.instance.penguinViews[e].objRigidbody.AddForce(new Vector3(Random.Range(-.5f, .5f), 1, 0) * 80);
                    }
                    StartCoroutine(DeathPenguin(gameObject));
                    PenguinsModel.instance.penguinViews.Remove(this);
                }
                else
                {
                    if (PenguinsModel.instance.penguinViews[i].level == level)
                    {
                        if (triggerMerge == false)
                        {
                            triggerMerge = true;
                            PenguinView penguinView_1 = PenguinsModel.instance.penguinViews[i];
                            Vector3 pos = penguinView_1.objTransform.position;
                            penguinView_1.triggerMerge = true;
                            MusicAndSoundsManager.instance.PlaySound("Merge", 1f);
                            DailyTasksPresenter.CheckCreateForTask(level + 1);
                            if (!PenguinsModel.instance.penguinsCardsInformations[level + 1].ready)
                            {
                                PenguinsModel.instance.penguinsCardsInformations[level + 1].ready = true;
                                DataPresenter.SavePenguinsModel();
                            }
                            penguinView_1.objRigidbody.simulated = false;
                            PenguinsModel.instance.penguinViews.RemoveAt(i);
                            objRigidbody.simulated = false;
                            StartCoroutine(AnimationMerge(penguinView_1, this, level, pos));
                            PenguinsPresenter.MergePenguins(level);
                            PenguinsModel.instance.penguinViews.Remove(this);
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
        Vector3 addPos = (penguinView_1.objTransform.position - penguinView_2.objTransform.position) * 0.1f;
        while (stage < 1)
        {
            stage += 0.1f;
            penguinView_2.transform.position += addPos;
            yield return new WaitForFixedUpdate();
        }

        SpawnPenguinsPresenter.SpawnByLevel(level + 1, pos);

        Instantiate(PenguinsModel.instance.particleFog, pos, Quaternion.identity, PenguinsModel.instance.particleParent);
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

    public IEnumerator DeathPenguin(GameObject penguin)
    {
        while (penguin.transform.localScale.x > 0f)
        {
            penguin.transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
            yield return new WaitForFixedUpdate();
        }
        Destroy(penguin);
    }

    public void OnMouseDown()
    {
        if (BafsPresenter.GetSelectBaf() == 5 && level != 16 && level != 15 && PenguinsModel.instance.penguinInSpawn != null)
        {
            DailyTasksPresenter.CheckUsedBaffForTask(BafsPresenter.GetSelectBaf());
            BafsView.instance.StartTriggerBtn();
            BafsPresenter.SetDestroyBaf(PenguinsModel.instance.penguinInSpawn.level);
            StartCoroutine(DeathPenguin(PenguinsModel.instance.penguinInSpawn.go));
            PenguinsModel.instance.penguinInSpawn = null;
            SpawnPenguinsPresenter.instance.SpawnByLevel(level);
            PenguinsModel.instance.penguinInSpawnMagnet = PrefabsPresenter.GetPrefabByLevel(level).GetComponent<PenguinView>();
            StartCoroutine(DeathPenguin(go));
            for (int i = 0; i < PenguinsModel.instance.penguinViews.Count; i++)
            {
                if (PenguinsModel.instance.penguinViews[i] == this)
                {
                    PenguinsModel.instance.penguinViews.RemoveAt(i);
                }
            }
            BafsPresenter.ReduceMagnetBafs(1);
            MusicAndSoundsManager.instance.PlaySound("Magnet", 2.5f);
            BafsPresenter.SetActiveBlackbackgroundBtn();
        }
    }
}
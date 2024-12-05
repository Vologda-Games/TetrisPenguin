using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinsPresenter : MonoBehaviour
{
    public static PenguinsPresenter instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        if (PenguinsModel.instance.penguinInSpawn == null)
        {
            StartCoroutine(SpawnPenguin());
        }
    }

    public void SpawnPenguinOnStart()
    {
        if (PenguinsModel.instance.penguinObjectsForStart.Count > 0)
        {
            for (int i = 0; i < PenguinsModel.instance.penguinObjectsForStart.Count; i++)
            {
                PenguinObject penguinObject = PenguinsModel.instance.penguinObjectsForStart[i];
                SpawnPenguinsPresenter.SpawnStart(penguinObject.levelPenguin, penguinObject.posXPenguin, penguinObject.posYPenguin);
            }
        }
    }

    public void LoadSpritesPenguins()
    {
        PenguinsModel.spritesAllSoftPenguins = Resources.LoadAll<Sprite>("Sprites/Penguins/SoftPenguins");
        PenguinsModel.spritesAllUnknownPenguins = Resources.LoadAll<Sprite>("Sprites/Penguins/UnknownPenguins");
        if (PenguinsModel.instance.penguinsCardsInformations == null) PenguinsModel.instance.penguinsCardsInformations = new List<PenguinCardInformation>();
        if (PenguinsModel.instance.penguinsCardsInformations.Count < PenguinsModel.spritesAllSoftPenguins.Length)
        {
            for (int i = 0; i < PenguinsModel.spritesAllSoftPenguins.Length; i++)
            {
                for (int j = 0; j < PenguinsModel.spritesAllSoftPenguins.Length; j++)
                {
                    if (PenguinsModel.spritesAllSoftPenguins[j].name == $"penguin_{i}")
                    {
                        PenguinsModel.instance.penguinsCardsInformations.Add(new PenguinCardInformation()
                        {
                            levelPenguin = i,
                            softSprite = PenguinsModel.spritesAllSoftPenguins[j],
                            unknownSprite = PenguinsModel.spritesAllUnknownPenguins[j],
                            ready = false
                        });
                        if (i == 0)
                        {
                            PenguinsModel.instance.penguinsCardsInformations[i].ready = true;
                        }
                        else
                        {
                            PenguinsModel.instance.penguinsCardsInformations[i].ready = false;
                        }
                        break;
                    }
                }
            }
        }
        else
        {
            for (int i = 0; i < PenguinsModel.spritesAllSoftPenguins.Length; i++)
            {
                for (int j = 0; j < PenguinsModel.spritesAllSoftPenguins.Length; j++)
                {
                    if (PenguinsModel.spritesAllSoftPenguins[j].name == $"penguin_{i}")
                    {
                        PenguinsModel.instance.penguinsCardsInformations[i].softSprite = PenguinsModel.spritesAllSoftPenguins[j];
                        PenguinsModel.instance.penguinsCardsInformations[i].unknownSprite = PenguinsModel.spritesAllUnknownPenguins[j];
                        break;
                    }
                }
            }
        }
        DataPresenter.SavePenguinsModel();
    }

    public static void MergePenguins(int level)
    {
        int experience = 0;
        if (level == 0) { experience = 2; }
        else if (level == 1) { experience = 4; }
        else if (level == 2) { experience = 8; }
        else if (level == 3) { experience = 16; }
        else if (level == 4) { experience = 32; }
        else if (level == 5) { experience = 64; }
        else if (level == 6) { experience = 128; }
        else if (level == 7) { experience = 256; }
        else if (level == 8) { experience = 512; }
        else if (level == 9) { experience = 1024; }
        else if (level == 10) { experience = 2048; }
        else if (level == 11) { experience = 4096; }
        else if (level == 12) { experience = 8192; }
        else if (level == 13) { experience = 16384; }
        else if (level == 14) { experience = 32768; }
        PlayerPresenter.instance.AddExperience(experience);
    }

    public void StartPenguin()
    {
        PenguinView penguinView = null;
        if (PenguinsModel.instance.penguinInSpawn != null)
        {
            penguinView = PenguinsModel.instance.penguinInSpawn;
            penguinView.objRigidbody.simulated = true;
            penguinView.triggerUp = false;
            PenguinsModel.instance.penguinViews.Add(penguinView);
            PenguinsModel.instance.penguinInSpawn = null;
            DailyTasksPresenter.CheckClickForTask();
            if (BafsPresenter.GetSelectBaf() != 0 && BafsPresenter.GetSelectBaf() < 4)
            {
                DailyTasksPresenter.CheckUsedBaffForTask(BafsPresenter.GetSelectBaf());
            }
            if (penguinView.level == 15 && BafsPresenter.GetSelectBaf() != 2 && BafsView.instance.isSpring == true)
            {
                BafsPresenter.SetSelectBaf(0);
                BafsPresenter.ReduceMulticolorBafs(1);
                BafsPresenter.SetActiveBlackbackgroundBtn();
            }
            else if (penguinView.level == 16 && BafsPresenter.GetSelectBaf() != 2 && BafsView.instance.isSpring == true)
            {
                BafsPresenter.SetSelectBaf(0);
                BafsPresenter.ReduceBombBafs(1);
                BafsPresenter.SetActiveBlackbackgroundBtn();
            }
            if (BafsPresenter.GetSelectBaf() == 2 || BafsPresenter.GetSelectBaf() == 1 || BafsPresenter.GetSelectBaf() == 3 && ((BafsView.instance.isSpring == true && BafsView.instance.isBomb == true) || (BafsView.instance.isSpring == true && BafsView.instance.isMulticolor == true)))
            {
                Debug.Log("BUM");
                penguinView.objRigidbody.AddForce(Vector3.down * 800);
                if (!penguinView._strongBlow) penguinView._strongBlow = true;
                BafsPresenter.SetSelectBaf(0);
                if (BafsPresenter.GetSelectBaf() == 0) 
                {
                    Debug.Log("СТАЛ 0");
                }
                else 
                {
                    Debug.Log("НЕ 0");
                }
                BafsPresenter.ReduceSpringBafs(1);
                if (BafsView.instance.isSpring == true && BafsView.instance.isBomb == true) 
                {
                    BafsPresenter.ReduceBombBafs(1);
                }
                else if (BafsView.instance.isSpring == true && BafsView.instance.isMulticolor == true) 
                {
                    BafsPresenter.ReduceMulticolorBafs(1);
                }
                ProjectionView.instance.PointProjection();
                BafsPresenter.SetActiveBlackbackgroundBtn();
                BafsView.instance.isSpring = false;
                BafsView.instance.isBomb = false;
                BafsView.instance.isMulticolor = false;
            }
            if (BafsPresenter.GetSelectBaf() == 0)
            {
                if (PenguinsModel.instance.penguinInSpawn == null)
                {
                    StartCoroutine(SpawnPenguin());
                }
                else
                {
                    SpawnPenguinsPresenter.SpawnByLevel(BafsPresenter.GetDestroyBaf());
                    BafsPresenter.SetDestroyBaf(0);
                }
            }
        }
    }

    public IEnumerator SpawnPenguin()
    {
        yield return new WaitForSeconds(0.5f);
        if (BafsPresenter.GetSelectBaf() == 0 || BafsPresenter.GetSelectBaf() == 2)
        {
            int _randomChance = Random.Range(1, 101);
            for (int i = PenguinsModel._levelToChances.Count - 1; i > 0; i--)
            {
                if (_randomChance <= PenguinsModel._levelToChances[i].chance)
                {
                    SpawnPenguinsPresenter.SpawnByLevel(i);
                    break;
                }
                else
                {
                    if (PenguinsModel._levelToChances[i] == PenguinsModel._levelToChances[1]) SpawnPenguinsPresenter.SpawnByLevel(0);
                }
            }
            if (BafsPresenter.GetSelectBaf() == 2)
            {
                ProjectionView.instance.RedProjection();
            }
        }
        Debug.Log("spawn");
    }
}
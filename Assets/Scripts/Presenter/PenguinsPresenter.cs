using System.Collections;
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
        if (PenguinsModel.instance.penguinObjectsForStart.Count > 0)
        {
            for (int i = 0; i < PenguinsModel.instance.penguinObjectsForStart.Count; i++)
            {
                PenguinObject penguinObject = PenguinsModel.instance.penguinObjectsForStart[i];
                SpawnPenguinsPresenter.SpawnStart(penguinObject.levelPenguin, penguinObject.posXPenguin, penguinObject.posYPenguin);
            }
        }
        if (PenguinsModel.instance.penguinInSpawn == null)
        {
            StartCoroutine(SpawnPenguin());
        }
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
        PlayerPresenter.AddCoin(experience);
    }

    public void StartPenguin()
    {
        PenguinView penguinView = PenguinsModel.instance.penguinInSpawn;
        penguinView.objRigidbody.simulated = true;
        penguinView.triggerUp = false;
        PenguinsModel.instance.penguinViews.Add(penguinView);
        PenguinsModel.instance.penguinInSpawn = null;
        if (penguinView.level == 15)
        {
            BafsPresenter.SetSelectBaf(0);
            BafsPresenter.ReduceMulticolorBafs(1);
        }
        else if (penguinView.level == 16)
        {
            BafsPresenter.SetSelectBaf(0);
            BafsPresenter.ReduceBombBafs(1);
        }
        if (BafsPresenter.GetSelectBaf() == 2)
        {
            penguinView.objRigidbody.AddForce(Vector3.down * 800);
            BafsPresenter.SetSelectBaf(0);
            BafsPresenter.ReduceSpringBafs(1);
            ProjectionView.instance.PointProjection();
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

    public IEnumerator SpawnPenguin()
    {
        yield return new WaitForSeconds(0.5f);
        if (BafsPresenter.GetSelectBaf() == 0)
        {
            SpawnPenguinsPresenter.SpawnByLevel(0);
        }
    }
}
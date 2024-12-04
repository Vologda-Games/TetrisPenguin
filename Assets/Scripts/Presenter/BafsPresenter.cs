using UnityEngine;

public class BafsPresenter : MonoBehaviour
{
    public static void Multicolor()
    {
        SetSelectBaf(1);
        if (PenguinsModel.instance.penguinInSpawn != null)
        {
            SetDestroyBaf(PenguinsModel.instance.penguinInSpawn.level);
            Destroy(PenguinsModel.instance.penguinInSpawn.go);
            PenguinsModel.instance.penguinInSpawn = null;
        }
        SpawnPenguinsPresenter.SpawnByLevel(15);
    }

    public static void Spring()
    {
        SetSelectBaf(2);
        if (PenguinsModel.instance.penguinInSpawn != null)
        {
            ProjectionView.instance.RedProjection();
        }
    }

    public static void Bomb()
    {
        SetSelectBaf(3);
        if (PenguinsModel.instance.penguinInSpawn != null)
        {
            SetDestroyBaf(PenguinsModel.instance.penguinInSpawn.level);
            Destroy(PenguinsModel.instance.penguinInSpawn.go);
            PenguinsModel.instance.penguinInSpawn = null;
        }
        SpawnPenguinsPresenter.SpawnByLevel(16);
        Debug.Log("Бомба");
    }

    public static void Tornado()
    {
        for (int i = 0; i < PenguinsModel.instance.penguinViews.Count; i++)
        {
            if (PenguinsModel.instance.penguinViews[i] != null)
            {
                for (int j = 0; j < 5; j++)
                {
                    PenguinsModel.instance.penguinViews[i].objRigidbody.AddForce(new Vector3(-1, 1, 0) * 100);
                }
            }
        }
    }

    public static void Magnet()
    {
        SetSelectBaf(5);
    }

    /// CANCEL
    public static void CancelMulticolor()
    {
        SetSelectBaf(0);
        if (PenguinsModel.instance.penguinInSpawn != null)
        {
            if (PenguinsModel.instance.penguinInSpawn.level == 15)
            {
                Destroy(PenguinsModel.instance.penguinInSpawn.go);
                PenguinsModel.instance.penguinInSpawn = null;
                SpawnPenguinsPresenter.SpawnByLevel(GetDestroyBaf());
                SetDestroyBaf(0);
            }
        }
    }

    public static void CancelSpring()
    {
        SetSelectBaf(0);
        if (PenguinsModel.instance.penguinInSpawn != null)
        {
            PenguinView penguinView = PenguinsModel.instance.penguinInSpawn;
            if (penguinView._strongBlow) penguinView._strongBlow = false;
        }
        ProjectionView.instance.PointProjection();
    }

    public static void CancelBomb()
    {
        SetSelectBaf(0);

    }

    public static void CancelMagnet()
    {
        SetSelectBaf(0);
        if (PenguinsModel.instance.penguinInSpawn.level != GetDestroyBaf())
        {
            Destroy(PenguinsModel.instance.penguinInSpawn.go);
            PenguinsModel.instance.penguinInSpawn = null;
            SpawnPenguinsPresenter.SpawnByLevel(GetDestroyBaf());
            SetDestroyBaf(0);
        }
    }

    /// SET
    public static void SetMulticolorBafs(int value)
    {
        BafsModel.instance.multicolorBafs = value;
        BafsView.instance.RenderCountBafs();
    }

    public static void SetSpringBafs(int value)
    {
        BafsModel.instance.springBafs = value;
        BafsView.instance.RenderCountBafs();
    }

    public static void SetBombBafs(int value)
    {
        BafsModel.instance.bombBafs = value;
        BafsView.instance.RenderCountBafs();
    }

    public static void SetTornadoBafs(int value)
    {
        BafsModel.instance.tornadoBafs = value;
        BafsView.instance.RenderCountBafs();
    }

    public static void SetMagnetBafs(int value)
    {
        BafsModel.instance.magnetBafs = value;
        BafsView.instance.RenderCountBafs();
    }

    public static void SetDestroyBaf(int value)
    {
        BafsModel.instance.destroyBaf = value;
        Debug.Log(value);
    }

    public static void SetSelectBaf(int value)
    {
        BafsModel.instance.selectBaf = value;
    }

    /// ADD
    public static void AddMulticolorBafs(int value)
    {
        BafsModel.instance.multicolorBafs += value;
        BafsView.instance.RenderCountBafs();
    }

    public static void AddSpringBafs(int value)
    {
        BafsModel.instance.springBafs += value;
        BafsView.instance.RenderCountBafs();
    }

    public static void AddBombBafs(int value)
    {
        BafsModel.instance.bombBafs += value;
        BafsView.instance.RenderCountBafs();
    }

    public static void AddTornadoBafs(int value)
    {
        BafsModel.instance.tornadoBafs += value;
        BafsView.instance.RenderCountBafs();
    }

    public static void AddMagnetBafs(int value)
    {
        BafsModel.instance.magnetBafs += value;
        BafsView.instance.RenderCountBafs();
    }

    public static void AddBaffsByNumber(int _numberBaff, int _value)
    {
        switch (_numberBaff)
        {
            case 1:
                AddMulticolorBafs(_value);
                break;
            case 2:
                AddSpringBafs(_value);
                break;
            case 3:
                AddBombBafs(_value);
                break;
            case 4:
                AddTornadoBafs(_value);
                break;
            case 5:
                AddMagnetBafs(_value);
                break;
        }
    }

    /// REDUCE
    public static void ReduceMulticolorBafs(int value)
    {
        BafsModel.instance.multicolorBafs -= value;
        BafsView.instance.RenderCountBafs();
    }

    public static void ReduceSpringBafs(int value)
    {
        BafsModel.instance.springBafs -= value;
        BafsView.instance.RenderCountBafs();
    }

    public static void ReduceBombBafs(int value)
    {
        BafsModel.instance.bombBafs -= value;
        BafsView.instance.RenderCountBafs();
    }

    public static void ReduceTornadoBafs(int value)
    {
        BafsModel.instance.tornadoBafs -= value;
        BafsView.instance.RenderCountBafs();
    }

    public static void ReduceMagnetBafs(int value)
    {
        BafsModel.instance.magnetBafs -= value;
        BafsView.instance.RenderCountBafs();
    }

    /// GET
    public static int GetMulticolorBafs()
    {
        return BafsModel.instance.multicolorBafs;
    }

    public static int GetSpringBafs()
    {
        return BafsModel.instance.springBafs;
    }

    public static int GetBombBafs()
    {
        return BafsModel.instance.bombBafs;
    }

    public static int GetTornadoBafs()
    {
        return BafsModel.instance.tornadoBafs;
    }

    public static int GetMagnetBafs()
    {
        return BafsModel.instance.magnetBafs;
    }

    public static int GetDestroyBaf()
    {
        return BafsModel.instance.destroyBaf;
    }

    public static int GetSelectBaf()
    {
        return BafsModel.instance.selectBaf;
    }

    public static void SetActiveBlackbackgroundBtn()
    {
        if (BafsView.instance.isBlackBackground == true)
        {
            for (int i = 0; i < BafsView.instance._blackBackgroundButtons.Length; i++)
            {
                BafsView.instance._blackBackgroundButtons[i].SetActive(false);
            }
        }
    }
}
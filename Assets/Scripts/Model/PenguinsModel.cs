using System.Collections.Generic;
using UnityEngine;

public class PenguinsModel : MonoBehaviour
{
    public static PenguinsModel instance;
    public List<PenguinObject> penguinObjectsForStart;
    public List<PenguinView> penguinViews;
    public PenguinView penguinInSpawn;

    private void Awake()
    {
        penguinObjectsForStart = new List<PenguinObject>();
        instance = this;
    }

    public List<PenguinObject> GetPenguins()
    {
        List<PenguinObject> penguins = new List<PenguinObject>();
        for (int i = 0; i < penguinViews.Count; i++)
        {
            penguins.Add(new PenguinObject(penguinViews[i].level, penguinViews[i].objTransform.localPosition));
        }
        return penguins;
    }
}

public class SavePenguinsModel
{
    public List<PenguinObject> penguinObjects;
}
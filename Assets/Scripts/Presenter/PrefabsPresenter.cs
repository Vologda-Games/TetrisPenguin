using UnityEngine;

public class PrefabsPresenter
{
    public static GameObject GetPrefabByLevel(int level)
    {
        return PrefabsModel.instance.penguins[level];
        
    }
}

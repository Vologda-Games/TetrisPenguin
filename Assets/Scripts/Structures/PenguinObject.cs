using UnityEngine;

public class PenguinObject
{
    public int levelPenguin;
    public float posXPenguin;
    public float posYPenguin;

    public PenguinObject(int levelPenguin, Vector3 posPenguin)
    {
        this.levelPenguin = levelPenguin;
        posXPenguin = posPenguin.x;
        posYPenguin = posPenguin.y;
    }
}
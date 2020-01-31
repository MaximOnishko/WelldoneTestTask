using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public int ResAtStartup;

    public ResourceSO WoodSO;
    public ResourceSO StoneSO;
    public ResourceSO IronSO;

    //public Sprite defaultSprite;

    public Sprite GetCurrentSprite(Resource res, int lvl)
    {
        //if (res == null)
        //    return defaultSprite;
        if (res is Wood)
        {
            if (lvl == 0)
                return WoodSO.level0;
            if (lvl == 1)
                return WoodSO.level1;
            if (lvl == 2)
                return WoodSO.level2;
        }
        else if(res is Stone)
        {
            if (lvl == 0)
                return StoneSO.level0;
            if (lvl == 1)
                return StoneSO.level1;
            if (lvl == 2)
                return StoneSO.level2;
        }
        else if (res is Iron)
        {
            if (lvl == 0)
                return IronSO.level0;
            if (lvl == 1)
                return IronSO.level1;
            if (lvl == 2)
                return IronSO.level2;
        }

        return null;
    }
}

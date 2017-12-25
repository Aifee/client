using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BrickColor
{
    None = 0,
    White = 1,
    Azure,
    Blue,
    Green,
    Orange,
    Red,
    Rose_e,
    Violet,
    Yellow,
}

public class ResourceManager : LEngine.Singleton<ResourceManager>
{
    private Dictionary<BrickColor, GameObject> brickColors = new Dictionary<BrickColor, GameObject>();

    public GameObject GetBrick(BrickColor colorType)
    {
        if (brickColors.ContainsKey(colorType))
        {
            return brickColors[colorType];
        }
        string colorRes = colorType == BrickColor.Rose_e ? "Rose-e" : colorType.ToString();
        string resPath = string.Format("Bricks/Brick_{0}", colorRes);
        GameObject go = Resources.Load<GameObject>(resPath);
        brickColors.Add(colorType, go);
        return go;
    }
    private Dictionary<int, List<List<int>>> maps = new Dictionary<int, List<List<int>>>();
    public List<List<int>> GetLevel(int level)
    {
        if (maps.ContainsKey(level))
        {
            return maps[level];
        }
        TextAsset asset = Resources.Load<TextAsset>(string.Format("Configs/map{0}", level));
        List<List<int>> mapInfo = new List<List<int>>();
        
        string[] raws = asset.text.Split('\n');
        for(int i = 0; i < raws.Length; i++)
        {
            List<int> mapRank = new List<int>();
            string[] rank = raws[i].Split(',');
            for(int j = 0; j < rank.Length; j++)
            {
                mapRank.Add(int.Parse(rank[j]));
            }
            mapInfo.Add(mapRank);
        }
        maps.Add(level, mapInfo);
        return mapInfo;
    }

}

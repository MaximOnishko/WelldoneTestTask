using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CellsManager : MonoBehaviour
{
    [SerializeField] private List<Cell> cells;

    private ResourceCreater resourceCreater = new ResourceCreater();
    public static GameObject poiterEnterObj;

    public delegate void PointerEnter(Resource collisionRes);
    public static event PointerEnter PointerE;

    private void Start()
    {
        AddCell();
        RandomResourceFill();
    }

    public void InvokePointerE(GameObject _gameObject)
    {
        poiterEnterObj = _gameObject;
        PointerE?.Invoke(_gameObject.GetComponent<Cell>().resource);
    }
    private void AddCell()
    {
        foreach (Transform image in transform)
        {
            cells.Add(image.gameObject.AddComponent<Cell>());
        }
    }

    private void RandomResourceFill()
    {
        for (int i = 0; i < GameManager.Instance.ResAtStartup; i++)
        {
            var j = Random.Range(0, cells.Count);

            if (cells[j].resource == null)
                cells[j].AddResoure(resourceCreater.RandomCreate());
            else
                i--;
        }
    }
    public void AddElement()
    {
        var j = Random.Range(0, cells.Count);

        if (cells[j].resource == null)
            cells[j].AddResoure(resourceCreater.RandomCreate());
        else
        {
            if (cells.FirstOrDefault(x => x.resource == null))
                AddElement();
        }
    }
}   

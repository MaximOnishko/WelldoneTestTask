
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.Collections;

public class Cell : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    private bool _canBeUpgrade;
    private static Resource _selectedResource;
    public static event EventHandler MaxLevelRes;


    private Vector2 _startPos;

    public Resource resource { get; private set; }

    private void Start()
    {
        CellsManager.PointerE += CellsManager_PointerE;
        MaxLevelRes += Cell_MaxLevelRes;
    }

    private void Cell_MaxLevelRes(object sender, EventArgs e)
    {
        var cell = (Cell)sender;
        cell.resource = null;
        cell.VizualizeCell();
    }

    private void CellsManager_PointerE(Resource collisionRes)
    {
        if (collisionRes == null || _selectedResource == null)
            return;

        _canBeUpgrade = compareRes(_selectedResource, collisionRes);
    }

    public void AddResoure(Resource res)
    {
        resource = res;
        VizualizeCell();
    }

    private void VizualizeCell()
    {
        if(resource == null)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            return;
        }

        Sprite sprite = GameManager.Instance.GetCurrentSprite(resource, resource.currentLevel);
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(0).GetComponent<Image>().sprite = sprite;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.GetChild(0).position = Input.mousePosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        transform.GetChild(0).GetComponent<Canvas>().sortingOrder = 2;
        _startPos = transform.position;

        _selectedResource = resource;
        _canBeUpgrade = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.GetChild(0).GetComponent<Canvas>().sortingOrder = 1;
        transform.GetChild(0).position = _startPos;

        if (_canBeUpgrade)
            Upgrade();

    }

    private bool compareRes(Resource selected,Resource colliderRes)
    {
        if (selected != colliderRes)
            if (selected.GetType() == colliderRes.GetType())
                if (selected.currentLevel == colliderRes.currentLevel)
                    return true;
        return false;
    }

    private void Upgrade()
    {
        resource = null;
        VizualizeCell();

        var cell = CellsManager.poiterEnterObj.GetComponent<Cell>();
        cell.resource.UpgradeItem();
        cell.VizualizeCell();
        if (cell.resource.currentLevel == 2)
            StartCoroutine(CauseEvent(cell));
    }
    IEnumerator CauseEvent(Cell cell)
    {
        yield return new WaitForSeconds(0.3f);
        MaxLevelRes?.Invoke(cell, null);
    }
}

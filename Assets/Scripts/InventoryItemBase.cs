using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemBase : MonoBehaviour, IInventoryItem
{
    // Start is called before the first frame update
    public virtual string Name
    {
        get {
            return "_base_item";
        }
    }

    public Sprite _Image;
    public Sprite Image
    {
        get
        {
            return _Image;
        }
    }


    // Update is called once per frame
    public virtual void OnDrop()
    {
        RaycastHit hit = new RaycastHit();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1000))
        {
            gameObject.SetActive(true);
            gameObject.transform.position = hit.point;
            gameObject.transform.eulerAngles = dropRotation;
        }
    }
    public virtual void OnPickup()
    {
        gameObject.SetActive(false);
    }
    public virtual void OnUse()
    {
        transform.localPosition = pickPosition;
        transform.localEulerAngles = pickRotation;
    }

    public Vector3 pickPosition;
    public Vector3 pickRotation;
    public Vector3 dropRotation;
}

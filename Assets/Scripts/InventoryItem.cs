using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler,IPointerEnterHandler,IPointerExitHandler{
    [Header("UI")]
    public Image image;
    public Text countText;
    [HideInInspector] public Item item;
    [HideInInspector] public int count=1;
    [HideInInspector] public Transform parentAfterDrag;
    public bool canBeDestroyed=false;
    public Button button;
    private void Start(){
        InitialiseItem(item);
    }
    public void InitialiseItem(Item newItem){
        item = newItem;
        image.sprite= newItem.image;
        RefreshCount();
    }
    public void RefreshCount(){
        countText.text =count.ToString();
        bool textActive = count>1;
        countText.gameObject.SetActive(textActive);
    }
    public void OnBeginDrag(PointerEventData eventData){
        if(GameManager.instance.inventoryManager.normalMode){
            image.raycastTarget=false;
            parentAfterDrag = transform.parent;
            transform.SetParent(transform.root);
            transform.SetAsLastSibling();
        }
    }

    public void OnDrag(PointerEventData eventData){
        if(GameManager.instance.inventoryManager.normalMode) transform.position= Input.mousePosition;

    }

    public void OnEndDrag(PointerEventData eventData){
        if(GameManager.instance.inventoryManager.normalMode){
            image.raycastTarget=true;
            transform.SetParent(parentAfterDrag);
        }
    }
    public void OnPointerEnter(PointerEventData eventData){
        if(!GameManager.instance.inventoryManager.normalMode)
        if(button.name.Split()[0].Equals("Sell") && item.type.Equals(Item.ItemType.Fish)) button.gameObject.SetActive(true);
        else if(button.name.Split()[0].Equals("Buy")) button.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData){
        if(!GameManager.instance.inventoryManager.normalMode) button.gameObject.SetActive(false);
    }
    void OnMouseDown() {
        if(canBeDestroyed) Destroy(this.gameObject);
    }
    // private void Update() {
    //     print("Update");
    //     if(canBeDestroyed && Input.GetMouseButtonDown(0)) Destroy(this.gameObject);
    // }
}

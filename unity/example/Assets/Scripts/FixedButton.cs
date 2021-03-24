using UnityEngine;
using UnityEngine.EventSystems;

public class FixedButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    [HideInInspector]
    public bool Pressed;


    public void OnPointerDown(PointerEventData eventData)
    {
        Pressed = true;
        print("Pressed");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Pressed = false;
        print("Pressed false");
    }

   
}

using UnityEngine;

public class InputsManager : MonoBehaviour
{
    private int CardMask;
    
    private void Awake()
    {
        CardMask = 1 << LayerMask.NameToLayer(Configs.CARD_LAYER);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePosition2D = new Vector2(mousePosition.x, mousePosition.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePosition2D, Vector2.zero, float.MaxValue, CardMask);

            if (hit.collider)
            {
                Core.Events.OnClickCard?.Invoke(hit.collider.name);
            }
        }
    }
}

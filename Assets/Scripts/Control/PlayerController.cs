using UnityEngine;
using RPG.Movement;
using RPG.Camera;
namespace RPG.Control
{
    public class PlayerController : MonoBehaviour
{
    Mover move;

    private void Start() 
    {
        move = GetComponent<Mover>();
    }
    private void Update() 
    {
        if (Input.GetMouseButton(0)) 
        {
            MoveToCursor();
        }
    }
    private void MoveToCursor()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool hasHit = Physics.Raycast(ray, out hit);
        if (hasHit)
        {
            move.MoveTo(hit.point);
        }
    }
}
}


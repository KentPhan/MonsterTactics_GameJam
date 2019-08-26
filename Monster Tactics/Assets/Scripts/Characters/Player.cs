using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Classes;
using Assets.Scripts.Constants;
using Assets.Scripts.Managers;
using UnityEngine;
using UnityEngine.AI;


public class Player : MonoBehaviour
{
    // Exposed properties
    [SerializeField] [Range(1, 20)] private int actionPointLimit = 6; public int ActionPointLimit => actionPointLimit;


    // Members
    private NavMeshAgent agent;
    private Square currentSquare;
    public Square CurrentSquare => currentSquare;

    // Start is called before the first frame update
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        FindAndUpdateSquare();
        CanvasManager.Instance.UIInfoPanel.UpdateActionPointTotalValue(actionPointLimit);
    }

    private void Update()
    {
    }

    public void FindAndUpdateSquare()
    {
        // Raycast downward to find current square
        bool squareFound = true;
        int squareMask = LayerMask.GetMask(Layers.GRID);
        RaycastHit hitInfo;
        if (Physics.Raycast(this.transform.position, Vector3.down, out hitInfo, 5000, squareMask,
            QueryTriggerInteraction.UseGlobal))
        {
            this.currentSquare = hitInfo.transform.GetComponent<Square>();
            if (this.currentSquare == null)
            {
                squareFound = false;
            }
        }
        else
        {
            squareFound = false;
        }

        if (!squareFound)
        {
            Debug.LogError("No Square found below the player via raycast");
        }
    }


}

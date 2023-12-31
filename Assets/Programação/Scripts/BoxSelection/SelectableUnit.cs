using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class SelectableUnit : MonoBehaviour
{
    private NavMeshAgent Agent;
    [SerializeField]
    private SpriteRenderer SelectionSprite;

    private void Awake()
    {
        SelectionManager.Instance.AvailableUnits.Add(this);
        Agent = GetComponent<NavMeshAgent>();
    }

    public void MoveTo(Vector3 Position)
    {
        Agent.SetDestination(Position);
    }

    public void OnSelected() //coisas q acontecem ao clicar na unit
    {
        SelectionSprite.gameObject.SetActive(true);
    }

    public void OnDeselected()
    {
        SelectionSprite.gameObject.SetActive(false);
    }
}

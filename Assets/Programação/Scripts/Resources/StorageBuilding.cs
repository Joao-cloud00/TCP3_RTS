using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageBuilding : StaticUnit, IResourcesReceiver
{
    [SerializeField]
    private ResourceType[] _acceptedResources;

    public ResourceType[] AcceptedResources
    {
        get { return null; }
    }

    public void ReceiveResource(int amount, ResourceType resource)
    {
        //envia os recursos para o GameManager
    }

    public bool AcceptResource(ResourceType resource)
    {
        foreach (ResourceType acceptedResource in _acceptedResources)
        {
            if (resource == acceptedResource)
            {
                return true;
            }
        }
        return false;
    }
}

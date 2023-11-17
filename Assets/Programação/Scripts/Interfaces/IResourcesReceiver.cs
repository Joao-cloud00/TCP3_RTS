using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IResourcesReceiver
{
    ResourceType[] AcceptedResources
    {
        get; 
    }

    void ReceiveResource(int amount,ResourceType resource);
    bool AcceptResource(ResourceType resource);

}

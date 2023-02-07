using UnityEngine;
using Zenject;

public class BootStrapInstaller : MonoInstaller
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform startTransform;
    public override void InstallBindings()
    {
        
    }
}
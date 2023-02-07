using HurricaneVR.Framework.Weapons;
using UnityEngine;
using Zenject;
using Zenject.SpaceFighter;

public class SceneInstaller : MonoInstaller
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform startTransform;

    public override void InstallBindings()
    {
        PlayerData player = Container.InstantiatePrefabForComponent<PlayerData>(playerPrefab, startTransform.position, 
                Quaternion.identity, null);
        Container.Bind<PlayerData>().FromInstance(player).AsSingle();

        //PistolController pistol = Container.InstantiatePrefabForComponent<PistolController>(pistolPrefab, startTransformPistol); 
        
    }
}
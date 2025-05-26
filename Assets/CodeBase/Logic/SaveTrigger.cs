using System;
using Assets.CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.SaveLoad;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Assets.CodeBase.Logic
{
    public class SaveTrigger : MonoBehaviour
    {
        [SerializeField] public Button _button;
        private ISaveLoadService _saveLoadService;
        

        private void Awake()
        {
            _saveLoadService = AllServices.Container.Single<ISaveLoadService>();
            _button.onClick.AddListener(Save);
        }

        private void Save()
        {
            _saveLoadService.SaveProgress();
            Debug.Log("Saved Successfully");
        }
    }
}
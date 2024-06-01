using System;
using UnityEngine;
using UnityEngine.UI;

namespace UIModule.Panels.PausePanelModule
{
    public class PausePanel : BasePanel
    {
        [SerializeField] private Button _pauseButton;
        [SerializeField] private Button _resetButton;

        public void Initialize(Action OnPauseButtonClick, Action OnResetButtonClick)
        {
            _resetButton.gameObject.SetActive(false);
            
            _pauseButton.onClick.AddListener(() => OnPauseButtonClick?.Invoke());
            _resetButton.onClick.AddListener(() => OnResetButtonClick?.Invoke());
        }

        public void ActivatePauseMenu(bool isActive)
        {
            _resetButton.gameObject.SetActive(isActive);
        }
    }
}
using System;
using UIModule.Panels.ChangeIndexPanelModule;
using UIModule.Panels.IntroductionPanelModule;
using UIModule.Panels.PausePanelModule;
using UnityEngine;

namespace UIModule
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private IntroductionPanel _introductionPanel;
        [SerializeField] private PausePanel _pausePanel;
        [SerializeField] private ChangeIndexPanel _changeIndexPanel;

        public void Initialize(Action OnPauseButtonClick, Action OnResetButtonClick, 
            Action OnIncreaseButtonClick, Action OnDecreaseButtonClick)
        {
            _pausePanel.Initialize(OnPauseButtonClick, OnResetButtonClick);
            _changeIndexPanel.Initialize(OnIncreaseButtonClick, OnDecreaseButtonClick);
        }

        public void ActivateIntroductionPanel()
        {
            _introductionPanel.Activate();
        }
        
        public void ActivateUI()
        {
            _introductionPanel.Deactivate();
            _pausePanel.Activate();
            _changeIndexPanel.Activate();
        }

        public void DeactivateUI()
        {
            _pausePanel.Deactivate();
            _changeIndexPanel.Deactivate();
        }

        public void SetPause(bool isPaused)
        {
            _changeIndexPanel.SetInteractable(!isPaused);
            _pausePanel.ActivatePauseMenu(isPaused);
        }
    }
}
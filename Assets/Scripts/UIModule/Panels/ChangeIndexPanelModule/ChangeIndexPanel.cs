using System;
using UnityEngine;
using UnityEngine.UI;

namespace UIModule.Panels.ChangeIndexPanelModule
{
    public class ChangeIndexPanel : BasePanel
    {
        [SerializeField] private Button _increaseButton;
        [SerializeField] private Button _decreaseButton;

        public void Initialize(Action OnIncreaseButtonClick, Action OnDecreaseButtonClick)
        {
            _increaseButton.onClick.AddListener(() => OnIncreaseButtonClick?.Invoke());
            _decreaseButton.onClick.AddListener(() => OnDecreaseButtonClick?.Invoke());
        }

        public void SetInteractable(bool isInteractable)
        {
            _increaseButton.interactable = isInteractable;
            _decreaseButton.interactable = isInteractable;
        }
    }
}
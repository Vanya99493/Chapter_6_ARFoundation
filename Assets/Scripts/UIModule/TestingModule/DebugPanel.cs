using TMPro;
using UnityEngine;

namespace UIModule.TestingModule
{
    public class DebugPanel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _debugText;

        public void ShowMessage(string message)
        {
            _debugText.text = message;
        }

        public void AddMessage(string message)
        {
            _debugText.text = _debugText.text + "\n" + message;
        }
    }
}
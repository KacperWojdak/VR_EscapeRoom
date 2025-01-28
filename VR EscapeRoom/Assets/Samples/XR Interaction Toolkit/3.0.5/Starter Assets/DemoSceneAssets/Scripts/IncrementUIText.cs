using UnityEngine.UI;
using static PlasticPipe.PlasticProtocol.Client.ConnectionCreator.PlasticProtoSocketConnection;

namespace UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets
{
    public class IncrementUIText : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("The Text component this behavior uses to display the value.")]
        private Text m_Text;

        public Text text
        {
            get => m_Text;
            set => m_Text = value;
        }

        private int m_Count;

        protected void Awake()
        {
            if (m_Text == null)
                Debug.LogWarning("Missing required Text component reference. Use the Inspector window to assign which Text component to increment.", this);
        }

        /// <summary>
        /// Increment the value and update the UI.
        /// </summary>
        public void IncrementText()
        {
            m_Count = (m_Count + 1) % 10;
            UpdateText();
            ResetTextColor();
        }

        /// <summary>
        /// Decrement the value and update the UI.
        /// </summary>
        public void DecrementText()
        {
            m_Count = (m_Count - 1 + 10) % 10;
            UpdateText();
            ResetTextColor();
        }

        /// <summary>
        /// Update the Text component with the current value.
        /// </summary>
        private void UpdateText()
        {
            if (m_Text != null)
                m_Text.text = m_Count.ToString();
        }

        /// <summary>
        /// Reset the text color to white.
        /// </summary>
        private void ResetTextColor()
        {
            if (m_Text != null)
            {
                m_Text.color = Color.white;
            }
        }
    }
}

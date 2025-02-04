using UnityEngine.UI;

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

        public void IncrementText()
        {
            m_Count = (m_Count + 1) % 10;
            UpdateText();
            ResetTextColor();
        }

        public void DecrementText()
        {
            m_Count = (m_Count - 1 + 10) % 10;
            UpdateText();
            ResetTextColor();
        }

        private void UpdateText()
        {
            if (m_Text != null)
                m_Text.text = m_Count.ToString();
        }

        private void ResetTextColor()
        {
            if (m_Text != null)
                m_Text.color = Color.white;
        }
    }
}

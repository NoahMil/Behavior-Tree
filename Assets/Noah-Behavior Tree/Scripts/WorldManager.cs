using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

namespace Noah_Behavior_Tree.Scripts
{
    public class ChangeCameraBackground : MonoBehaviour
    {
        
        [SerializeField] private  Renderer sunRenderer;
        
        [SerializeField] private  Light sunLight;

        [SerializeField] private Color MoonlightColor;
        [SerializeField] private Color DaylightColor;

        [SerializeField] private Color NightBackgroundColor; 
        [SerializeField] private  Color DayBackgroundColor;
        
        [SerializeField] private Color MoonColor; 
        [SerializeField] private  Color SunColor;
        
        
        
        void Start()
        {
            if (Camera.main != null) Camera.main.backgroundColor = DayBackgroundColor;
        }

        private void Update()
        {
            foreach (AnimalAI ai in FindObjectsOfType<AnimalAI>())
            {
                if (ai.IsSleepy)
                {
                    ChangeBackgroundColor(NightBackgroundColor);
                    ChangeSunColor(MoonColor);
                    ChangeLightColor(MoonlightColor);
                }
                else
                {
                    ChangeBackgroundColor(DayBackgroundColor);
                    ChangeSunColor(SunColor);
                    ChangeLightColor(DaylightColor);
                }
            }
        }

        private void ChangeBackgroundColor(Color newColor)
        {
            if (Camera.main != null) Camera.main.backgroundColor = newColor;
        }

        private void ChangeSunColor(Color newColor)
        {
            if (sunRenderer != null)
            {
                sunRenderer.material.color = newColor;
            }
        }

        private void ChangeLightColor(Color newColor)
        {
            sunLight.color = newColor;
        }
    }
}
using UnityEngine;

namespace UserInterface.FX.Image
{
    public class ImageEvent : MonoBehaviour
    {
        public delegate void OnEvent();
        public static OnEvent onEnable, onDisable;

        public static void Begin()
        {
            if (onEnable != null) onEnable();
        }
        public static void End()
        {
            if (onDisable != null) onDisable();
        }
    }
}
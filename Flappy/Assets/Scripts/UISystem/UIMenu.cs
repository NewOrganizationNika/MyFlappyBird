using UnityEngine;
using UnityEngine.Events;

namespace UISystem
{
    public class UIMenu : MonoBehaviour
    {
        [SerializeField] private GameObject menu = null, shop = null, scoreCanvas = null;

        public void _StartGame()
        {
            menu.SetActive(false);
            scoreCanvas.SetActive(true);
            Time.timeScale = 1;
        }

        public void _OpenShop()
        {
            menu.SetActive(false);
            shop.SetActive(true);
        }

        public void _OpenMainMenu()
        {
            menu.SetActive(true);
            shop.SetActive(false);
            scoreCanvas.SetActive(false);
        }
    }
}
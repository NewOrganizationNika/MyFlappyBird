using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UISystem
{
    //Changeable means the gameObjects which would have options to change the skin
    //Skin means the visual representation of the gameObject
    //Set is group of objects which are used with same purpose
    //The Container is parent transform for desired instantiation of objects
    public class UISkinChanger : MonoBehaviour
    {
        [SerializeField] private GameObject buttonPrefab = null;

        [SerializeField] private GameObject changeableContainer = null, skinContainer = null;

        [SerializeField] private GameObject changeableSet = null;

        private GameObject selectedOne; //selected obj from changeableSet

        private void Start()
        {
            var tempName = new List<string>();
            tempName.Clear();

            GameObject tempButton = null;

            foreach (var childWithSpriteRenderer in changeableSet.GetComponentsInChildren<SpriteRenderer>())
            {
                if (tempName.Exists(tempMatch => tempMatch.Equals(childWithSpriteRenderer.name)))
                {
                    if (tempButton != null)
                        tempButton.GetComponent<Button>().onClick
                            .AddListener(() => selectedOne = childWithSpriteRenderer.gameObject);
                    continue;
                }

                var childButton = Instantiate(buttonPrefab, changeableContainer.transform);
                childButton.GetComponent<Image>().color = new Color(159, 0, 255, 40);

                childButton.GetComponentInChildren<Text>().text = childWithSpriteRenderer.name;
                childButton.GetComponent<Button>().onClick
                    .AddListener(() => selectedOne = childWithSpriteRenderer.gameObject);

                tempButton = childButton;
                tempName.Add(childWithSpriteRenderer.name);
            }

            //buttonPrefab.GetComponentInChildren<Text>().text = ""; //Why Is this Line Necessary?

            selectedOne = changeableSet.GetComponentInChildren(typeof(SpriteRenderer)).gameObject;
            var sprites = Resources.LoadAll<Sprite>("Skins");
            foreach (var sprite in sprites)
            {
                var skinButton = Instantiate(buttonPrefab, skinContainer.transform);
                skinButton.GetComponent<Image>().sprite = sprite;
                skinButton.GetComponent<Button>().onClick.AddListener(() =>
                    selectedOne.GetComponent<SpriteRenderer>().sprite = skinButton.GetComponent<Image>().sprite);
            }
        }
    }
}
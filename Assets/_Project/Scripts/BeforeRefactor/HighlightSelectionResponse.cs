using UnityEngine;

namespace BeforRefactor
{
    internal class HighlightSelectionResponse : MonoBehaviour, ISelectionResponse
    {
        [SerializeField] public Material highlightMaterial;
        [SerializeField] public Material defaultMaterial;


        public void OnDeselected(Transform selection)
        {
            var selectionRenderer = selection.GetComponent<Renderer>();
            if (selectionRenderer != null)
            {
                selectionRenderer.material = this.defaultMaterial;
            }
        }

        public void OnSelected(Transform selection)
        {
            var selectionRenderer = selection.GetComponent<Renderer>();
            if (selectionRenderer != null)
            {
                selectionRenderer.material = this.highlightMaterial;
            }
        }
    }
}
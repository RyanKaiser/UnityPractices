using UnityEngine;

namespace BeforRefactor
{
    public class SelectionManager : MonoBehaviour
    {
        [SerializeField] private string selectableTag = "Selectable";

        private Transform _selection;
        private HighlightSelectionResponse _selectionResponse;

        private void Update()
        {
            if (_selection != null)
            {
                _selectionResponse.OnDeselected(_selection);
            }

            #region MyRegion

            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            _selection = null;
            if (Physics.Raycast(ray, out var hit))
            {
                var selection = hit.transform;
                if (selection.CompareTag(selectableTag))
                {
                    _selection = selection;
                }
            }

            #endregion

            if (_selection != null)
            {
                _selectionResponse.OnSelected(_selection);
            }
        }
    }

    internal class HighlightSelectionResponse : MonoBehaviour
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
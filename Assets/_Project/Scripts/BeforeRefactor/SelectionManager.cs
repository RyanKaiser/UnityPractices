using UnityEngine;

namespace BeforRefactor
{
    public class SelectionManager : MonoBehaviour
    {
        [SerializeField] private string selectableTag = "Selectable";

        private Transform _selection;
        private ISelectionResponse _selectionResponse;

        private void Awake()
        {
            _selectionResponse = GetComponent<ISelectionResponse>();
        }
        
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
}
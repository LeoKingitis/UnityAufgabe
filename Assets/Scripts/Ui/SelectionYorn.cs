
using UnityEngine;
using UnityEngine.UI;

public class SelectionYorn : MonoBehaviour
{
   [SerializeField] private RectTransform[] options;
   private RectTransform rect;
   private int currentPosition;

   private void Awake()
   {
      rect = GetComponent<RectTransform>();
   }

   private void Update()      //change the position of the selection yorn
   {
      if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) )
      {
         ChangePosition(-1);
      }
      else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
      {
         ChangePosition(1);
      }

      if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.E))
      {
         Interact();
      }
   }

   private void ChangePosition(int _change)
   {

      if (currentPosition < 0)
      {
         currentPosition = options.Length - 1;
      }
      else if (currentPosition > options.Length -1)
      {
         currentPosition = 0;
      }
      currentPosition += _change;
      rect.position = new Vector3(rect.position.x, options[currentPosition].position.y, 0); // assign the y position of the current position to the yorn

   }

   private void Interact()
   {
      options[currentPosition].GetComponent<Button>().onClick.Invoke();
   }
}

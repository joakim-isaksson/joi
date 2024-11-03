using UnityEngine;

namespace Joi.VirtualInputs.Samples.VirtualInputSample
{
    public class VirtualInputSampleController : MonoBehaviour
    {
       private void Update()
        {
            var normalizedInput = new Vector3(VirtualInput.GetAxisRaw("Horizontal"), VirtualInput.GetAxisRaw("Vertical"), 0).normalized;
            transform.position += normalizedInput * Time.deltaTime;
            
            GetComponent<SpriteRenderer>().color = VirtualInput.GetButton("Jump") ? Color.green : Color.white;
        }
    }
}

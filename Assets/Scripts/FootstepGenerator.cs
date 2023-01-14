using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarterAssets
{
    public class FootstepGenerator : MonoBehaviour
    {
        [SerializeField] List<AudioClip> footstepSoundsConcrete = new List<AudioClip>();
        [SerializeField] List<AudioClip> footstepSoundsGround = new List<AudioClip>();
        [SerializeField] private float baseStepDelay = 3f;
        [SerializeField] private float fastSpeedDelay = 1.5f;
        [SerializeField] private AudioSource audioSource = default;
        [SerializeField] private Camera mainCamera;
        [SerializeField] private float rayCastDepth = 4f;

        private bool canPlaySound = true;
        private FirstPersonController fspController = null;

        Rigidbody playerRB = null;

        void Start()
        {
            fspController = GetComponent<FirstPersonController>();
            playerRB = GetComponent<Rigidbody>();
            
        }

        void Update()
        {
            if (fspController.GetSpeed() > 0 && canPlaySound && fspController.Grounded)
            {
                canPlaySound = false;
                if (mainCamera != null)
                {
                    if (Physics.Raycast(mainCamera.transform.position, Vector3.down, out RaycastHit hit, rayCastDepth))
                    {
                        switch (hit.transform.gameObject.layer)
                        {
                            case 6:
                                audioSource.PlayOneShot(footstepSoundsConcrete[Random.Range(0, footstepSoundsConcrete.Count)]);
                                break;
                            default:
                                audioSource.PlayOneShot(footstepSoundsGround[Random.Range(0, footstepSoundsGround.Count)]);
                                break;
                        }
                    }
                }
                else
                {
                    Logger.Log("mainCamera is null");
                }

                if (fspController.IsSprinting())
                {
                    StartCoroutine(nameof(SoundDelay), fastSpeedDelay);
                }
                else
                {
                    StartCoroutine(nameof(SoundDelay), baseStepDelay);
                }
            }
        }

        IEnumerator SoundDelay(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            canPlaySound = true;
        }
    }


}

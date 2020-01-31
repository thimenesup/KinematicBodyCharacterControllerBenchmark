using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StressTest : MonoBehaviour
{
	public GameObject fps;
	Text fpsText;

	public uint count = 0;
    public GameObject character;

    public List<CharacterController> controllers;

    void Start()
    {
		fpsText = fps.GetComponent<Text>();

        for (int i = 0; i < count; ++i)
        {
            var newCharacter = Instantiate(character, new Vector3(0,1, -i * 3), Quaternion.identity);

            var controller = newCharacter.GetComponent<CharacterController>();
            controllers.Add(controller);
        }
    }

    void Update()
    {
        for (int i = 0; i < count; ++i)
        {
            controllers[i].Move(Vector3.forward * Time.deltaTime);
        }

		float fps = 1.0f/Time.deltaTime;
		fpsText.text = string.Format("{0}FPS with {1} bodies", fps, count);

	}
}

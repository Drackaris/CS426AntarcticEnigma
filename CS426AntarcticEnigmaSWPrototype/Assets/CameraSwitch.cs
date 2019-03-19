using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
	public GameObject PlayerCamera;
	public GameObject ComputerCamera;

	public int CamMode;
	// Start is called before the first frame update
	void Start()
	{
		CamMode = 0;
		PlayerCamera.SetActive(true);
		ComputerCamera.SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void GoToPlayerCamera()
	{
		PlayerCamera.SetActive(true);
		ComputerCamera.SetActive(false);
	}

	//IEnumerator PlayerCamSwitch()
	//{
	//	yield return new WaitForSeconds(0.01f);
	//	PlayerCamera.SetActive(true);
	//	ComputerCamera.SetActive(false);
	//}

	public void GoToComputerCamera()
	{
		PlayerCamera.SetActive(false);
		ComputerCamera.SetActive(true);
	}

	//IEnumerator ComputerCamSwitch()
	//{
	//	yield return new WaitForSeconds(0.01f);
	//	PlayerCamera.SetActive(true);
	//	ComputerCamera.SetActive(false);
	//}
}

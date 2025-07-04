using System;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSoundsButton : MonoBehaviour
{
	private bool isOff
	{
		get
		{
			GGPlayerSettings instance = GGPlayerSettings.instance;
			if (this.soundType != ToggleSoundsButton.SoundType.Music)
			{
				return instance.isSoundFXOff;
			}
			return instance.isMusicOff;
		}
		set
		{
			GGPlayerSettings instance = GGPlayerSettings.instance;
			if (this.soundType == ToggleSoundsButton.SoundType.Music)
			{
				instance.isMusicOff = value;
				return;
			}
			instance.isSoundFXOff = value;
		}
	}

	private void OnEnable()
	{
		this.UpdateVisualState();
	}

	public void ButtonCallback_OnClick()
	{
		this.isOff = !this.isOff;
		if (this.name == "Music_Line")
		{
			this.UpdateVisualStateMusic();
		}
		if (this.name == "Sounds_Line")
		{
			this.UpdateVisualStateSound();
		}
	}

	private void UpdateVisualStateMusic()
	{
		bool flag = !this.isOff;
		Music.SetActive(flag);
		GGUtil.Hide(this.widgetsToHide);
		if (flag)
		{
			this.onStyle.Apply();
			return;
		}
		this.offStyle.Apply();
	}

	private void UpdateVisualStateSound()
	{
		bool flag = !this.isOff;
		Sound.SetActive(flag);
		GGUtil.Hide(this.widgetsToHide);
		if (flag)
		{
			this.onStyle.Apply();
			return;
		}
		this.offStyle.Apply();
	}

	private void UpdateVisualState()
	{
		bool flag = !this.isOff;
		GGUtil.Hide(this.widgetsToHide);
		if (flag)
		{
			this.onStyle.Apply();
			return;
		}
		this.offStyle.Apply();
	}
	[SerializeField]
	private ToggleSoundsButton.SoundType soundType;

	[SerializeField]
	private List<Transform> widgetsToHide = new List<Transform>();

	[SerializeField]
	private VisualStyleSet onStyle = new VisualStyleSet();

	[SerializeField]
	private VisualStyleSet offStyle = new VisualStyleSet();

	public enum SoundType
	{
		Music,
		SoundFx
	}

	public GameObject Music;
	public GameObject Sound;
}

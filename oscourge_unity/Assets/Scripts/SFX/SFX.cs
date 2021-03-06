﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{

	public AudioSource jump1,jump2;
	public AudioSource run;
	public AudioSource explosion;
	public AudioSource hurt;
	public AudioSource teleport;
	public AudioSource button;
	public AudioSource click;
	public AudioSource music;
	public AudioSource menuMusic;
    public AudioSource knightRun;
    public AudioSource destruction;



    public void destructionSound()
    {
        if (!destruction.isPlaying)
        {
            destruction.Play();
        }
    }

    public void KnightRunSound()
    {

        if (!knightRun.isPlaying)
        {
            knightRun.Play();
        }
    }

    public void KnightRunStop()
    {

            knightRun.Stop();
        
    }

    public void JumpSound1(){
		jump1.Play();
	}

	public void JumpSound2(){
		jump2.Play();
	}


	public void RunSound(){
		if(!run.isPlaying){
			run.Play();
		}
	}

	public void RunStop(){
		run.Stop();
	}

	public void ExplosionSound(){
		explosion.Play();
	}

	public void HurtSound(){
		hurt.Play();
	}

	public void TeleportSound(){
		teleport.Play();
	}

	public void ButtonSound(){
		button.Play();
	}
    public void ClickSound()
    {
        click.Play();
    }
    public void Music(){
		music.Play();
	}

	public void MusicStop(){
		music.Stop();
	}

	public void MenuMusic(){
		menuMusic.Play();
	}

	public void MenuMusicStop(){
		menuMusic.Stop();
	}
}

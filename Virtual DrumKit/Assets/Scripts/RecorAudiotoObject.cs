using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;

public class RecorAudiotoObject : MonoBehaviour
{
	private AudioClip ac;
	public GameObject cdprefab;
	private GameObject cd;
	public GameObject Creationpoint;
	private CD cdscript;
	private AudioClip audioc;
	private int outputRate = 44100;
	private String fileName;
	private int headerSize = 44;
	private bool recOutput;
	private FileStream fileStream;
	private GameObject Recorder;
	private Recorder rec;

	void Awake()
	{
	}

	void Start()
	{
		Recorder = GameObject.Find("Recorder");
		rec = Recorder.GetComponent<Recorder>(); 
		fileName = Application.persistentDataPath + "/recording.wav";
		print("lololol"+Application.persistentDataPath);
	}

	void Update()
	{

		if (rec.recording)
		{
			print("rec");
			if (recOutput == false)
			{
				StartWriting(fileName);
				recOutput = true;
			}
			else
			{
				recOutput = false;
				WriteHeader();
				print("rec stop");
				cd = (GameObject)Instantiate (cdprefab, Creationpoint.transform.position, Creationpoint.transform.rotation);
				cdscript = (CD)cd.GetComponent<CD>();
				cdscript.setpath (fileName);
				print (cdscript.getpath());
				WWW www = new WWW ("file://"+fileName);
				while (!www.isDone) {
				}
				AudioClip audioclip = www.GetAudioClip (false);
				AudioSource lmnop = cd.GetComponent<AudioSource> ();
				lmnop.clip=audioclip;
				print ("done");
			}
		}
	}

	void StartWriting(String name)
	{
		fileStream = new FileStream(name, FileMode.Create);
		byte emptyByte = new byte();

		for (int i = 0; i < headerSize; i++)
		{
			fileStream.WriteByte(emptyByte);
		}

	}

	void OnAudioFilterRead(float[] data, int channels)
	{
		if (recOutput)
		{
			ConvertAndWrite(data);
		}
	}

	void ConvertAndWrite(float[] dataSource)
	{

		Int16[] intData = new Int16[dataSource.Length];

		Byte[] bytesData = new Byte[dataSource.Length * 2];


		int rescaleFactor = 32767; 

		for (int i = 0; i < dataSource.Length; i++)
		{
			intData[i] = (short)(dataSource[i] * rescaleFactor);
			Byte[] byteArr = new Byte[2];
			byteArr = BitConverter.GetBytes(intData[i]);
			byteArr.CopyTo(bytesData, i * 2);
		}

		fileStream.Write(bytesData, 0, bytesData.Length);
	}

	void WriteHeader()
	{

		fileStream.Seek(0, SeekOrigin.Begin);

		Byte[] riff = System.Text.Encoding.UTF8.GetBytes("RIFF");
		fileStream.Write(riff, 0, 4);

		Byte[] chunkSize = BitConverter.GetBytes(fileStream.Length - 8);
		fileStream.Write(chunkSize, 0, 4);

		Byte[] wave = System.Text.Encoding.UTF8.GetBytes("WAVE");
		fileStream.Write(wave, 0, 4);

		Byte[] fmt = System.Text.Encoding.UTF8.GetBytes("fmt ");
		fileStream.Write(fmt, 0, 4);

		Byte[] subChunk1 = BitConverter.GetBytes(16);
		fileStream.Write(subChunk1, 0, 4);

		UInt16 two = 2;
		UInt16 one = 1;

		Byte[] audioFormat = BitConverter.GetBytes(one);
		fileStream.Write(audioFormat, 0, 2);

		Byte[] numChannels = BitConverter.GetBytes(two);
		fileStream.Write(numChannels, 0, 2);

		Byte[] sampleRate = BitConverter.GetBytes(outputRate);
		fileStream.Write(sampleRate, 0, 4);

		Byte[] byteRate = BitConverter.GetBytes(outputRate * 4);

		fileStream.Write(byteRate, 0, 4);

		UInt16 four = 4;
		Byte[] blockAlign = BitConverter.GetBytes(four);
		fileStream.Write(blockAlign, 0, 2);

		UInt16 sixteen = 16;
		Byte[] bitsPerSample = BitConverter.GetBytes(sixteen);
		fileStream.Write(bitsPerSample, 0, 2);

		Byte[] dataString = System.Text.Encoding.UTF8.GetBytes("data");
		fileStream.Write(dataString, 0, 4);

		Byte[] subChunk2 = BitConverter.GetBytes(fileStream.Length - headerSize);
		fileStream.Write(subChunk2, 0, 4);

		fileStream.Close();

	}
}




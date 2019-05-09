using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class TopScorer : MonoBehaviour {

	public Text uiScoreBox;

	public TextAsset jsonScore;
	int totalScores = 5; 

	public Scores score;

	// Use this for initialization
	void Start () {
		//score = JsonUtility.FromJson<Scores>(jsonScore.text);
		
		StartCoroutine(loadStreamingAsset("ScoreBoard1.json"));
		//WriteScore();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void WriteScore(){
		uiScoreBox.text = "";

		for(int i = 0; i < totalScores; i++){
			uiScoreBox.text += (score.names[i] + " - " + score.values[i] + '\n');
		}

	}

	IEnumerator LoadSkin(FileInfo jsonFile)
	{
		
		if (jsonFile.Name.Contains("meta")) 
		{
			yield break;
		}
		else 
		{
			string jsonFilePath = jsonFile.FullName.ToString();
			string url = string.Format("file://{0}", jsonFilePath);
			WWW www = new WWW(url);
			yield return www;
			//score = www.get
			//musicPlayer.clip = www.GetAudioClip(false, false);
			//musicPlayer.Play();
		}
	}

	IEnumerator loadStreamingAsset(string fileName)
	{
		
		string filePath = System.IO.Path.Combine(Application.streamingAssetsPath, fileName);

		string result;

		if (filePath.Contains("://") || filePath.Contains(":///") || filePath.Contains(":/"))
		{
			WWW www = new WWW(filePath);
			yield return www;
			result = www.text;
			ReceiveJson(result);
		}
		//else
		//	result = System.IO.File.ReadAllText(filePath);
	}

	void ReceiveJson(string textJson){
		score = JsonUtility.FromJson<Scores>(jsonScore.text);

		WriteScore();
	}

	public void myCorote(){
		StartCoroutine(getTexttoFile());
		Debug.Log(Application.absoluteURL);
	}

	public void SetPhp(){
		StartCoroutine(sendTexttoFile());
	}

	IEnumerator sendTexttoFile(){
		bool success = true;

		WWWForm form = new WWWForm();
		form.AddField("jsonScore",/*"score" */JsonUtility.ToJson(score));
		WWW www = new WWW("http://localhost:80/Local/phpscore.php", form);
		//https://apps.univesp.br/na-roda-do-mundo-la-vem-o-menino
		//http://localhost:80/Local/
		//Application.absoluteURL + "phpscore.php"
		yield return www;
		if(www.error != null){
			success = false;
		}else{
			Debug.Log(www.text);
			success =true;
		}
	}

	IEnumerator getTexttoFile(){
		bool success = true;

		//Debug.Log("get stuff");

		WWWForm form = new WWWForm();
		
		WWW www = new WWW("http://localhost:80/Local/phpget.php", form);
				yield return www;
		if(www.error != null){
			success = false;
		}else{
			Debug.Log(www.text);
			success =true;
		}
	}
}

using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.Extensions.Configuration;
using System.Text;
using Microsoft.Extensions.Configuration.Json;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {

		var json=new MemoryStream(Encoding.UTF8.GetBytes(@"{
  'option1': 'value1_from_json',
  'option2': 2,

  'subsection': {
    'suboption1': 'subvalue1_from_json'
  },
  'wizards': [
    {
      'Name': 'Gandalf',
      'Age': '1000'
    },
    {
      'Name': 'Harry',
      'Age': '17'
    }
  ]
}"));

var dict = new JsonConfigurationFileParser().Parse(json);

		 var builder = new ConfigurationBuilder();
		         builder.AddInMemoryCollection(dict);	

        var configuration = builder.Build();

        Debug.LogWarning($"option1 = {configuration["option1"]}");
        Debug.LogWarning($"option2 = {configuration["option2"]}");
        Debug.LogWarning($"suboption1 = {configuration["subsection:suboption1"]}");


        Debug.Log("Wizards:");
        Debug.LogWarning($"{configuration["wizards:0:Name"]}, ");
        Debug.LogWarning($"age {configuration["wizards:0:Age"]}");
        Debug.LogWarning($"{configuration["wizards:1:Name"]}, ");
        Debug.LogWarning($"age {configuration["wizards:1:Age"]}");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

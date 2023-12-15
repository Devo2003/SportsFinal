using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace SportsFinal
{
    public class SavingData
    {
        public static void SaveData<T>(string filepath, ObservableCollection<T> data)
        {
            try
            {
                string json = JsonConvert.SerializeObject(data, Formatting.Indented);
                //this writes JSON to the file
                File.WriteAllText(filepath, json);
            }
            catch (Exception ex)
            {
                //error if file is not found
                Console.WriteLine($"Error loading data to {filepath}: {ex.Message}");
            }
           
        }

        

    }
}

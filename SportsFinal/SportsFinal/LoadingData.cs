using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace SportsFinal
{
    public class LoadingData
    {

        public static ObservableCollection<T> LoadData<T>(string filepath)
        {

            try
            {
                if (File.Exists(filepath))
                {
                    string json = File.ReadAllText(filepath);
                    return JsonConvert.DeserializeObject<ObservableCollection<T>>(json);
                }
                return new ObservableCollection<T>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving data to {filepath}: {ex.Message}");
                return new ObservableCollection<T>();
            }
            
            
               
            
        }

    }
}

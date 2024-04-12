using System.Text.Json;

public class DataLoad : DataLoadBase {

    public override List<T> Load<T>(string local){
        local = local + ".json";
        if(!File.Exists(local))
            throw new ArgumentException(local);
        
        string json = File.ReadAllText(local);
    
        return JsonSerializer.Deserialize<List<T>>(json);    
    }
}
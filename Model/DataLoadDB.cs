using System.Text.Json;

public class DataLoadDB : IDataLoad {

    public DataLoadDB(){
        
    }

    public List<Cidade> Cidades(){
        return Load<Cidade>(".\\Files\\cities.json");
    }

    public List<Estado> Estados(){
        return Load<Estado>(".\\Files\\states.json");
    }

    public List<Pais> Paises(){
        return Load<Pais>(".\\Files\\countries.json");
    }
    public List<T> Load<T>(string local){
        if(!File.Exists(local))
            throw new ArgumentException(local);
        
        string json = File.ReadAllText(local);
    
        return JsonSerializer.Deserialize<List<T>>(json);    
    }
}
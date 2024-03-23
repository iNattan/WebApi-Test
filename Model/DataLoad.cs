using System.Text.Json;

public static class DataLoad{

    public static List<Cidade> Cidades(){
        return Load<Cidade>(".\\Files\\cities.json");
    }

    public static List<Estado> Estados(){
        return Load<Estado>(".\\Files\\states.json");
    }

    public static List<Pais> Paises(){
        return Load<Pais>(".\\Files\\countries.json");
    }
    public static List<T> Load<T>(string local){
        if(!File.Exists(local))
            throw new ArgumentException(local);
        
        string json = File.ReadAllText(local);
    
        return JsonSerializer.Deserialize<List<T>>(json);    
    }
}
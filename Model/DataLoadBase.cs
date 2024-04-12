using System.Text.Json;

public abstract class DataLoadBase : IDataLoad {

    public List<Cidade> Cidades(){
        return Load<Cidade>(".\\Files\\cities");
    }

    public List<Estado> Estados(){
        return Load<Estado>(".\\Files\\states");
    }

    public List<Pais> Paises(){
        return Load<Pais>(".\\Files\\countries");
    }

    public abstract List<T> Load<T>(string local);
}
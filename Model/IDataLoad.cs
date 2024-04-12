using System.Text.Json;

public interface IDataLoad
{
    List<Cidade> Cidades();

    List<Estado> Estados();

    List<Pais> Paises();

    List<T> Load<T>(string local);
}
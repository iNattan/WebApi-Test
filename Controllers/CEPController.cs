using Microsoft.AspNetCore.Mvc;

namespace WebApiAtvd.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class CEPController : ControllerBase
{
    private readonly ILogger<CEPController> _logger;

    public CEPController(ILogger<CEPController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "Cidade")]
    public IEnumerable<string> Cidades([FromHeader] string UF, [FromHeader] string sigla)    
    {
        List<Cidade> cidades = DataLoad.Cidades();
        var objCidade = cidades.Where(c => c.state_code == UF && c.country_code == sigla);
        var nome = objCidade.Select(c => c.name);
        return nome; 
    }

    [HttpGet(Name = "Estado")]
    public IEnumerable<string> Estados([FromHeader] string sigla)    
    {
        List<Estado> estados = DataLoad.Estados();
        var objEstado = estados.Where(e => e.country_code == sigla);
        var nome = objEstado.Select(e => e.name);
        return nome; 
    }

    [HttpGet(Name = "Países")]
    public IEnumerable<string> Paises()    
    {
        List<Pais> paises = DataLoad.Paises();
        var nome = paises.Select(p => p.name);
        return nome; 
    }

    [HttpGet(Name = "CEP")]
    public IEnumerable<object> CEP([FromHeader] string cidade) 
    {
        List<Cidade> cidades = DataLoad.Cidades();
        var objCidade = cidades.Where(c => c.name == cidade);
        var CEP = objCidade.Select(c => new {
            Cidade = c.name,
            Estado = c.state_name,
            País = c.country_name
            });
        return CEP; 
    }
}
using API_Stefanini.Modelos;
using API_Stefanini.View_Model;
using Microsoft.AspNetCore.Mvc;

namespace API_Stefanini.Controladores;

// Primeiramente o controlador é definido como um APIController e então é declarada a rota 
// "api/v1/tarefas" como padrão para qualquer requisição que seja utilizada por essa api.
[ApiController]
[Route("/api/v1/tarefas")]
public class ControladorTarefas : ControllerBase
{
    // Este trecho do código puxa as informações da interface de repositório de tarefas
    // e as guarda na variável _tarefasRepository.
    private readonly InterfaceTarefaRepository _tarefasRepository;
    
    // Este trecho de código garante que a variável _tarefasRepository não é nula 
    public ControladorTarefas(InterfaceTarefaRepository tarefasRepository)
    {
        _tarefasRepository = tarefasRepository ?? throw new ArgumentNullException();
    }
    
    // Este trecho de código contem uma requisição post que é responsável por adicionar uma nova 
    // tarefa ao banco de dados do Postgres. Ele cria uma variável que recebe um novo objeto Tarefa
    // com os parâmetros que são passados a ele e então adiciona essa nova tarefa ai banco, retornando
    // um código 200 com a mensagem "Tarefa adicionada".
    [HttpPost("adicionar-tarefa")]
    public IActionResult AdicionarTarefa([FromBody] TarefaViewModel tarefaViewModel)
    {
        var tarefa = new Tarefa(tarefaViewModel.Tarefa, tarefaViewModel.Descrição, tarefaViewModel.Status);
        
        _tarefasRepository.Add(tarefa);

        return Ok("Tarefa adicionada");
    }
    
    // Este trecho de código é um segundo método Post que é responsável por buscar uma tarefa específica
    // no banco por meio do número de id dela. Após encontrar a tarefa a API responde com um código 200
    // e retorna a tarefa na requisição.
    [HttpPost]
    [Route("{id}/Take")]
    public IActionResult PegarTarefaEspecifica(int id)
    {
        var tarefa = _tarefasRepository.Get(id);

        return Ok(tarefa);
    }
    
    // Este trecho de código é o último endpoint do controlador e é responsável por entrar no banco
    // de dados e puxar todas as tarefas inseridas nele até o momento por meio de um método get. Caso
    // a operação tenha sucesso a API retorna um código 200 com a lista de tarefas em formato de JSON.
    [HttpGet("listar-tarefas")]
    public IActionResult ListarTarefas()
    {
        var tarefas = _tarefasRepository.Get();

        return Ok(tarefas);
    }
}
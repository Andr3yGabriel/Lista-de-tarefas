using API_Stefanini.Modelos;

namespace API_Stefanini.Conexão_com_o_banco;

public class TarefaRepository : InterfaceTarefaRepository
{
    
    // Aqui é chamada a conexão com o banco para poder fazer as alterações de cada requisição.
    private readonly ContextoConexao _context = new ContextoConexao();
    
    // A função Add se refere ao método Post de AdicionarTarefa do controlador.
    // Neste arquivo o banco identifica a tarefa, adiciona ela ao banco e salva as alterações.
    public void Add(Tarefa tarefa)
    {
        _context.Tarefa.Add(tarefa);
        _context.SaveChanges();
    }
    
    // A função List<Tarefa> é responsável por puxar todas as tarefas do banco e listar por meio
    // de uma requisição do tipo Get.
    public List<Tarefa> Get()
    {
        return _context.Tarefa.ToList();
    }
    
    // Esta função é responsável por entrar no banco e encontrar o id informado na requisição
    // post para poder puxar as informações e exibir no front-end.
    public Tarefa? Get(int id)
    {
        return _context.Tarefa.Find(id);
    }
}
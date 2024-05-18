namespace API_Stefanini.Modelos;


// Na interface são declaradas as funções que serão utilizadas nas requisições feitas no arquivo
// controlador, basicamente servem de modelo para as requisições.
public interface InterfaceTarefaRepository
{
    void Add(Tarefa tarefa);

    List<Tarefa> Get();

    Tarefa? Get(int id);
}
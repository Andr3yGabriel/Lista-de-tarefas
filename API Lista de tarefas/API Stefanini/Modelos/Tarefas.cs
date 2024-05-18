using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Stefanini.Modelos;

// A classe Tarefa é a que armazena o formato que as informações estão guardadas no banco para que
// não existam ambiguidades ou erros na hora de inserir ou puxar dados do banco.
[Table("tarefas")]
public class Tarefa
{
    [Key]
    
    // O Id é um sequencial de identificação da tarefa
    public int id { get; private set; }
    
    // O campo tarefa é responsável por guardar o nome dado a tarefa
    public string tarefa { get; private set; }
    
    // A descrição é um campo longo de até 300 caracteres no banco que serve para guardar as
    // informações sobre a tarefa
    public string descrição { get; private set; }
    
    // O status da tarefa conta com os estágios de 'Fila' para quando a tarefa inda não foi iniciada
    // 'Parada' para quando a tarefa já foi iniciada mas não está em andamento no momento, 'Finalizada'
    // para quando a tarefa já foi concluída e 'Em andamento' pra quando a tarefa está em progresso.
    public string status { get; private set; }
    
    // Aqui é declarado como o objeto tarefa será preenchido.
    public Tarefa(string tarefa, string descrição, string status)
    {
        this.tarefa = tarefa ?? throw new ArgumentNullException(nameof(tarefa));
        this.descrição = descrição;
        this.status = status;
    }
    
}
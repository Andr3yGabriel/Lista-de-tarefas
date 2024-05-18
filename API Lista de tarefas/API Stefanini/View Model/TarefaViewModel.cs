namespace API_Stefanini.View_Model;

// A viewModel é utilizada para simplificar o preenchimento dos campos de requisição e para
// servir de modelo de visualização de como os dados são inseridos na tabela.
public class TarefaViewModel
{
    public string Tarefa { get; set; }

    public string Descrição { get; set; }
    
    public string Status { get; set; } 
}
namespace TopSchool.API.Models
{
    public class AlunoDisciplinasModel : ModelBase
    {
        public int AlunoModelId { get; set; }
        public int DisciplinaProfessorModelId { get; set; }
        public AlunoModel Aluno { get; set; }
        public DisciplinaProfessorModel Disciplina { get; set; }

        public AlunoDisciplinasModel(){}
        public AlunoDisciplinasModel(int alunoModelId, int disciplinaProfessorModelId)
        {
            AlunoModelId = alunoModelId;
            DisciplinaProfessorModelId = disciplinaProfessorModelId;
        }

        public AlunoDisciplinasModel(int alunoModelId, int disciplinaModelId, AlunoModel aluno, DisciplinaProfessorModel disciplina)
        {
            AlunoModelId = alunoModelId;
            DisciplinaProfessorModelId = disciplinaModelId;
            Aluno = aluno;
            Disciplina = disciplina;
        }
    }
}

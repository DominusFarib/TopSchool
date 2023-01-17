namespace TopSchool.Domain.Models;
public class AlunoDisciplinasModel : ModelBase
    {
        public int AlunoId { get; set; }
        public int DisciplinaProfessoresId { get; set; }
        public AlunoModel Aluno { get; set; }
        public DisciplinaProfessoresModel ProfessorDaDisciplina { get; set; }

        public AlunoDisciplinasModel(){}
        public AlunoDisciplinasModel(int alunoModelId, int disciplinaProfessorModelId)
        {
            AlunoId = alunoModelId;
            DisciplinaProfessoresId = disciplinaProfessorModelId;
        }

        public AlunoDisciplinasModel(int alunoModelId, int disciplinaModelId, AlunoModel aluno, DisciplinaProfessoresModel disciplina)
        {
            AlunoId = alunoModelId;
            DisciplinaProfessoresId = disciplinaModelId;
            Aluno = aluno;
            ProfessorDaDisciplina = disciplina;
        }
    }

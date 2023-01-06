namespace TopSchool.API.Models
{
    public class DisciplinaProfessorModel : ModelBase
    {
        public int ProfessorId { get; set; }
        public int DisciplinaId { get; set; }
        public ProfessorModel Professor { get; set; }
        public DisciplinaModel Disciplina { get; set; }

        public DisciplinaProfessorModel(){}
        public DisciplinaProfessorModel(int professorId, int disciplinaId)
        {
            ProfessorId = professorId;
            DisciplinaId = disciplinaId;
        }

        public DisciplinaProfessorModel(ProfessorModel professor, DisciplinaModel disciplina)
        {
            Professor = professor;
            Disciplina = disciplina;
        }
    }
}

import { Disciplina } from "./Disciplina";

export class Aluno {
  id!: number;
  idade!: number;
  nome!: string;
  nrMatricula!: number;
  alunoDisciplinas: Disciplina[] = [];
}

import { Disciplina } from './Disciplina';

export class Professor {
  id!: number;
  nome!: string;
  disciplinasDoProfessor: Disciplina[] = [];
}

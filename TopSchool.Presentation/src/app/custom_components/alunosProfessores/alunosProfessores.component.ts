import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Professor } from 'src/app/models/Professor';
import { Utils } from '../../utils/utils';
import { Disciplina } from 'src/app/models/Disciplina';
import { Router } from '@angular/router';

@Component({
  selector: 'app-alunosProfessores',
  templateUrl: './alunosProfessores.component.html',
  styleUrls: ['./alunosProfessores.component.css']
})
export class AlunosProfessoresComponent implements OnInit {

  @Input()
  public professores: Professor[] = [];
  @Output() closeModal = new EventEmitter();

  constructor(private router: Router) { }

  //constructor() { }

  ngOnInit(): void {
  }

  disciplinaConcat(disciplinas: Disciplina[]): string {
    return Utils.nomeConcat(disciplinas);
  }

  professorSelect(prof: Professor): void {
    this.closeModal.emit(null);
    this.router.navigate(['/professores', prof.id]);
  }

}

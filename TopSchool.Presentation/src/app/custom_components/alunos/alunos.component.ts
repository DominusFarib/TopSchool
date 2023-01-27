import { Component, OnInit, TemplateRef, OnDestroy } from '@angular/core';
import { Aluno } from '../../models/Aluno';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';
import { AlunosService } from '../../services/alunos.service';
import { takeUntil } from 'rxjs/operators';
import { Subject } from 'rxjs';
import { ProfessorService } from '../../services/professores.service';
import { Professor } from '../../models/Professor';
import { ActivatedRoute } from '@angular/router';
import { Disciplina } from 'src/app/models/Disciplina';

@Component({
  selector: 'app-alunos',
  templateUrl: './alunos.component.html',
  styleUrls: ['./alunos.component.css']
})
export class AlunosComponent implements OnInit, OnDestroy {

  public modalRef!: BsModalRef;
  public alunoForm!: FormGroup;
  public titulo: string = 'Alunos';
  public alunoSelecionado: Aluno = new Aluno;
  public textSimple!: string;
  public profsAlunos: Professor[] = [];

  private unsubscriber = new Subject();

  public alunos: Aluno[] = [];
  public aluno: Aluno = new Aluno;
  public msnDeleteAluno!: string;
  public modeSave: string = 'post';

  openModal(template: TemplateRef<any>, alunoId: number) {
    this.professoresAlunos(template, alunoId);
  }

  closeModal() {
    this.modalRef.hide();
  }

  professoresAlunos(template: TemplateRef<any>, id: number) {
    this.spinner.show();
    this.professorService.getByAlunoId(id)
      .pipe(takeUntil(this.unsubscriber))
      .subscribe((professores: Professor[]) => {
        this.profsAlunos = professores;
        this.modalRef = this.modalService.show(template);
      }, (error: any) => {
        this.toastr.error(`erro: ${error}`);
        console.log(error);
        this.spinner.hide();
      }, () => this.spinner.hide()
      );
  }

  constructor(
    private alunoService: AlunosService,
    private route: ActivatedRoute,
    private professorService: ProfessorService,
    private fb: FormBuilder,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService
  ) {
    this.criarForm();
  }

  ngOnInit() {
    this.carregarAlunos();
  }

  ngOnDestroy(): void {
    this.unsubscriber.next(new Object());
    this.unsubscriber.complete();
  }

  criarForm() {
    this.alunoForm = this.fb.group({
      id: [0],
      nome: ['', Validators.required],
      idade: [''],
      nrMatricula: ['', Validators.required]
    });
  }

  saveAluno() {
    if (this.alunoForm.valid) {
      this.spinner.show();
      //const disp = <Disciplina>{};
      //const disp: Disciplina[] = [];

      if (this.modeSave === 'post') {
        this.aluno = { ...this.alunoForm.value };

      } else {
        this.aluno = { id: this.alunoSelecionado.id, ...this.alunoForm.value };
      }
      this.aluno.alunoDisciplinas = [];
      var nada = null;
      var met: string = 'post';
      switch (this.modeSave) {
        case 'post': this.toastr.success('Aluno NOVO?'); nada = this.alunoService.post(this.aluno); break;
        case 'get': nada = this.alunoService.getById(this.aluno.id); break;
        case 'put': this.toastr.success('Aluno A atualizar?' + JSON.stringify(this.aluno)); nada = this.alunoService.put(this.aluno); break;
        case 'patchValue': nada = this.alunoService.post(this.aluno); break;
      }
      (this.alunoService as any)[this.modeSave];
      nada = this.alunoService.post(this.aluno);

      nada.pipe(takeUntil(this.unsubscriber))
        .subscribe(
          () => {
            this.carregarAlunos();
            this.toastr.success('Aluno salvo com sucesso!');
          }, (error: any) => {
            this.toastr.error(`Erro: Aluno não pode ser salvo!` + JSON.stringify(this.aluno));
            console.error(error);
            this.spinner.hide();
          }, () => this.spinner.hide()
        );

    }
  }

  carregarAlunos() {
    const id = this.route.snapshot.paramMap.get('id') != null ? this.route.snapshot.paramMap.get('id') : 0;

    this.spinner.show();
    this.alunoService.getAll()
      .pipe(takeUntil(this.unsubscriber))
      .subscribe((alunos: Aluno[]) => {
        this.alunos = alunos;

        if (id != null && id > 0) {

          var tmpAluno = this.alunos.find(aluno => aluno.id == id) != null ? this.alunos.find(aluno => aluno.id == id) : new Aluno();
          this.alunoSelect(tmpAluno);
        }

        this.toastr.success('Alunos foram carregado com Sucesso!');
      }, (error: any) => {
        this.toastr.error('Alunos não carregados!');
        console.log(error);
        this.spinner.hide();
      }, () => this.spinner.hide()
      );
  }

  alunoSelect(aluno: Aluno | undefined) {
    var luno: Aluno = new Aluno;
    luno = aluno != undefined ? aluno : new Aluno;
    this.modeSave = 'put';
    this.alunoSelecionado = luno;
    this.alunoForm.patchValue(luno);
  }

  voltar() {
    this.alunoSelecionado = new Aluno;
  }

}

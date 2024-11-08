import {
  NgIf,
  NgForOf,
  NgSwitch,
  NgSwitchCase,
  AsyncPipe,
} from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { Observable } from 'rxjs';
import { ListagemCategoria } from '../../categorias/models/categoria.models';
import { CategoriaService } from '../../categorias/services/categoria.service';
import { CadastroNota, DetalhesNota } from '../models/nota.models';
import { NotaService } from '../services/nota.service';
import { NotificacaoService } from '../../../core/notificacao/notificacao.service';

@Component({
  selector: 'app-edicao-nota',
  standalone: true,
  imports: [
    NgIf,
    NgForOf,
    NgSwitch,
    NgSwitchCase,
    RouterLink,
    AsyncPipe,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatIconModule,
    MatButtonModule,
    MatSelectModule,
    MatCardModule,
  ],
  templateUrl: './edicao-nota.component.html',
})
export class EdicaoNotaComponent implements OnInit {
  id?: number;
  notaForm: FormGroup;

  categorias$?: Observable<ListagemCategoria[]>;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private notaService: NotaService,
    private categoriaService: CategoriaService,
    private notificacao: NotificacaoService
  ) {
    this.notaForm = new FormGroup({
      titulo: new FormControl<string>(''),
      conteudo: new FormControl<string>(''),
      categoriaId: new FormControl<number>(0),
    });
  }

  get titulo() {
    return this.notaForm.get('titulo');
  }

  get conteudo() {
    return this.notaForm.get('conteudo');
  }

  get categoriaId() {
    return this.notaForm.get('categoriaId');
  }

  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];

    if (!this.id) {
      this.notificacao.erro('Não foi possível recuperar o id requisitado!');
      return;
    }

    this.notaService
      .selecionarPorId(this.id)
      .subscribe((res) => this.carregarFormulario(res));

    this.categorias$ = this.categoriaService.selecionarTodos();
  }

  editar(): void {
    if (!this.id) {
      this.notificacao.erro('Não foi possível recuperar o id requisitado!');
      return;
    }

    const notaEditada: CadastroNota = this.notaForm.value;

    this.notaService.editar(this.id, notaEditada).subscribe((res) => {
      this.notificacao.sucesso(
        `O registro ID [${res.id}] foi editado com sucesso!`
      );

      this.router.navigate(['/notas']);
    });
  }

  campoNaoFoiTocado(campo: string): boolean {
    const controle = this.notaForm.get(campo);

    if (!controle) return false;

    return controle.pristine;
  }

  mapearTituloDaCategoria(id: number, categorias: ListagemCategoria[]): string {
    const categoria = categorias.find((categoria) => categoria.id === id);

    return categoria ? categoria.titulo : 'Categoria não encontrada';
  }

  private carregarFormulario(registro: DetalhesNota) {
    this.notaForm.patchValue(registro);

    const campos = Object.keys(this.notaForm.controls);

    for (let campo of campos) {
      const controle = this.notaForm.get(campo);

      controle?.markAsDirty();
    }
  }
}

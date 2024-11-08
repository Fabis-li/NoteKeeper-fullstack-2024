import {
  AsyncPipe,
  NgForOf,
  NgIf,
  NgSwitch,
  NgSwitchCase,
} from '@angular/common';
import { Component, OnInit } from '@angular/core';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { Router, RouterLink } from '@angular/router';
import { Observable } from 'rxjs';
import { ListagemCategoria } from '../../categorias/models/categoria.models';
import { CategoriaService } from '../../categorias/services/categoria.service';
import { MatCardModule } from '@angular/material/card';
import { NotaService } from '../services/nota.service';
import { CadastroNota } from '../models/nota.models';
import { NotificacaoService } from '../../../core/notificacao/notificacao.service';

@Component({
  selector: 'app-cadastro-nota',
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
  templateUrl: './cadastro-nota.component.html',
})
export class CadastroNotaComponent implements OnInit {
  notaForm: FormGroup;

  categorias$?: Observable<ListagemCategoria[]>;

  constructor(
    private router: Router,
    private notaService: NotaService,
    private categoriaService: CategoriaService,
    private notificacao: NotificacaoService
  ) {
    this.notaForm = new FormGroup({
      titulo: new FormControl<string>('', [Validators.required]),
      conteudo: new FormControl<string>(''),
      categoriaId: new FormControl<number | undefined>(undefined, [
        Validators.required,
      ]),
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
    this.categorias$ = this.categoriaService.selecionarTodos();
  }

  cadastrar(): void {
    const novaNota: CadastroNota = this.notaForm.value;

    this.notaService.cadastrar(novaNota).subscribe((res) => {
      this.notificacao.sucesso(
        `O registro ID [${res.id}] foi cadastrado com sucesso!`
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
}

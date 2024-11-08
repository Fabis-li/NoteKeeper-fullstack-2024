import { NgIf, AsyncPipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { DetalhesNota } from '../models/nota.models';
import { NotaService } from '../services/nota.service';
import { Observable } from 'rxjs';
import { NotificacaoService } from '../../../core/notificacao/notificacao.service';

@Component({
  selector: 'app-exclusao-nota',
  standalone: true,
  imports: [NgIf, RouterLink, AsyncPipe, MatButtonModule, MatIconModule],
  templateUrl: './exclusao-nota.component.html',
})
export class ExclusaoNotaComponent implements OnInit {
  id?: number;
  nota$?: Observable<DetalhesNota>;

  notaArquivada: boolean;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private notaService: NotaService,
    private notificacao: NotificacaoService
  ) {
    this.notaArquivada = false;
  }

  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];

    if (!this.id) {
      this.notificacao.erro('Não foi possível recuperar o id requisitado!');
      return;
    }

    if (this.route.snapshot.queryParams['arquivada']) this.notaArquivada = true;

    this.nota$ = this.notaService.selecionarPorId(this.id);
  }

  excluir() {
    if (!this.id) {
      this.notificacao.erro('Não foi possível recuperar o id requisitado!');
      return;
    }

    this.notaService.excluir(this.id).subscribe((res) => {
      this.notificacao.sucesso(
        `O registro ID [${this.id}] foi excluído com sucesso!`
      );

      this.router.navigate(['/notas']);
    });
  }
}

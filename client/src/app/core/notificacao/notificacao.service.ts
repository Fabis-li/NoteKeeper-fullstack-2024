import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable()
export class NotificacaoService {
  constructor(private snackbar: MatSnackBar) {}

  sucesso(mensagem: string): void {
    this.snackbar.open(mensagem, 'OK', {
      panelClass: ['notificacao-sucesso'],
    });
  }

  aviso(mensagem: string): void {
    this.snackbar.open(mensagem, 'OK', {
      panelClass: ['notificacao-aviso'],
    });
  }

  erro(mensagem: string): void {
    this.snackbar.open(mensagem, 'OK', {
      panelClass: ['notificacao-erro'],
    });
  }
}
